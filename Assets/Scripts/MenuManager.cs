using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    public GameObject instructionPanel;

    [SerializeField]
    public Button playButton, menuButton, quitButton; //, closeButton;

    [SerializeField]
    public GameObject image;

    public void playGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void instructionMenu(){
        instructionPanel.SetActive(true);
        playButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        image.SetActive(false);
    }

    public void ExitGame(){
        if(Application.platform == RuntimePlatform.WebGLPlayer || Application.platform == RuntimePlatform.WindowsEditor){
            SceneManager.LoadScene("ThanksForPlaying");
        }
        else if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.Android){
            Application.Quit();
        }
    }

    public void closeInstruction(){
        instructionPanel.SetActive(false);
        playButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        image.SetActive(true);
    }

}
