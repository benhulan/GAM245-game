using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DraggedCard : MonoBehaviour {


    public CardManager cm;
    
    void Start () {
		// Find the player.  Get the platformPlayer component.  Use that to look at the list inside of the player
		// GameObject card = GameObject.FindWithTag ("spellCard");
		// CardManager cm = card.GetComponent<CardManager>();
        // Debug.Log(card);
    }
		
    public void Update()
    {
        
        
    }
   
    
	// public void OnTriggerEnter(Collider trigger)
    // {
     
    //     if(trigger.tag != "circle" )
    //     {
    //         GameObject card = this.gameObject;
    //         ReturnCard(card);
    //     }
    //     //Debug.Log(trigger); 

    //     //when a collider passes a trigger that objcets gets added to the pile
    //     //cm.AddToPile(card);        
	// }
        
    //     public void ReturnCard(GameObject card)
    //     {
    //        // 
    //         CardManager cm = card.GetComponent<CardManager>();
            
    //         cm.AddToPile(card);
            
    //     }
    
}
