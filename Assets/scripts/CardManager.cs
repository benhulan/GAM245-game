using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;


public class CardManager : MonoBehaviour {
    
    [SerializeField] public GameObject m_waterCard = null;
    [SerializeField] public GameObject m_fireCard = null;
    [SerializeField] public GameObject m_airCard = null;
    [SerializeField] public GameObject m_energyCard = null;
    [SerializeField] public GameObject m_earthCard = null;


    public CardMatch[] m_possibleMatches2 = null;
    
    public int pointsAwarded = 0;
    
    public bool hintTapped = false;
   
    
    //string m_resultingCard = gameObject.name;

    /// <summary>
    /// The cards that are currently on the pile.
    /// </summary>
    public List<GameObject> m_currentlySelectedCards = new List<GameObject>();
    
    private void Awake(){
        
        DontDestroyOnLoad(this.gameObject);
    }

    public int GetCardCount()
    {
        return m_currentlySelectedCards.Count;
    }
    /// <summary>
    /// Checks for debug input commands.
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CheckMatches2();
            Debug.Log("CheckMatches");
            
        }
    }
    
    //-------------------------
    /// <summary>
    /// Adds a card to the pile of currently selected cards.
    /// </summary>
    /// <param name="card">The card to add to the pile.</param>
    //-------------------------
    
    public void AddToPile(GameObject card)
    {
       // Debug.Log(card);
        if(m_currentlySelectedCards.Count >= 2)
        {
            // already full
            Debug.Log("Already full.");
            return;
        }

        m_currentlySelectedCards.Add(card);

        // TODO: Visually move the card.
    }

    /// <summary>
    /// Checks if two cards are on the pile.
    /// If so, checks if they are a valid match.
    /// If so, casts a spell.
    /// </summary>
   
    
    public void CheckMatches2()
    {
        for(int i = 0; i < m_possibleMatches2.Length; i++)
        {
            
            CardMatch match = m_possibleMatches2[i];
            
            bool success = true;
            
            for(int j = 0; j < match.requirements.Count; ++j)
            {
                GameObject card = match.requirements[j];
                
                if(m_currentlySelectedCards.Contains(card) == false)
                {
                    success = false;
                    Debug.Log("doesn't have two cards to match");
                    break;
                }
                
            }
            
            if (success == true)
            {
                hintTapped = true;
               
            //    Debug.Log(hintTapped);
                // Find the textbox game object
                // Get the Text component
                // Change the visible text
                GameObject.Find("Spell Name Text").GetComponent<Text>().text = match.spellName;
                GameObject.Find("Points Awarded For Spell").GetComponent<Text>().text = pointsAwarded.ToString();
                
                if(match.spellName == "Oxi-Bust"){
                    pointsAwarded = 2;   
                } else if(match.spellName == "Stormery"){
                    pointsAwarded = 5;   
                } else if(match.spellName == "Musty-Dusty"){
                    pointsAwarded = 6;   
                } else if(match.spellName == "Wicked-Steam"){
                    pointsAwarded = 3;   
                } else if(match.spellName == "Electro-Fusing"){
                    pointsAwarded = 1;   
                } else if(match.spellName == "Electro-Fire"){
                    pointsAwarded = 0;   
                } else if(match.spellName == "Blazy-Stones"){
                    pointsAwarded = 4;   
                } else if(match.spellName == "Muddus-Hummus"){
                    pointsAwarded = 7;   
                } else if(match.spellName == "Zip-Zing-Vim"){
                    pointsAwarded = 8;   
                } 
                GameObject.Find("Points Awarded For Spell").GetComponent<Text>().text = pointsAwarded.ToString();
                Debug.Log(pointsAwarded);
            }
        }
                    
    }
}
             