using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class CardManager : MonoBehaviour {


    public CardMatch[] m_possibleMatches2 = null;

    
    //string m_resultingCard = gameObject.name;

    /// <summary>
    /// The cards that are currently on the pile.
    /// </summary>
    public List<GameObject> m_currentlySelectedCards = new List<GameObject>();

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
        Debug.Log(card);
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
                    Debug.Log("hello");
                    break;
                }
                
            }
            
            if (success == true)
            {
                
                Instantiate(match.resultPrefab);
                Debug.Log(match.resultPrefab.name);
            }
        }
    }
                
}
             