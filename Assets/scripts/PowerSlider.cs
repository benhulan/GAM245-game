using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PowerSlider : MonoBehaviour{

    //PowerSlider
    public Slider powerSlider = null;
    
    public Timer tm;
    public CardManager cm;
    
    // public int pointsAwarded = 0;
    
    
    public bool timerIsOn = false;
    public float timeToIgnite = 120.0f;
   // public int duration = 120;
    //public int pointsAwarded;
	
    
//public  points to ignite the spell;
    
    public int points = 0;
    
	// Use this for initialization
	void Start () {
         
	//    Debug.Log(points);
       powerSlider.value = 0;
//       points = false;  
	}
   
    private void Awake(){
        
        DontDestroyOnLoad(GameObject.FindWithTag("circle"));
    }
	
	// Update is called once per frame
	void Update () {
        GameObject pointsAwardedManager = GameObject.FindWithTag("circle");
        CardManager cm = pointsAwardedManager.GetComponent<CardManager>();
        
        timeToIgnite -= Time.deltaTime;
        
        // powerSlider.maxValue = maxPower;
        // powerSlider.minValue = 0;
        
       // AddPower();
       
       powerSlider.value = points;
       
       if(points >= 10){
           if(timeToIgnite > 115 )
           {
            cm.pointsAwarded += 12;    
           }else if(timeToIgnite > 110 )
           {
            cm.pointsAwarded += 8;    
           }
           else if(timeToIgnite > 100 )
           {
            cm.pointsAwarded += 5;    
           }
           else if(timeToIgnite > 90 )
           {
            cm.pointsAwarded += 4;    
           }
           else if(timeToIgnite > 80 )
           {
            cm.pointsAwarded += 4;    
           }
           else if(timeToIgnite > 70 )
           {
            cm.pointsAwarded += 3;    
           }
           else if(timeToIgnite > 60 )
           {
            cm.pointsAwarded += 2;    
           }
           else if(timeToIgnite > 50 )
           {
            cm.pointsAwarded += 1;    
           }
           else
           {
            cm.pointsAwarded += 0;    
           }
           Debug.Log(cm.pointsAwarded+" points awarded");
           
           SceneManager.LoadScene(2);
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
        // if(gameObject.tag == "twoPoints")
        // {
           // points++;
            //Debug.Log(points);
        // } else  
        if(pointGranter.tag == "onePoint")
        {
            points++;
            Debug.Log(points);
        }else if(pointGranter.tag == "twoPoints")
        {
            points += 2;
            Debug.Log(points);
        }
        //  Slider.value ++;
		//Displays the value of the slider in the console.
       
    }
    
    
    // public void  OnTriggerExit(Collider trigger){
    //  GameObject pointGranter = trigger.gameObject;
       
            // points = false;
            // Debug.Log(points);
            // Debug.Log (powerSlider.value); 
          
    // }
    
    // public void AddPower(){
        
      //  powerSlider.value = 0;
        
    //     if (points == true){
    //             ++powerSlider.value;
    //             Debug.Log (powerSlider.value); 
    //     }    
    // }
    
    //  public void  OnTap(Vector3 startPosition){
    // //   GameObject pointGranter = trigger.gameObject;
    //     if(gameObject.tag == "twoPoints")
    //     {
    //         points += 2;
    //         Debug.Log(points);
    //     } else  if(gameObject.tag == "onePoint")
    //     {
    //         points++;
    //         Debug.Log(points);
    //     }
    // }
}
