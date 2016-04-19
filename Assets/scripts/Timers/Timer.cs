using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    
    // public bool timerIsOn = false;
    public float timeToIgnite = 120.0f;
    
    public int sceneToLoad;
   // public int duration = 120;
    //public int pointsAwarded;
    
//    public Text TimerTextBox;
    
    // public void Start(){
        
       // GameObject.Find("Timer Text Box").GetComponent<Text>().text = timeToIgnite.ToString();
       
    // }
	
    public void Update()
    {
         //translate object for 10 seconds.

            //Decrease timeToIgnite
        timeToIgnite -= Time.deltaTime;
        
        Debug.Log(timeToIgnite);
                
        if(timeToIgnite <= 0)
        { 
            SceneManager.LoadScene(sceneToLoad);
           // GameObject.FindWithTag("target").BroadcastMessage("OnLoadingLevel");
            
        }
    }
    
    
}
