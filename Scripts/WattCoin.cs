using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WattCoin : MonoBehaviour
{

    private PlayerStats stats;
    private SFX sfx;
    public int energyRecover;

    private void Awake() {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        sfx = GameObject.FindGameObjectWithTag("sfx").GetComponent<SFX>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            sfx.playRecolectable();
            stats.gainEnergy(energyRecover);
            gameObject.SetActive(false);
        }
        
    }

}
