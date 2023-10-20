using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 15f;
    [SerializeField] float moveSpeed = 50f;

    [SerializeField] float destroyDelay = 0.5f;
 

    [SerializeField]TMP_Text SpeedText;

    
    
    
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
        SpeedText.text = moveSpeed + "mph";
        if(moveSpeed>=90){
            SpeedText.color = Color.red;
        }
        else{
            SpeedText.color = Color.white;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
      
        
       if(other.gameObject.tag != "Edge"){
        moveSpeed = moveSpeed-5;
        if(moveSpeed == 0){
            moveSpeed = moveSpeed + 20;
        }
       }
    }

    private void OnTriggerEnter2D(Collider2D other) {
     
        if(other.tag == "Boost" && moveSpeed<90){
        Destroy(other.gameObject,destroyDelay);
         moveSpeed = moveSpeed+10;
        }
    }
}
