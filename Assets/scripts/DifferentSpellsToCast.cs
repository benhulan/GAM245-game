using UnityEngine;
using UnityEngine.UI;
using System.Collections;
// using System;
using System.Collections.Generic;

public class DifferentSpellsToCast : MonoBehaviour {
    
    // [SerializeField] public Text m_growAtree = null;
    // [SerializeField] public Text m_invisibility = null;
    // [SerializeField] public Text m_speedyRun = null;
    // [SerializeField] public Text m_ironShield = null;
    // [SerializeField] public Text m_makeAdiamond = null;


    public PossibleSpells[] m_possibleSpellsToCast = null;
    
    public int pointsAwarded = 0;
    
    public float spellIndex;
       
    //string m_resultingCard = gameObject.name;

    /// <summary>
    /// The cards that are currently on the pile.
    /// </summary>
  //  public List<GameObject> m_currentSpellPoints = new List<GameObject>();
    
    private void Awake(){
        
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        spellIndex = Random.Range(0.0f, 1.0f);
        Debug.Log(spellIndex);

        if(spellIndex >= 0.0f && spellIndex <= 0.2f )
        {
            GameObject.Find("Spell To Defeat Name Text").GetComponent<Text>().text = "Grow a tree"; 
        } else if(spellIndex >= 0.2f && spellIndex <= 0.4f )
        {
            GameObject.Find("Spell To Defeat Name Text").GetComponent<Text>().text = "Create a rainbow"; 
        } else if(spellIndex >= 0.4f && spellIndex <= 0.6f )
        {
            GameObject.Find("Spell To Defeat Name Text").GetComponent<Text>().text = "Convert carbon to diamonds"; 
        }   else if(spellIndex >= 0.6f && spellIndex <= 0.8f )
        {
            GameObject.Find("Spell To Defeat Name Text").GetComponent<Text>().text = "Make yourself invisible"; 
        } else if(spellIndex >= 0.8f && spellIndex <= 1.0f )
        {
            GameObject.Find("Spell To Defeat Name Text").GetComponent<Text>().text = "Absorbe all light and create drarkness"; 
        }
           
    }

    // public int GetCardCount()
    // {
    //     return m_currentlySelectedCards.Count;
    // }
    /// <summary>
    /// Checks for debug input commands.
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            NewSpell();
            Debug.Log("New Spell Name");
            
        }
    }
    
    //-------------------------
    /// <summary>
    /// Adds a card to the pile of currently selected cards.
    /// </summary>
    /// <param name="card">The card to add to the pile.</param>
    //-------------------------
    
    // public void AddToPile(GameObject card)
    // {
    //    // Debug.Log(card);
    //     if(m_currentlySelectedCards.Count >= 2)
    //     {
    //         // already full
    //         Debug.Log("Already full.");
    //         return;
    //     }

    //     m_currentlySelectedCards.Add(card);

    //     // TODO: Visually move the card.
    // }

    /// <summary>
    /// Checks if two cards are on the pile.
    /// If so, checks if they are a valid match.
    /// If so, casts a spell.
    /// </summary>
   
    
    public void NewSpell()
    {
       
            
        // ++spellIndex;
        // for(int i = 0; i < m_possibleSpellsToCast.Length; i++)
        // {
            
        //    PossibleSpells[] newSpell = m_possibleSpellsToCast;
            
            // bool success = true;
    
            
          //  for(int j = 0; j < spellIndex; ++j)
            //{
               // Text newSpellToCast = m_possibleSpellsToCast.spellNameToDefeat[spellIndex];
                
                
            // }
            
            // if (success == true)
            // {
                // ++spellIndex;
               
            //    Debug.Log(hintTapped);
                // Find the textbox game object
                // Get the Text component
                // Change the visible text
                
                
                // switch(spellIndex)
                // {
                //     case 0: 
                //     GameObject.Find("Spell To Defeat Name Text").GetComponent<Text>().text = "Grow a tree"; 
                //     break;
                    
                //     case 1: 
                //     GameObject.Find("Spell To Defeat Name Text").GetComponent<Text>().text = "Grow a tree 2"; 
                //     break;
                    
                    // case 3: 
                    // GameObject.Find("Spell To Defeat Name Text").GetComponent<Text>().text = newSpell.spellNameToDefeat[2]; 
                    // break;
                    
                    // case 4: 
                    // GameObject.Find("Spell To Defeat Name Text").GetComponent<Text>().text = newSpell.spellNameToDefeat[3]; 
                    // break;
                    
                    // case 5: 
                    // GameObject.Find("Spell To Defeat Name Text").GetComponent<Text>().text = newSpell.spellNameToDefeat[4]; 
                    // break;
                    
                // } 
                // GameObject.Find("Spell To Defeat Name Text").GetComponent<Text>().text = newSpell.spellNameToDefeat;
                // GameObject.Find("Points Awarded For Spell Text Box").GetComponent<Text>().text = newSpell.pointsAwardedForSpell.ToString();
                
            //     if(match.spellName == "Oxi-Bust"){
            //         pointsAwarded = 2;   
            //     } else if(match.spellName == "Stormery"){
            //         pointsAwarded = 5;   
            //     } else if(match.spellName == "Musty-Dusty"){
            //         pointsAwarded = 6;   
            //     } else if(match.spellName == "Wicked-Steam"){
            //         pointsAwarded = 3;   
            //     } else if(match.spellName == "Electro-Fusing"){
            //         pointsAwarded = 1;   
            //     } else if(match.spellName == "Electro-Fire"){
            //         pointsAwarded = 0;   
            //     } else if(match.spellName == "Blazy-Stones"){
            //         pointsAwarded = 4;   
            //     } else if(match.spellName == "Muddus-Hummus"){
            //         pointsAwarded = 7;   
            //     } else if(match.spellName == "Zip-Zing-Vim"){
            //         pointsAwarded = 8;   
            //     } 
            //     GameObject.Find("Points Awarded For Spell").GetComponent<Text>().text = pointsAwarded.ToString();
            //     Debug.Log(pointsAwarded);
       }
                   
}
             