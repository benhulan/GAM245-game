using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Rotates this object to match the physical orientation of the phone.
/// </summary>
public class MatchPhoneOrientation : MonoBehaviour, IAcceleratable
{
    //[Range(0, 1)]
    //[SerializeField] private float m_smoothing = 1.0f;
    [SerializeField] private bool m_invertX = true;
    [SerializeField] private bool m_invertY = false;
    [SerializeField] private bool m_invertZ = false;
    
    // private Vector3 deltaRotation;
   

    /// <summary>
    /// Registers itself in the InputManager acceleratable list.
    /// </summary>
    private void Awake()
    {
        InputManager.m_acceleratableObjects.Add(this);
    }
    

    /// <summary>
    /// When the accelerometer reading is updated.
    /// </summary>
    public void OnAccelerometerUpdate(Vector3 deltaRotation)
    {
        Vector3 newValueRotation = Vector3.zero;
       
        
        // If necessary, invert the rotation value.
        if (m_invertX == true)
            deltaRotation.x *= -1;
        if (m_invertY == true)
            deltaRotation.y *= -1;
        if (m_invertZ == true)
            deltaRotation.z *= -1;
            
       // Debug.Log(deltaRotation.x);  // this works
       
       newValueRotation.x = deltaRotation.y*25;
       newValueRotation.y = deltaRotation.x*25;

        // Apply rotation.
        this.transform.Rotate(newValueRotation);
        
        //DebugLogger.LogMessage(deltaRotation.x.ToString() + deltaRotation.y.ToString() + deltaRotation.z.ToString());

       // #region Unused
        // Calculating a good value to pass into the Lerp function.
        // Lerp = interpolate.
        /*float minimumSmoothing = Time.deltaTime;
        float maximumSmoothing = 1;
        float smoothingRange = maximumSmoothing - minimumSmoothing;
        float smoothingCoefficient = minimumSmoothing + smoothingRange * (1 - m_smoothing);*/



        // Apply the actual rotation. (Accelerometer version)
        //this.transform.up = Vector3.Lerp(this.transform.up, // start point
        //    -currentAccelerometerReading,                   // end point
        //    smoothingCoefficient);                          // how far to go (0 == start point, 1 == end point)

        // This will jump the rotation all the way.
        //this.transform.up = -currentAccelerometerReading;

        // This doesn't work perfectly. It is off by about 90 degrees.
        //this.transform.rotation = currentGyroscopeReading;
       // #endregion
    }
}
