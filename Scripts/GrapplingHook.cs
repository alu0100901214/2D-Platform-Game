using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    DistanceJoint2D joint;
    bool hookActive;
    LineRenderer lr;
    Transform itemPos;
    Rigidbody2D rb2D;
    private SFX sfx;

    void Start(){
        joint = GetComponent<DistanceJoint2D>();
        sfx = GameObject.FindGameObjectWithTag("sfx").GetComponent<SFX>();
        joint.enabled = false;
        hookActive = false;
        rb2D = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    void Update() {
        
        joint.distance = 4f;
        if(Input.GetKeyDown(KeyCode.E)){
            if((joint.connectedBody != null) && (!hookActive)){
                sfx.playHook();
                joint.enabled = true;
                hookActive = true;
                lr.enabled = true;
            }else if(hookActive){
                joint.enabled = false;
                hookActive = false;
                lr.enabled = false;
                rb2D.velocity = new Vector2(0f, 25f);
            }
        }
        if(hookActive) {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, itemPos.position);
        }
    }

    public void SetItemPos(GameObject j){
        if(j != null){
            joint.connectedBody = j.GetComponent<Rigidbody2D>();
            itemPos = j.transform;
        } else{
            joint.connectedBody = null;
            joint.enabled = false;
            itemPos = null;
        }
    }

}
