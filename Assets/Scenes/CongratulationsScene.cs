using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CongratulationsScene : MonoBehaviour
{
    public TMP_Text  pointsText;
    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }     

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartButton(){
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitButton(){
        Application.Quit();
    }
}
