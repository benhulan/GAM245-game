using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    /// <summary>
    /// References to all IAcceleratable scripts in the scene.
    /// </summary>
    public static List<IAcceleratable> m_acceleratableObjects = new List<IAcceleratable>();

    /// <summary>
    /// References to all IPinchable scripts in the scene.
    /// </summary>
    //public static List<IPinchable> m_pinchableObjects = new List<IPinchable>();

    /// <summary>
    /// Reference to the Gyroscope readout from Unity.
    /// </summary>
    private Gyroscope m_gyro = null;

    /// <summary>
    /// How far apart fingers are during a pinch gesture.
    /// </summary>
    private float m_pinchDistanceLastFrame = 0;

    
    public CardManager atp;
    
    
    //variables to move through the space with using the accelerometer
    public float speed = 5.0F;
    Vector3 initialPosition;
    Vector3 deviceAcceleration;
    Vector3 deltaRotation = Vector3.zero;
    
    //finds a default camara to work with
    
    private void Reset()
    {
        //Camera.main returns a reference to any camera game Object with the "MainCamera" tag
        
        my_camera = Camera.main;
    
    }
    
    private void Start ()
    {
        //saves the initial position of the object
       initialPosition = this.transform.position;
       // Debug.Log(initialPosition.ToString());  // works!
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

 private void Awake()
    {
        // Find the Gyroscope.
        // m_gyro = Input.gyro;


        // Check if it was found.
        // if(m_gyro == null)
        // {
        //     // Error out if it wasn't found.
        //     DebugLogger.LogMessage("Gyroscope not detected.");
        // }
        // else
        // {
        //     // Enable it if it was found.
        //     DebugLogger.LogMessage("Gyroscope detected.");
        //     m_gyro.enabled = true;
        // }
    }
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

        if(Application.loadedLevelName == "card-finder") 
        {
            CheckAccelerometer();
        }

        // Android "BACK" button.
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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
                
                //Canvas canvasToMove = GetComponent<Canvas>;
                
                
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
                    // Debug.Log("Im dragging?"); 
                    if (draggableScript != null)
                    {
                        // Debug.Log("touch phase moved heard");
                        // call OnDrag() on whatever script we found
                        draggableScript.OnDrag(hitInfo.point, touchInfo.deltaPosition);     
                        //  Debug.Log("Im dragging");                   
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
                            //    Debug.Log("Im tapping"); 
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
                            // Search the object we hit for any script that implements / conforms to ISwipeable.
                            ISwipeable swipeScript = objectWeHit.GetComponent<ISwipeable>(); 
                            //  Debug.Log("Im swiping"); 
                            // NOTE: GetComponent() returns null if it doesn't find anything that matches.
                            // To account for this by checking if swipeScript is null before continuing.
                            if (swipeScript != null)
                            {
                                // Whatever script was found with ISwipeable, call the OnTap() function on it.
                                swipeScript.OnSwipe(touchInfo.deltaPosition, touchDuration, hitInfo.point);
                                //Debug.Log(touchInfo.deltaPosition.x);
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
        Vector3 neutralAcceleration =  new Vector3(0.0f, -0.6f, -0.7f);
        
        deviceAcceleration = Input.acceleration - neutralAcceleration;
               
        Vector3 deltaAcceleration = deviceAcceleration - initialPosition;// = m_gyro.rotationRate;
        
        deltaRotation.x = -deviceAcceleration.x;
        deltaRotation.y = -deviceAcceleration.y;
        
        deltaRotation *= Time.deltaTime;
        transform.Translate(deltaRotation * speed);
        
        // Debug.Log("device acceleration" + deviceAcceleration.ToString()); 
        
       // Debug.Log(deltaRotation.x.ToString());     
        
        //DebugLogger.LogMessage(Input.accelerationEventCount.ToString());
        for(int i = 0; i < m_acceleratableObjects.Count; ++i)
        {
            //DebugLogger.LogMessage("rotation: "+ deltaRotation.ToString());
            // Send the updated reading to every IAcceleratable.

            // Quaternion version.
            //m_acceleratableObjects[i].OnAccelerometerUpdate(currentGyroscopeAttitude);

            // Vector3 version.
            m_acceleratableObjects[i].OnAccelerometerUpdate(deltaRotation);
        }
        
        
    }
    
    private void OnGUI()
    {
        GUILayout.Label(m_currentAcceleration.ToString());
        //DebugLogger.LogMessage(m_currentAcceleration.ToString());
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