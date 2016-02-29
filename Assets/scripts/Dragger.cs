using UnityEngine;
using System.Collections;
using System;

public class Dragger : MonoBehaviour, ITappable, IDraggable
{
    
    private Vector3 startPosition;
    
     public void Start()
    {
        //saves the initial position of the object
       startPosition = this.transform.position;
       //Debug.Log(startPosition); 
    }
    
    public void OnTap(Vector3 startPosition)
    {
       MoveBackTo(startPosition);
    }
    public void OnDrag(Vector3 worldPosition, Vector2 dragVelocity)
    {
        MoveTo(worldPosition);
    }
    public void MoveTo(Vector3 worldPosition)
    {
        worldPosition.z = this.transform.position.z;
        this.transform.position = worldPosition;
    }
    
    public void MoveBackTo(Vector3 startPosition)
    {
        //startPosition.z = this.transform.position.z;
        transform.position = this.startPosition;
    }

        
}

