using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingItem : MonoBehaviour
{
    
    private SpriteRenderer rend;
    Color pinkColor;
    Color blueColor;
    void Start(){
        rend = GetComponent<SpriteRenderer>();
        pinkColor = new Color(0.9f, 0.5f, 0.9f, 1);
        blueColor = new Color(0.5f, 0.9f, 0.9f, 1);     
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            rend.color = blueColor;
            other.GetComponent<GrapplingHook>().SetItemPos(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            rend.color = pinkColor;
            other.GetComponent<GrapplingHook>().SetItemPos(null);
        }
    }
}
