using UnityEngine;
using System.Collections;

public class HideToShow : MonoBehaviour {

	// public float sec;
    public CardManager cm2;
    
    // public GameObject pausedElement = null;
    
    public GameObject pausedElement;
    
     void Start()
     {
  
             pausedElement = GameObject.FindWithTag("pausedElement");
             // Debug.Log(pausedElement); // works!
             pausedElement.gameObject.SetActive(false);
 

     }
     

    public void ShowButton () 
     {
     
        //  Debug.Log("HELLO");
         GameObject buttonHintTapped = GameObject.FindWithTag("circle");
         CardManager cm2 = buttonHintTapped.GetComponent<CardManager>();
        //  Debug.Log("cm2.hintTapped" + cm2.hintTapped);
         if (cm2.hintTapped == true)
         {
        
           Debug.Log("cm2.hintTapped" + cm2.hintTapped);
           pausedElement.gameObject.SetActive(true);  
           Debug.Log("pausedElement" + pausedElement);

         }
     }
 
   
}
