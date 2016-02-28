using UnityEngine;
using System.Collections;

public class DraggedCard : MonoBehaviour {


    public CardManager atp;
    
    
    public InputManager owh;
    
   
    
    public void Update()
    {
        // Debug.Log(owh.objectWeHit.name);
    }
   
    
	public void OnTriggerStay2D(Collider2D trigger)
    {
     
            Debug.Log("Am I getting called?"); 

        //when a collider passes a trigger that objcets gets added to the pile
        // atp.AddToPile(this.gameObject.name);
           
        
	}
    
    /*public void ReturnCard()
    {
        //if the are 2 cards in the pile already the cards gets back to its original position
        if(atp.GetCardCount() >= 2)
        {
            GameObject = startPosition;
        }
        
    }*/
    
}
