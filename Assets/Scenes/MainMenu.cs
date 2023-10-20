using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text howToPlayText;
    public void HowToPlay(){
        howToPlayText.gameObject.SetActive(true);
    }

    public void PlayGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void GoToSettingsMenu(){
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
