using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    private Vector2 vector2D;

    public float speed;
    private bool active = false;

    private SFX sfx;

    private void OnEnable(){
        active = true;
    }

    private void OnDisable() {
        active = false;
    }

    void Awake() {
        sfx = GameObject.FindGameObjectWithTag("sfx").GetComponent<SFX>();
    }

    void Update(){
        if(active)
            transform.Translate(vector2D * speed * Time.deltaTime);
    }

    public void setVector2D(Vector2 v2){
        vector2D = v2;
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if( (other.gameObject.tag == "Platform") ){
            gameObject.SetActive(false);
        }
        
        if((other.gameObject.tag == "Enemy")){
            sfx.playProjectileDestroy();
            other.GetComponent<EnemyStats>().takeDamage(2);
            gameObject.SetActive(false);
        }
    }

}
