using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    
    // ATTRIBUTES
    public float moveSpeed;
    public bool moveRight;

    // WALL CHECK
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    // EDGE CHECK
    private bool atEdge;
    public Transform edgeCheck;

    // PRIVATE
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;

    void Start(){
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update(){

        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        atEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if(hittingWall || !atEdge){
            moveRight = !moveRight;
        }


        if(moveRight){
            transform.localScale = new Vector2(-0.5f, 0.5f);
            rb2D.velocity = new Vector2 (moveSpeed, rb2D.velocity.y);
        } else {
            transform.localScale = new Vector2(0.5f, 0.5f);
            rb2D.velocity = new Vector2 (-moveSpeed, rb2D.velocity.y);
        }
    }
}
