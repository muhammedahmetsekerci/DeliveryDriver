using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Delivery : MonoBehaviour
{
    //[SerializeField] Color32 hasGoldColor = new Color32 (1, 1, 1, 1);
    //[SerializeField] Color32 noGoldColor = new Color32 (1, 1, 1, 1);
    
    int goldQuantity=0;
    [SerializeField]TMP_Text goldScoreText;
    [SerializeField]int totalGoldQuantity=4;
    [SerializeField]int goldPoint=20;
    [SerializeField]int bumpScore=-1;

    [SerializeField] Image panel;
    [SerializeField]TMP_Text healthText;
    [SerializeField] int health=100;
    int bumpNumber=0;
   public int totalScore;

    public AudioClip audioSource;

    [SerializeField] GameOverScreen gameOverScreen;
    [SerializeField] CongratulationsScene congratulationsScene;
 
    public GameObject[] ChestOpenClose;
    [SerializeField] float destroyDelay=0.1f;

    private void Start() {
        Time.timeScale = 1;
    }

    public int TotalScore(){
        return totalScore = (goldPoint*goldQuantity) +  (bumpScore*bumpNumber);
    }
    
    public void GameWin(){
        Time.timeScale = 0;
        congratulationsScene.Setup(totalScore);
    }
    public void GameOver(){
        panel.gameObject.SetActive(false);
        Time.timeScale = 0;
        TotalScore();
        gameOverScreen.Setup(5);
        gameObject.SetActive(true);
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
         if(other.gameObject.tag != "Edge"){
            if(health>0){
             health = health-5;
             
             if(health<20){
                healthText.color = Color.red;
             }
        }
         }
        
        bumpNumber++;
        if(health == 0){
            GameOver();
        }
        else{
            healthText.text = health.ToString();
        }
        Debug.Log("Ouch!");
        

    }

    void Update(){
       
        
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        

        if(other.tag=="Health"){
            if(health>0 && health<95){
                 Destroy(other.gameObject,destroyDelay);
                health+=10;
                healthText.text = health.ToString();
            }

            if(health>15){
                healthText.color = Color.white;
            }
        }

        if(other.tag == "Gold"){
             Debug.Log("Gold has been taken");
                        //spriteRenderer.color = hasGoldColor;
            Destroy(other.gameObject,destroyDelay);
            goldQuantity++;
            goldScoreText.text = goldQuantity.ToString();
            AudioSource.PlayClipAtPoint(audioSource, transform.position);
           
        }
       
        if(other.tag == "Chest" && goldQuantity==totalGoldQuantity){
            Debug.Log("Game Completed");
           TotalScore();
            Debug.Log("total score : " + totalScore);
            Destroy(other.gameObject,destroyDelay);
            ChestOpenClose[0].SetActive(false);
            ChestOpenClose[1].SetActive(true);
            Invoke("GameWin",0.5f);
        }
        
    }
}