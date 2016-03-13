using UnityEngine;
using System.Collections;
using System;

public class Dragger : MonoBehaviour, ITappable, IDraggable, ISwipeable
{
    
    private Vector3 startPosition;
    private CardManager cm;
    
     public void Start()
    {
        //saves the initial position of the object
       startPosition = this.transform.position;
       //cm = GameObject.Find("circle-dotted-line").GetComponent<CardManager>();
       //Debug.Log(startPosition); 
    }
    
    public void OnTap(Vector3 startPosition)
    {
       MoveBackTo(startPosition);
    }
    public void OnDrag(Vector3 worldPosition, Vector2 dragVelocity)
    {
      //  if(cm.m_possibleMatches2.Length > 1)
        //{
            MoveTo(worldPosition);
        //}
    }
    public void OnSwipe(Vector2 direction, float time, Vector3 worldPosition)
    {
      //  if(cm.m_possibleMatches2.Length > 1)
        //{
            MoveTo(worldPosition);
        //}
    }
    public void MoveTo(Vector3 worldPosition)
    {
        worldPosition.z = this.transform.position.z;
        this.transform.position = worldPosition;
    }
    
    public void MoveBackTo(Vector3 startPosition)
    {
        //this. will look for member variables
        //startPosition.z = this.transform.position.z;
        transform.position = this.startPosition;
    }

        
}

