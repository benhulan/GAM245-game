using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class CardMatch 
{
    public List<GameObject> requirements;
    public GameObject resultPrefab;
    
    // Simple
    public Text spellNameTextBox;
    public string spellName;
    
    public Text pointsAwardedForSpellTextBox;
    public int pointsAwardedForSpell;
    
    // Arty
    //public GameObject specificUIElement;
}



	