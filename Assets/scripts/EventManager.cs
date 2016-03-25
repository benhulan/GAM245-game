using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void AnimalStartledBehaivor(GameObject startler);
    
    
    ///<summary>
    ///This will call one or more functions when starteled event occurs
    ///</summary>
    public static event AnimalStartledBehaivor e_OnStartled = null;
    
    
    //for testing putposes only 
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            BroadcastStartledEvent(this.gameObject);
        }
        
    } 
    
    ///<summary>
    ///Calls all delegates from e_OnStartled
    ///</summary>
    ///<param name="startler">Which game object did the startling</param>
    
    
    
     public static void BroadcastStartledEvent(GameObject startler)
     
     {
         //Check if there is at least one delegate attached to the event
       if(e_OnStartled != null)
        {
            //calls all the delagates from this event , telling them aho the startler is.
            e_OnStartled.Invoke(startler);
        }
    }
}
