using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartFindCards : MonoBehaviour {
    
    public bool timerIsOn = false;
    public bool startTimerIsOn = false;    
    
    public float timer = 10.0f;
    
    public float startTimerIn = 5.0f;
    
    
   public int sceneToLoad;
   // public int duration = 120;
    
    public Text timerTextBox = null;
    public Text startTimerIntBox = null;
    
    public RectTransform countDownPanel;
    Vector3 end;
    Vector3 start;
	
    public void Update()
    {
        GameObject.Find("TimerTextBox").GetComponent<Text>().text = timer.ToString();
        
        GameObject.Find("countDown").GetComponent<Text>().text = startTimerIn.ToString();
        // StartTimer();
        if (timerIsOn == true)
        {
            startTimerIn -= Time.deltaTime;
            if (startTimerIn <= 0.0f)
            {
                startTimerIn = 0.0f;
                HideCountDown();
                // StartTimerIsOn();
                startTimerIsOn = true;
            }
        }
        
        if (startTimerIsOn == true)
        {
            timer -= Time.deltaTime;
        
            if(timer <= 0.0f)
            { 
                SceneManager.LoadScene(sceneToLoad);
                GameObject.FindWithTag("target").BroadcastMessage("OnLoadingLevel");
                
            }
        }
    }
    
    public void StartTimer()
    {
    //translate object for 10 seconds.

        //Decrease timeToIgnite
        // timer -= Time.deltaTime;
        
        // Debug.Log(timer);
       
        
        // if(timer <= 0)
        // { 
        //     SceneManager.LoadScene(sceneToLoad);
        //     GameObject.FindWithTag("target").BroadcastMessage("OnLoadingLevel");
            
        // }
        
    }
    
    public void TimerIsOn()
    {

            timerIsOn = true;
        
    }
    
    // public void StartTimerIsOn()
    // {

    //         startTimerIsOn = true;
        
    // }
    
    public void HideInstructions()
    {
        GameObject.FindWithTag("instructions").SetActive(false);   
    }
    
    public void HideCountDown()
    {
        
       countDownPanel = GameObject.FindWithTag("countdown").GetComponent<RectTransform>();
       countDownPanel.anchoredPosition = Vector3.Lerp(start, end, timer);
       start = countDownPanel.anchoredPosition;
       end = start;
       end.y -= countDownPanel.rect.height;
       // DebugLogger.LogMessage("count down panel should desapear");
    }
    
  
}
