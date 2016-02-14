using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// Use camara to raycat from
	[SerializeField] private Camera my_camera = null;
    
    //finds a default camara to work with
    
    private void Reset()
    {
        //Camera.main returns a reference to any camera game Object with the "MainCamera" tag
        
        my_camera = Camera.main;
    }
    
    //checks mouse input
    
    private void Update()
    {
        //on touch / mouse click
        
        #if !UNITY_ANDROID
        
        //ON MOUSE CLICK
        if (Input.GetMouseButtonDown(0) == true)
        {
           
            //get the mouse position to world space
            Vector2 cursorPosition = Input.mousePosition;
            
            CheckInput(cursorPosition);
        }
        
        #else
        
        //Input.tuoch tells us how many fingers are touching the screen.
        if(Input.touchCount == 1)
        {
          //Gathering all touch input information
          Touch[] touches = Input.touches;
          
           // Extracting only the first touch.
            Touch firstTouch = touches[0];

            // Extract the position of that finger's touch.
            Vector2 touchPosition = firstTouch.position;

            // Check for input at this position.
            CheckInput(touchPosition);  
        }
        
        #endif
    }
    
    /// <summary>
    /// Sends the OnClick message to anything under the input position.
    /// </summary>
    /// <param name="inputPosition">It's the screen position to check for input and send a message to.</param>
    private void CheckInput(Vector2 inputPosition) 
        {
            //convert the mouse position to the world space
            Ray mouseCursorRay = my_camera.ScreenPointToRay(inputPosition);
            
            //declare a RaycastHit object to recieve our results
            RaycastHit hitInfo;
            
            //performs the actual raycast using the ray information and outputting hitInfo
            if (Physics.Raycast(mouseCursorRay, out hitInfo) == true)
            {
                
                //find out what we hit
                Collider objectWeHit = hitInfo.collider;
                
                // log the name of the object that was touched
                Debug.Log(objectWeHit.name);
                
                // if-else-ifs to check which object was clicked and act accordingly
                // use a switch statement for the same thing

                // attach a script to the touchable object and call out to it
                
                //calls the function hideCard() on every script on the object if it exists
                objectWeHit.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
            }
        }
    }    
        
            
           

