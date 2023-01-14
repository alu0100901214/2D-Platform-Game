using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{

    public void startButton(){
        SceneManager.LoadScene("testLevel");
    }

    public void exitButton(){
        Application.Quit();
    }
}
