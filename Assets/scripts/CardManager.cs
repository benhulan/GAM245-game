using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class CardManager : MonoBehaviour {

	[SerializeField] private GameObject m_waterCard = null;
    [SerializeField] private GameObject m_fireCard = null;
    [SerializeField] private GameObject m_airCard = null;
    [SerializeField] private GameObject m_energyCard = null;
    [SerializeField] private GameObject m_earthCard = null;

	[SerializeField] private CardMatchInfo[] m_possibleMatches = null;
    
    //string m_resultingCard = gameObject.name;

    /// <summary>
    /// The cards that are currently on the pile.
    /// </summary>
    private List<GameObject> m_currentlySelectedCards = new List<GameObject>();

    /// <summary>
    /// Checks for debug input commands.
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CheckMatches();
        }

        else if(Input.GetKeyDown(KeyCode.W))
        {
            AddToPile(m_waterCard);
           // CheckMatches();
        }

       else if (Input.GetKeyDown(KeyCode.F))
        {
            AddToPile(m_fireCard);
            // CheckMatches();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            AddToPile(m_airCard);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            AddToPile(m_earthCard);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            AddToPile(m_energyCard);
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
    public void CheckMatches()
    {
        if(m_currentlySelectedCards.Count != 2)
        {
            Debug.Log("There must be exactly two cards on the pile.");
            return;
        }
        else if(m_currentlySelectedCards.Count == 2) 
        {
                //Debug.Log("There are two cards on the pile.");
                
                for(int i = 0; i < m_possibleMatches.Length; ++i) 
                {
                   CardMatchInfo currentlyCheckingMatch = m_possibleMatches[i];
                   // Debug.Log(m_currentlySelectedCards[0], m_currentlySelectedCards[1]);
                   Debug.Log(currentlyCheckingMatch);
                   
                    if (m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_waterCard) && 
                       m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_fireCard))
                    {
                        Instantiate(currentlyCheckingMatch.m_resultingCard);
                        Debug.Log(currentlyCheckingMatch.m_resultingCard.name);
                        return;
                        
                    }
                    else if (m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_waterCard) && 
                        m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_airCard))
                    {
                        Instantiate(currentlyCheckingMatch.m_resultingCard);
                        Debug.Log(currentlyCheckingMatch.m_resultingCard.name);
                        return;

                    }

                    else if (m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_waterCard) && 
                        m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_earthCard))
                    {
                        Instantiate(currentlyCheckingMatch.m_resultingCard);
                        Debug.Log(currentlyCheckingMatch.m_resultingCard.name);
                        return;

                    }
                    else if (m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_waterCard) && 
                    m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_energyCard))
                    {
                        Instantiate(currentlyCheckingMatch.m_resultingCard);
                        Debug.Log(currentlyCheckingMatch.m_resultingCard.name);
                        return;

                    }
                    else if (m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_airCard) && 
                    m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_fireCard))
                    {
                        Instantiate(currentlyCheckingMatch.m_resultingCard);
                        Debug.Log(currentlyCheckingMatch.m_resultingCard.name);
                        return;

                    }
                    else if (m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_earthCard) && 
                    m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_fireCard))
                    {
                        Instantiate(currentlyCheckingMatch.m_resultingCard);
                        Debug.Log(currentlyCheckingMatch.m_resultingCard.name);
                        return;

                    }
                    else if (m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_energyCard) && 
                    m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_fireCard))
                    {
                        Instantiate(currentlyCheckingMatch.m_resultingCard);
                        Debug.Log(currentlyCheckingMatch.m_resultingCard.name);
                        return;

                    }
                    else if (m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_airCard) && 
                    m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_earthCard))
                    {
                        Instantiate(currentlyCheckingMatch.m_resultingCard);
                        Debug.Log(currentlyCheckingMatch.m_resultingCard.name);
                        return;

                    }
                    else if (m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_airCard) && 
                    m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_energyCard))
                    {
                        Instantiate(currentlyCheckingMatch.m_resultingCard);
                        Debug.Log(currentlyCheckingMatch.m_resultingCard.name);
                        return;

                    }
                    else if (m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_earthCard) && 
                    m_currentlySelectedCards.Contains(currentlyCheckingMatch.m_energyCard))
                    {
                        Instantiate(currentlyCheckingMatch.m_resultingCard);
                        Debug.Log(currentlyCheckingMatch.m_resultingCard.name);
                        return;

                    }
                }
           }
           //else {
                Debug.Log("No match, try again");
          // }
    }
                
}
             