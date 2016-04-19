using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TimeToIgniteSpell : MonoBehaviour {
    
    public bool timerIsOn = false;
    public float timeToIgnite = 120.0f;
    
    public int sceneToLoad;
	
    public void Start()
    {
        TimerIsOn();
    }
    
    public void Update()
    {
        
        //translate object for 10 seconds.
        if (timerIsOn)
        {
            //Decrease timeToIgnite
            timeToIgnite -= Time.deltaTime;
            
            // Debug.Log(timeToIgnite); // works!
        }
        
       /* if(timeToIgnite <= 0)
        { 
            SceneManager.LoadScene(sceneToLoad);
            GameObject.FindWithTag("target").BroadcastMessage("OnLoadingLevel");
            
        }*/
    }
    
    public void TimerIsOn()
    {
        timerIsOn = true;
    }
    
    // public void StartTimer()
    // {
    //     timerIsOn = true;
    // }
    
    // public void Begin()
    // {
    //     if (!timerIsOn){
    //         timerIsOn = true;
    //         timeToIgnite = duration;
    //         Invoke ("_tick", 1f);
    //     }
    // }
    
    // private _tick(){
    //     timeToIgnite--;
    //     if(timeToIgnite > 0){
    //         Invoke ("_tick", 1f);
    //     } else {
    //         timeToIgnite = false;
    //     }
    // }
}
