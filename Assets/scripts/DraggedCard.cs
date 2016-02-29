using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DraggedCard : MonoBehaviour {


   public CardManager cm;
    
   private Vector3 startPosition;
    
     public void Start()
    {
        //saves the initial position of the object
       startPosition = this.transform.position;
       //Debug.Log(startPosition); 
    }
		
    public void Update()
    {
        
        
    }
   
    
	public void OnTriggerEnter(Collider trigger)
    {
        GameObject card = trigger.gameObject;
        CardManager cm = card.GetComponent<CardManager>();
        
        if(cm.m_currentlySelectedCards.Count >= 2)
        {
            // already full
            Debug.Log("Already full.");
            transform.position = this.startPosition;
            return;
        }
        else if(cm.m_currentlySelectedCards.Count < 3)
        {
            if (gameObject.tag == "water")
                
            {   
                cm.m_currentlySelectedCards.Add(cm.m_waterCard);
            
            }
            else if (gameObject.tag == "fire")
                
            {   
                cm.m_currentlySelectedCards.Add(cm.m_fireCard);
    
            }
            else if (gameObject.tag == "air")
                
            {   
                cm.m_currentlySelectedCards.Add(cm.m_airCard);
    
            }
            else if (gameObject.tag == "earth")
                
            {   
                cm.m_currentlySelectedCards.Add(cm.m_earthCard);
    
            }
            else if (gameObject.tag == "energy")
                
            {   
                cm.m_currentlySelectedCards.Add(cm.m_energyCard);
    
            } 
        }
       
        
	}
    
    public void OnTriggerExit(Collider trigger)
    {
        GameObject card = trigger.gameObject;
        CardManager cm = card.GetComponent<CardManager>();
        
            if (gameObject.tag == "water")
                
            {   
                cm.m_currentlySelectedCards.Remove(cm.m_waterCard);
            
            }
            else if (gameObject.tag == "fire")
                
            {   
                cm.m_currentlySelectedCards.Remove(cm.m_fireCard);
    
            }
            else if (gameObject.tag == "air")
                
            {   
                cm.m_currentlySelectedCards.Remove(cm.m_airCard);
    
            }
            else if (gameObject.tag == "earth")
                
            {   
                cm.m_currentlySelectedCards.Remove(cm.m_earthCard);
    
            }
            else if (gameObject.tag == "energy")
                
            {   
                cm.m_currentlySelectedCards.Remove(cm.m_energyCard);
    
            } 
   
	}
    
}
