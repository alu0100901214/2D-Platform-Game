using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private SpriteRenderer rend;
    private Animator animator;
    //public Color color;

    public delegate void leverDelegate();
    public event leverDelegate OnLeverActivate;

    private bool onRange;
    private bool activableAgain;
    private SFX sfx;

    void Start(){
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        sfx = GameObject.FindGameObjectWithTag("sfx").GetComponent<SFX>();
        rend.color = Color.red;
        onRange = false;
        activableAgain = true;
    }

    void Update() {
        if(onRange && activableAgain){
            if(Input.GetKey(KeyCode.E)){
                sfx.playDoorSwitch();
                animator.SetBool("lever", true);
                OnLeverActivate();
                activableAgain = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            onRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            onRange = false;
        }
    }
}
