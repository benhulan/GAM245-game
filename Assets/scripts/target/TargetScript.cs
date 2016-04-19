using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class TargetScript: MonoBehaviour 
{

    [SerializeField] public GameObject m_waterCard;
    [SerializeField] public GameObject m_fireCard;
    [SerializeField] public GameObject m_airCard;
    [SerializeField] public GameObject m_energyCard;
    [SerializeField] public GameObject m_earthCard;
    
    public bool containsWater = true;
    public bool containsAir = true;
    public bool containsFire = true;
    public bool containsEarth = true;
    public bool containsEnergy = true;
	/// <summary>
    /// The cards that are currently on the pile.
    /// </summary>
    public List<GameObject> m_currentlySelectedCards = new List<GameObject>();
    public string loadedLevelName;
    
     private void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void Start(){
        if(Application.loadedLevelName == "card-finder"){
            m_waterCard = GameObject.FindWithTag("water1");
            m_airCard = GameObject.FindWithTag("air1");
            m_fireCard = GameObject.FindWithTag("fire1");
            m_energyCard = GameObject.FindWithTag("energy1");
            m_earthCard = GameObject.FindWithTag("earth1");
        }
        if(Application.loadedLevelName == "cast-spell"){
            m_waterCard = GameObject.Find("water");
            m_airCard = GameObject.Find("air");
            m_fireCard = GameObject.Find("fire");
            m_energyCard = GameObject.Find("energy");
            m_earthCard = GameObject.Find("earth");
         }
    }
    
    
    private void Update (){  
        // if(Application.loadedLevelName == "card-finder"){
        //     m_waterCard = GameObject.FindWithTag("water1");
        //     m_airCard = GameObject.FindWithTag("air1");
        //     m_fireCard = GameObject.FindWithTag("fire1");
        //     m_energyCard = GameObject.FindWithTag("energy1");
        //     m_earthCard = GameObject.FindWithTag("earth1");
        // }
    
        if(Application.loadedLevelName == "cast-spell"){
            // m_waterCard = GameObject.Find("water");
            // m_airCard = GameObject.Find("air");
            // m_fireCard = GameObject.Find("fire");
            // m_energyCard = GameObject.Find("energy");
            // m_earthCard = GameObject.Find("earth");
        
     
            // GameObject hasWater = GameObject.Find("water");
            // GameObject hasAir = GameObject.Find("air");
            // GameObject hasEarth = GameObject.Find("earth");
            // GameObject hasFire = GameObject.Find("fire");
            // GameObject hasEnergy = GameObject.Find("energy");

            if(!m_currentlySelectedCards.Contains(m_waterCard))
            {
                containsWater = false;
                m_waterCard.gameObject.SetActive(false);
                // hasWater.gameObject.SetActive(false);
            } 
            
            if(!m_currentlySelectedCards.Contains(m_airCard))
            {
                containsAir = false;
               m_airCard.gameObject.SetActive(false);
               // hasAir.gameObject.SetActive(false);
            } 
            
            if(!m_currentlySelectedCards.Contains(m_energyCard))
            {
                containsEnergy = false;
               m_energyCard.gameObject.SetActive(false);
               // hasEnergy.gameObject.SetActive(false);
            }
            
            if(!m_currentlySelectedCards.Contains(m_earthCard))
            {
                containsEarth = false;
               m_earthCard.gameObject.SetActive(false);
               // hasEarth.gameObject.SetActive(false);
            }
            
            if(!m_currentlySelectedCards.Contains(m_fireCard))
            {
                containsFire = false;
               m_fireCard.gameObject.SetActive(false);
               // hasFire.gameObject.SetActive(false);
            } 
            
            //target.gameObject.SetActive(false);
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

        m_currentlySelectedCards.Add(card);

    }
    
    void OnLoadingLevel()
    {
        transform.parent = null;
        DontDestroyOnLoad(this.gameObject);
    }
}
