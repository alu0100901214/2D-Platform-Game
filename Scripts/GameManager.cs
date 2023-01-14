using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    private SFX sfx;

    public bool isPaused;

    public GameObject pauseMenu;

    void Start() {
        Time.timeScale = 1;
        sfx = GameObject.FindGameObjectWithTag("sfx").GetComponent<SFX>();
        isPaused = false;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!isPaused){
                sfx.playPause();
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            } else {
                sfx.playUI();
                isPaused = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void continueButton(){
        sfx.playUI();
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void restartButton(){
        Time.timeScale = 1;
        SceneManager.LoadScene("testLevel");
    }

    public void exitButton(){
        Time.timeScale = 1;
        SceneManager.LoadScene("mainMenu");
    }
}
