using UnityEngine;
//using System.Collections;

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
    
    // private void Update()
    // {
        //on touch / mouse click
        
//    #if !UNITY_ANDROID
//     private void Update()
//         {
//         //ON MOUSE CLICK
//         if (Input.GetMouseButtonDown(0) == true)
//         {
            
//             //get the mouse position to world space
//             Vector2 cursorPosition = Input.mousePosition;
//             // Debug.Log("I am a mouse click");
//             CheckInput(cursorPosition);
//         }
//        }
//         #else
    private void Update()
        {
            
        //Input.touch tells us how many fingers are touching the screen.
        if(Input.touchCount == 1)
        {
          //Gathering all touch input information
          Touch[] touches = Input.touches;
          
           // Extracting only the first touch.
            Touch firstTouch = touches[0];
            CheckTouch(firstTouch); 
        }
        
        }
       // #endif   
    
    private void CheckTouch(Touch touchInfo)
    {
            // Extract the position of that finger's touch.
            Vector2 touchPosition = touchInfo.position;

            // Convert the mouse position to world space
            Ray mouseCursorRay = my_camera.ScreenPointToRay(touchPosition);
            
            // Declare a RaycastHit object to recieve our results
            RaycastHit hitInfo;
            
            // perform the actual raycast
            if (Physics.Raycast(mouseCursorRay, out hitInfo) == true)
            {
                Collider objectWeHit = hitInfo.collider;
                Debug.Log(objectWeHit);
                if (objectWeHit.tag == "circle")
                {
                    Debug.Log("we hit the circle");
                    objectWeHit.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
                    objectWeHit.SendMessage("AddToPile", SendMessageOptions.DontRequireReceiver);
                }
                
                // extract the touch phase 
                TouchPhase touchPhase = touchInfo.phase;
                
                switch (touchPhase)
                {
                    case TouchPhase.Began:
                        // Debug.Log("touch began");
                        break;
                    case TouchPhase.Moved:
                    // search the object we hit for any script that implements IDraggable
                    IDraggable draggableScript = objectWeHit.GetComponent<IDraggable>();
                    // NOTE:  GetComponent returns null if no matches
                    if (draggableScript != null)
                    {
                        // Debug.Log("touch phase moved heard");
                        // call OnDrag() on whatever script we found
                        draggableScript.OnDrag(hitInfo.point, touchInfo.deltaPosition);     
                        Debug.Log("Im dragging");                   
                    }
                    break;
                    
                    case TouchPhase.Stationary:
                    {
                        // Debug.Log("touch phase stationary");
                        // search the object we hit for any script that implements ITappable
                        ITappable tappableScript = objectWeHit.GetComponent<ITappable>();
                        
                        if (tappableScript != null)
                        {
                            tappableScript.OnTap(hitInfo.point);
                            Debug.Log("Im tapping");  
                        }                    
                        break;
                    }
                    case TouchPhase.Ended:
                    // Debug.Log("Touch phase ended");
                    break;
                } // ends switch
            } // ends if RaycastHit
    } // ends CheckTouch()    
    
// #endif
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
                
                ITappable tappableScript = objectWeHit.GetComponent<ITappable>();
                if (tappableScript != null)
                {
                    tappableScript.OnTap(hitInfo.point);
                    Debug.Log("tap heard");
                }
                
                
                
                //  return objectWeHit.name;
                // log the name of the object that was touched
                // Debug.Log(objectWeHit.name);
                
                // if-else-ifs to check which object was clicked and act accordingly
                // use a switch statement for the same thing

                // attach a script to the touchable object and call out to it
                
                //calls the function hideCard() on every script on the object if it exists
                // objectWeHit.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
                // objectWeHit.SendMessage("AddToPile", SendMessageOptions.DontRequireReceiver);      
            }
        }
}