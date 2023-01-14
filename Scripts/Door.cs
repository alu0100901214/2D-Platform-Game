using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject otherDoor;

    public bool doorExit = true;

    private SFX sfx;

    void Start(){
        sfx = GameObject.FindGameObjectWithTag("sfx").GetComponent<SFX>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(doorExit && (other.tag == "Player")) {
            if(Input.GetKey(KeyCode.W)){
                sfx.playDoorTP();
                otherDoor.GetComponent<Door>().doorExit = false;
                other.transform.position = otherDoor.transform.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        StartCoroutine(activateDoor());
    }

    IEnumerator activateDoor(){
        yield return new WaitForSeconds(0.3f);
        doorExit = true;
    }
}
