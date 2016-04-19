using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TargetedCard : MonoBehaviour {

	public TargetScript ts;
    
    public bool hitCard = false;
    
    public GameObject targetRay = null;
    public GameObject my_camera = null;
    
    private RaycastHit hit;
    
    public Timer tm;
    public bool timerIsOn = false;
    
    /*
    string [] names;
    string r = names[Random.Range(0, names.Length)];
    */
    
    public void OnTriggerStay(Collider trigger)
    {
        GameObject card = trigger.gameObject;
        TargetScript ts = card.GetComponent<TargetScript>();

        
        
        if(ts == null)
        {
            return;
        }
        
        //Draws a line from the Draws a line from the targetRay downward slighly.
		Debug.DrawLine (targetRay.transform.position, targetRay.transform.up,  Color.red);
		

        if(Physics.Raycast(targetRay.transform.position, targetRay.transform.forward, out hit))
        {
            
            //this checks if there is something in front of the card
            if (hit.collider == null) 
            {
                //hit nothing
                hitCard = false;
            } else
            {
                //hit something
                hitCard = true;
                // Debug.Log("I'm hitting something"); // works!
            }
            
            if(hitCard == true) 
            {      
                if (this.gameObject.tag == "water1")
                    
                {   
                    ts.m_currentlySelectedCards.Add(ts.m_waterCard);
                    this.gameObject.SetActive(false);
                    ts.containsWater = true;
                    
                
                }
                else if (this.gameObject.tag == "fire1")
                    
                {   
                    ts.m_currentlySelectedCards.Add(ts.m_fireCard);
                    this.gameObject.SetActive(false);
                    ts.containsFire = true;

                }
                else if (this.gameObject.tag =="air1")
                    
                {   
                    ts.m_currentlySelectedCards.Add(ts.m_airCard);
                    this.gameObject.SetActive(false);
                    ts.containsAir = true;

                }
                else if (this.gameObject.tag =="earth1")
                    
                {   
                    ts.m_currentlySelectedCards.Add(ts.m_earthCard);
                    this.gameObject.SetActive(false);
                    ts.containsEarth = true;

                }
                else if (this.gameObject.tag =="energy1")
                    
                {   
                    ts.m_currentlySelectedCards.Add(ts.m_energyCard);
                    this.gameObject.SetActive(false);
                    ts.containsEnergy = true;

                } 
            }
       }
        
	}
}
