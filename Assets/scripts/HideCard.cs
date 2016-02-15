using UnityEngine;
using System.Collections;

public class HideCard : MonoBehaviour {
//hide the cards that have been clicked

//public GameObject energy;    

    private void OnClick()
    {
        this.GetComponent<Renderer>().enabled = false;
        string spellCardToShow = gameObject.name;
        
       
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
        }    
    
}
