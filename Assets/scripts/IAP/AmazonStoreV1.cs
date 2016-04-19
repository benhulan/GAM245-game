// Ignores all of this if "AMAZON_IAP_V1" isn't set up in Unity.
// To set this up, go to Edit > Project Settings > Player.
// It's under Other Settings > Scripting Define Symbols.

#if AMAZON_IAP_V1

using UnityEngine;
using System.Collections.Generic;
using System;

public class AmazonStoreV1 : MonoBehaviour, IStore 

{
    [SerializeField] private GameObject m_amazonIAPPrefab = null;

    [SerializeField] private string[] m_itemSkus = null;

   // [SerializeField] public List<GameObject> elements = null;

    [SerializeField] public GameObject m_waterCard = null;
    [SerializeField] public GameObject m_fireCard = null;
    [SerializeField] public GameObject m_airCard = null;
    [SerializeField] public GameObject m_energyCard = null;
    [SerializeField] public GameObject m_earthCard = null;
    [SerializeField] public GameObject m_steamCard = null;
    
    Vector3 waterPos = new Vector3(3.4f, -3.4f, 0); 
    Vector3 airPos = new Vector3(-3.4f, -3.4f, 0);
    Vector3 firePos = new Vector3(1.7f, -3.4f, 0);
    Vector3 energyPos = new Vector3(0.0f, -3.4f, 0);
    Vector3 earthPos = new Vector3(-1.7f, -3.4f, 0);

void Awake() {
        // DontDestroyOnLoad(m_waterCard);
        // DontDestroyOnLoad(m_airCard);
        // DontDestroyOnLoad(m_fireCard);
        // DontDestroyOnLoad(m_earthCard);
        // DontDestroyOnLoad(m_energyCard);
    }

void Reset()
{

     m_airCard = Resources.Load<GameObject>("air");
  
     m_waterCard = Resources.Load<GameObject>("water");

     m_fireCard = Resources.Load<GameObject>("fire");
     
     m_earthCard = Resources.Load<GameObject>("earth");

     m_energyCard = Resources.Load<GameObject>("energy");

}

    public void Init()
    {
        // Copy initialization steps from AmazonIAPEventListener and AmazonIAPUIManager

        //DebugLogger.LogMessage("Attempting to initialize Amazon v1 store.");
         // Creates a copy of the Amazon IAP required script.
        Instantiate<GameObject>(m_amazonIAPPrefab);

        // We now need to register functions for important store events.
        // 0. Find out what kind of function the event requires.
        // (You can do this by hovering your mouse over the name of the event.)
        // 1. declare a function that is compatible with the event.
        // 2. register that function with the event.
        AmazonIAPManager.itemDataRequestFailedEvent += OnItemDataRequestFailed;
        AmazonIAPManager.itemDataRequestFinishedEvent += OnItemDataRequestSucceeded;
        AmazonIAPManager.purchaseFailedEvent += OnPurchaseFailure;
        AmazonIAPManager.purchaseSuccessfulEvent += OnPurchaseSuccess;

        // TODO: register the rest of the events in AmazonIAPManager.

        // Send an item data request to the Amazon plugin.
        AmazonIAP.initiateItemDataRequest(m_itemSkus);
    
    }

     // Action == a void function with no parameters.

    /// <summary>
    /// Called when an item data request fails.
    /// </summary>
    private void OnItemDataRequestFailed()
    {
        DebugLogger.LogMessage("ERROR: Item data request has failed.");
    }

    // Action<X, Y> == a void function with two parameters: first of type X, second of type Y.

    /// <summary>
    /// Called when an item data request is successfully answered.
    /// </summary>
    private void OnItemDataRequestSucceeded(List<string> itemsThatCouldNotBeFound,
                                            List<AmazonItem> successfullyFoundItems)
    {
        DebugLogger.LogMessage("Item data request succeeded.");

        // Print out the items NOT found.
        for(int i = 0; i < itemsThatCouldNotBeFound.Count; ++i)
        {
            DebugLogger.LogMessage("Item NOT found: " + itemsThatCouldNotBeFound[i]);
        }
        
        //Generate Buttons
        

        // Print out the items that WERE found.
        for (int i = 0; i < successfullyFoundItems.Count; ++i)
        {
            DebugLogger.LogMessage("Item found: " + successfullyFoundItems[i].sku);
        }

        //generate buttons?
    }

    private void OnPurchaseFailure(string sku)
    {
        
       DebugLogger.LogMessage("ERROR: Couldn't purchase" + sku);
    }
    
    private void OnPurchaseSuccess(AmazonReceipt itemReceipt)
    {
        
       DebugLogger.LogMessage("Purchase sussessful: " + itemReceipt.sku);
       
       if(itemReceipt.sku == "com.amazon.buttonclicker.air-card")
       {
        // TODO: Have another script actually take care of what happens here.


                    Instantiate(m_airCard, airPos, Quaternion.identity);
                    DebugLogger.LogMessage("m_airCard");
       }
        else if(itemReceipt.sku == "com.amazon.buttonclicker.water-card")
        {
                  //  Instantiate<GameObject>(m_waterCard);
                    Instantiate(m_waterCard, waterPos, Quaternion.identity);
                    DebugLogger.LogMessage("Instatiate Water");
        }
        else if(itemReceipt.sku == "com.yesselhinojosa.buttonclicker.fire")
        {
                    Instantiate(m_fireCard, firePos, Quaternion.identity);
                    DebugLogger.LogMessage("Instatiate Fire");
        }
        else if(itemReceipt.sku == "com.yesselhinojosa.buttonclicker.earth")
        {
                    Instantiate(m_earthCard, earthPos, Quaternion.identity);
                    DebugLogger.LogMessage("Instatiate Earth");
        }
        else if(itemReceipt.sku == "com.yesselhinojosa.buttonclicker.energy")
        {
           
                    Instantiate(m_energyCard, energyPos, Quaternion.identity);
                    DebugLogger.LogMessage("Instatiate Energgy");
        }
    }

    
    public void AttemptToPurchaseWater() 
    {
        
        
        // DebugLogger.LogMessage("Attempting to purchase Water from Amazon v1 store.");
        AmazonIAP.initiatePurchaseRequest("com.amazon.buttonclicker.water-card");
        
    }
    //performs a purchase attempt for the air item
    public void AttemptToPurchaseAir() 
    {
        DebugLogger.LogMessage("Attempting to purchase Air from Amazon v1 store.");
        AmazonIAP.initiatePurchaseRequest("com.amazon.buttonclicker.air-card");
        Instantiate<GameObject>(m_airCard);
    }
        //performs a purchase attempt for the water item
    public void AttemptToPurchaseFire()
     {
        DebugLogger.LogMessage("Attempting to purchase Fire from Amazon v1 store.");
        AmazonIAP.initiatePurchaseRequest("com.yesselhinojosa.buttonclicker.fire");
        Instantiate<GameObject>(m_fireCard);
    }
        
    //performs a purchase attempt for the air item
    public void AttemptToPurchaseEarth()
     {
        DebugLogger.LogMessage("Attempting to purchase Earth from Amazon v1 store.");
        AmazonIAP.initiatePurchaseRequest("com.yesselhinojosa.buttonclicker.earth");
        Instantiate<GameObject>(m_earthCard);
    }
    
        //performs a purchase attempt for the water item
    public void AttemptToPurchaseEnergy()
     {
        DebugLogger.LogMessage("Attempting to purchase Energy from Amazon v1 store.");
        AmazonIAP.initiatePurchaseRequest("com.yesselhinojosa.buttonclicker.energy");
        Instantiate<GameObject>(m_energyCard);
    }
}



#endif