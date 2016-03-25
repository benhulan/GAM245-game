using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PowerSlider : MonoBehaviour{

    //PowerSlider
    public Slider powerSlider = null;
    
    public Timer tm;
    
    public int pointsAwarded = 0;
    
    
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
	
	// Update is called once per frame
	void Update () {
        timeToIgnite -= Time.deltaTime;
        
        // powerSlider.maxValue = maxPower;
        // powerSlider.minValue = 0;
        
       // AddPower();
       
       powerSlider.value = points;
       
       if(points >= 10){
           if(timeToIgnite > 110 )
           {
            pointsAwarded = 11;    
           }
           else if(timeToIgnite > 100 )
           {
            pointsAwarded = 5;    
           }
           else if(timeToIgnite > 90 )
           {
            pointsAwarded = 4;    
           }
           else if(timeToIgnite > 80 )
           {
            pointsAwarded = 4;    
           }
           else if(timeToIgnite > 70 )
           {
            pointsAwarded = 3;    
           }
           else if(timeToIgnite > 60 )
           {
            pointsAwarded = 2;    
           }
           else if(timeToIgnite > 50 )
           {
            pointsAwarded = 1;    
           }
           else
           {
            pointsAwarded = 0;    
           }
           Debug.Log(pointsAwarded+" points awarded");
           
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
