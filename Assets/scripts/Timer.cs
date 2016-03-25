using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    
    public bool timerIsOn = false;
    public float timeToIgnite = 120.0f;
   // public int duration = 120;
    //public int pointsAwarded;
	
    public void Update()
    {
        //translate object for 10 seconds.
        if (timerIsOn)
        {
            //Decrease timeToIgnite
            timeToIgnite -= Time.deltaTime;
            
            Debug.Log(timeToIgnite);
        }
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
