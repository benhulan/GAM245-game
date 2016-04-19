using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PowerSlider : MonoBehaviour{

    //PowerSlider
    public Slider powerSlider = null;
    
    // public TimeToIgniteSpell tm;
    public CardManager cm;
    
    // public int pointsAwarded = 0;
    
    
    public bool timerIsOn = false;
    //public float timeToIgnite = 120.0f;
   // public int duration = 120;
    //public int pointsAwarded;
	
    
//public  points to ignite the spell;
    
    public int points = 0;


    // public bool timerIsOn = false;
    public float timeToIgnite = 120.0f;
    
    public int sceneToLoad;
    
	// Use this for initialization
	void Start () {
         
	//    Debug.Log(points);
       powerSlider.value = 0;
       TimerIsOn();
  
	}
   
    private void Awake(){
        
        DontDestroyOnLoad(GameObject.FindWithTag("circle"));
    }
	
	// Update is called once per frame
	void Update () {
        GameObject pointsAwardedManager = GameObject.FindWithTag("circle");
        CardManager cm = pointsAwardedManager.GetComponent<CardManager>();
        // 

        if (timerIsOn)
        {
            //Decrease timeToIgnite
            timeToIgnite -= Time.deltaTime;
            
            Debug.Log(timeToIgnite);
        }
        
        
        //timeToIgnite -= Time.deltaTime;
        
        // powerSlider.maxValue = maxPower;
        // powerSlider.minValue = 0;
        
       // AddPower();
       
       powerSlider.value = points;
       
       if(points >= 10){

           if(timeToIgnite > 115.0f )
           {
            cm.pointsAwarded += 12;    
           }else if(timeToIgnite > 110.0f )
           {
            cm.pointsAwarded += 8;    
           }
           else if(timeToIgnite > 100.0f )
           {
            cm.pointsAwarded += 5;    
           }
           else if(timeToIgnite > 90.0f )
           {
            cm.pointsAwarded += 4;    
           }
           else if(timeToIgnite > 80.0f )
           {
            cm.pointsAwarded += 4;    
           }
           else if(timeToIgnite > 70.0f )
           {
            cm.pointsAwarded += 3;    
           }
           else if(timeToIgnite > 60.0f )
           {
            cm.pointsAwarded += 2;    
           }
           else if(timeToIgnite > 50.0f )
           {
            cm.pointsAwarded += 1;    
           }
           else
           {
            cm.pointsAwarded += 0;    
           }
           Debug.Log(cm.pointsAwarded+" points awarded");
           SceneManager.LoadScene(3);
           
       }
       
    //    Debug.Log(timeToIgnite);
	
	}
    //  public void PowerBar()
	// {
    //     Slider.value++;
	// 	//Displays the value of the slider in the console.
	// 	Debug.Log (Slider.value);
	// }
    
  public void  OnTriggerEnter(Collider trigger){
      GameObject pointGranter = trigger.gameObject;
        if(pointGranter.tag == "onePoint")
        {
            points++;
            Debug.Log("you earned 1 point" + points);
        }else if(pointGranter.tag == "twoPoints")
        {
            points += 2;
            Debug.Log("you earned double points" + points);
        }
        //  Slider.value ++;
		//Displays the value of the slider in the console.
       
    }

  public void TimerIsOn()
    {
        timerIsOn = true;
    }
    
}
