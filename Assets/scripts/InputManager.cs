using UnityEngine;
//using System.Collections;

public class InputManager : MonoBehaviour {

	// Use camara to raycat from
	[SerializeField] private Camera my_camera = null;
   
    /// <summary>
    /// The maximum duration that we can consider a tap, in seconds.
    /// </summary>
    [SerializeField] private float m_maxTapDuration = 0.5f;

    /// <summary>
    /// The maximum amount of finger movement that we can consider a tap. (in pixels / second ?)
    /// </summary>
    [SerializeField] private float m_maxTapVelocity = 50;

    /// <summary>
    /// The time that the last touch began, in seconds.
    /// </summary>
    private float m_touchBeginTime = 0;

    /// <summary>
    /// Current accelerometer reading.
    /// </summary>
    private Vector3 m_currentAcceleration = Vector3.zero;
    
    public CardManager atp;
    
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
                // Debug.Log(objectWeHit);
                if (objectWeHit.tag == "circle")
                {
                    
                    atp.AddToPile(this.gameObject);
                    
                   // Debug.Log("we hit the circle");
                    // objectWeHit.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
                    // objectWeHit.SendMessage("AddToPile", SendMessageOptions.DontRequireReceiver);
                }
                
                // extract the touch phase 
                TouchPhase touchPhase = touchInfo.phase;
                
                switch (touchPhase)
                {
                    case TouchPhase.Began:
                        // Debug.Log("touch began");
                        m_touchBeginTime = Time.time;
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
                        // Debug.Log("Im dragging");                   
                    }
                    break;
                    
                    case TouchPhase.Stationary:
                    {
                        
                        break;
                    }
                    case TouchPhase.Ended:
                    
                    float timeNow = Time.time;
                    float touchDuration = timeNow - m_touchBeginTime;
                    // Check if the duration of the touch fell within acceptable range for a tap.
                    if (touchDuration <= m_maxTapDuration)
                    {
                        // Check if the movement of the touch fell within acceptable range for a tap.
                        if (touchInfo.deltaPosition.magnitude < m_maxTapVelocity)
                        {
                            // tap
                            // *** NICE AND CLEAN PROPER VERSION USING INTERFACES *** 

                            // Search the object we hit for any script that implements / conforms to ITappable.
                            ITappable tappableScript = objectWeHit.GetComponent<ITappable>();

                            // NOTE: GetComponent() returns null if it doesn't find anything that matches.
                            // To account for this by checking if tappableScript is null before continuing.
                            if (tappableScript != null)
                            {
                                // Whatever script was found with ITappable, call the OnTap() function on it.
                                tappableScript.OnTap(hitInfo.point);
                            }
                        }
                        else
                        {
                            // swipe with the same duration as a tap.
                            // Search the object we hit for any script that implements / conforms to ITappable.
                            ISwipeable swipeScript = objectWeHit.GetComponent<ISwipeable>();

                            // NOTE: GetComponent() returns null if it doesn't find anything that matches.
                            // To account for this by checking if tappableScript is null before continuing.
                            if (swipeScript != null)
                            {
                                // Whatever script was found with ITappable, call the OnTap() function on it.
                                swipeScript.OnSwipe(touchInfo.deltaPosition, touchDuration, hitInfo.point);
                            }
                        }
                    }

                    // Debug.Log("Touch phase ended");
                    break;
                } // ends switch
            } // ends if RaycastHit
    } // ends CheckTouch()    
    
    private void CheckAccelerometer()
    {
        m_currentAcceleration = Input.acceleration;
    }
    
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
                    //Debug.Log("tap heard");
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