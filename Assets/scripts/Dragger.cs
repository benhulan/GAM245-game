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
       Debug.Log(startPosition); 
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
    /*
    public void OnTriggerEnter(Collider trigger)
    {
        //this.GetComponent<Renderer>().enabled = false;
        // string spellCardToShow = gameObject.name;
        Collider trigger = 
       Debug.Log("Hello from OnTriggerEnter");
        //this.GameObject.name;
           
        //Debug.Log(spellCardToShow);
       
        switch (spellCardToShow)
            {
            case "energy":
                GameObject energy = GameObject.FindWithTag("energy");
                // Debug.Log(energy.tag);
                energy.GetComponent<Renderer>().enabled = true;
                break;
            case "earth":
                GameObject earth = GameObject.FindWithTag("earth");
                // Debug.Log(earth.tag);
                earth.GetComponent<Renderer>().enabled = true;
                break;
            case "air":
                GameObject air = GameObject.FindWithTag("air");
                // Debug.Log(air.tag);
                air.GetComponent<Renderer>().enabled = true;
                break;
            case "water":
                GameObject water = GameObject.FindWithTag("water");
                // Debug.Log(water.tag);
                water.GetComponent<Renderer>().enabled = true;
                break;
            case "fire":
                GameObject fire = GameObject.FindWithTag("fire");
                // Debug.Log(fire.tag);
                fire.GetComponent<Renderer>().enabled = true;
                break;
                
            case "energy1":
                GameObject energy1 = GameObject.FindWithTag("energy1");
                // Debug.Log(energy1.tag);
                energy1.GetComponent<Renderer>().enabled = true;
                break;
            case "earth1":
                GameObject earth1 = GameObject.FindWithTag("earth1");
                // Debug.Log(earth1.tag);
                earth1.GetComponent<Renderer>().enabled = true;
                break;
            case "air1":
                GameObject air1 = GameObject.FindWithTag("air1");
                // Debug.Log(air1.tag);
                air1.GetComponent<Renderer>().enabled = true;
                break;
            case "water1":
                GameObject water1 = GameObject.FindWithTag("water1");
                // Debug.Log(water1.tag);
                water1.GetComponent<Renderer>().enabled = true;
                break;
            case "fire1":
                GameObject fire1 = GameObject.FindWithTag("fire1");
                // Debug.Log(fire1.tag);
                fire1.GetComponent<Renderer>().enabled = true;
                break;
                
            default:
            Debug.Log("Hello");
                //this.GetComponent<Renderer>().enabled = false;
                break;
            } 
        }    */
        
    }

