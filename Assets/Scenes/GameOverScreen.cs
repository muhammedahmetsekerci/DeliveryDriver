using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public TMP_Text  pointsText;

    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }     

    public void RestartButton(){
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitButton(){
        Application.Quit();
    }
}
