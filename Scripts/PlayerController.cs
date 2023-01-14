using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Private References
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float horizontalInput = 0f;
    [SerializeField]
    private GameObject pool;
    private PlayerStats stats;


    // Attributes
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    public float fireRate = 0.5f;
    [SerializeField]
    public float nextFire = 0.0f;

    public SFX sfx;
    public GameManager gameManager;

    //Booleans
    private bool isJumping;
    public bool facingRight;

    private void Start(){
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        stats = GetComponent<PlayerStats>();
        isJumping = true;
        facingRight = true;
    }

    private void Update(){
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Flip character and animation Walk
        if(!gameManager.isPaused){
            if(horizontalInput > 0){
                spriteRenderer.flipX = false;
                animator.SetBool("isWalking", true);
                facingRight = true;
            } else if(horizontalInput < 0){
                spriteRenderer.flipX = true;
                animator.SetBool("isWalking", true);
                facingRight = false;
            } else {
                animator.SetBool("isWalking", false);
            }
        }

        // Jump character
        if((Input.GetKey(KeyCode.Space)) && (!isJumping)){
            sfx.playJump();
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);  
            animator.SetBool("isJumpingUp", true);
        }

        // Animation falling
        if(rb2D.velocity.y < -5.5f)
            animator.SetBool("isJumpingDown", true);
        else
            animator.SetBool("isJumpingDown", false);

        // Shooting
        if(!gameManager.isPaused){
            if(Input.GetKey(KeyCode.Mouse0) && (Time.time > nextFire)){
                if(stats.currentEnergy > 1){
                    sfx.playShoot();
                    nextFire = Time.time + fireRate;
                    GameObject projectile = pool.GetComponent<objectPool>().RequestProjectile();
                    stats.loseEnergy(1);
                    if(facingRight){
                        projectile.GetComponent<Projectile>().setVector2D(Vector2.right);
                        projectile.transform.position = transform.position + new Vector3(1.3f,-0.5f,0);
                    }else{
                        projectile.GetComponent<Projectile>().setVector2D(Vector2.left);
                        projectile.transform.position = transform.position + new Vector3(-1.3f,-0.6f,0);
                    }
                }
            }
        }
        
    }

    private void FixedUpdate() {
        float currentSpeed = horizontalInput * speed * Time.fixedDeltaTime;
        Vector2 velocity = new Vector2(currentSpeed, rb2D.velocity.y);
        rb2D.velocity = velocity;
    }

    // Detect a platform that allows Jump
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Platform"){
            isJumping = false;
            animator.SetBool("isJumpingUp", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            sfx.playHit();
            gameObject.GetComponent<PlayerStats>().loseEnergy(5);
            rb2D.velocity = new Vector2(0f, 15f);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Platform"){
            isJumping = true;
        }
    }
}
