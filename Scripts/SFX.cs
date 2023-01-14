using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{

    public AudioSource jump;
    public AudioSource shoot;
    public AudioSource projectileDestroy;
    public AudioSource recolectable;
    public AudioSource enemyDie;
    public AudioSource jumper;
    public AudioSource doorSwitch;
    public AudioSource doorTP;
    public AudioSource hook;
    public AudioSource hit;
    public AudioSource pause;
    public AudioSource ui;

    public void playJump(){
        jump.Play();
    }

    public void playShoot(){
        shoot.Play();
    }

    public void playProjectileDestroy(){
        projectileDestroy.Play();
    }

    public void playRecolectable(){
        recolectable.Play();
    }

    public void playEnemyDie(){
        enemyDie.Play();
    }

    public void playJumper(){
        jumper.Play();
    }

    public void playDoorSwitch(){
        doorSwitch.Play();
    }

    public void playDoorTP(){
        doorTP.Play();
    }

    public void playHook(){
        hook.Play();
    }

    public void playHit(){
        hit.Play();
    }

    public void playPause(){
        pause.Play();
    }

    public void playUI(){
        ui.Play();
    }
    
}
