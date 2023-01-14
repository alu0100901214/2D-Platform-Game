using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    private Animator animator;
    public float jumpSpeed;

    private SFX sfx;

    private void Start(){
        animator = GetComponent<Animator>();
        sfx = GameObject.FindGameObjectWithTag("sfx").GetComponent<SFX>();
    }

    public void DisableAnimation(){
        animator.SetBool("activate", false);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            sfx.playJumper();
            animator.SetBool("activate", true);
            Rigidbody2D rb2D = other.gameObject.GetComponent<Rigidbody2D>();
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
    }


}
