using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class activableDoor : MonoBehaviour
{
    private SpriteRenderer rend;
    private Animator animator;
    
    public CinemachineVirtualCamera vcamDoor; // player

    public Lever lever;

    void Start(){
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        rend.color = Color.red;
        lever.OnLeverActivate += openDoor;
    }

    void openDoor(){
        animator.SetBool("openDoor", true);
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(camTransition());
    }

    IEnumerator camTransition(){
        vcamDoor.Priority = 12;
        yield return new WaitForSeconds(3f);
        vcamDoor.Priority = 5;
    }

}
