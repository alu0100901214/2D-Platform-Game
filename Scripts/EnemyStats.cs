using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    
    public float health;
    public float maxHealth;
    private SFX sfx;
    
    void Awake(){
        sfx = GameObject.FindGameObjectWithTag("sfx").GetComponent<SFX>();
    }

    public void takeDamage(int value){
        if( (health - value) > 0){
            health -= value;
            print("health: " + health + " / " + maxHealth);
        }else{
            sfx.playEnemyDie();
            print("Defeated");
            gameObject.SetActive(false);
        }
    }
}
