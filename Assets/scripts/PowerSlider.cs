using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerSlider : MonoBehaviour{

    //PowerSlider
    public Slider powerSlider = null;
    
   
    // public float maxPower;
    
    
    public bool points;
    
	// Use this for initialization
	void Start () {
        
	Debug.Log(points);
        powerSlider.value = 0;
        points = false;  
	}
	
	// Update is called once per frame
	void Update () {
        
        // powerSlider.maxValue = maxPower;
        // powerSlider.minValue = 0;
        
       // AddPower();
	
	}
    //  public void PowerBar()
	// {
    //     Slider.value++;
	// 	//Displays the value of the slider in the console.
	// 	Debug.Log (Slider.value);
	// }
    
  public void  OnTriggerEnter(Collider trigger){
     // GameObject pointGranter = trigger.gameObject;
        // if(gameObject.tag == "twoPoints")
        // {
            points = true;
            Debug.Log(points);
        // } else  if(gameObject.tag == "onePoint")
        // {
            // points++;
            // Debug.Log(points);
        // }
        //  Slider.value ++;
		//Displays the value of the slider in the console.
       
    }
    
    
    public void  OnTriggerExit(Collider trigger){
    //  GameObject pointGranter = trigger.gameObject;
       
            points = false;
            Debug.Log(points);
            Debug.Log (powerSlider.value); 
          
    }
    
    public void AddPower(){
        
      //  powerSlider.value = 0;
        
        if (points == true){
                ++powerSlider.value;
                Debug.Log (powerSlider.value); 
        }    
    }
    
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
