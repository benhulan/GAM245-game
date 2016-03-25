// Ignores all of this if "AMAZON_IAP_V1" isn't set up in Unity.
// To set this up, go to Edit > Project Settings > Player.
// It's under Other Settings > Scripting Define Symbols.

#if AMAZON_IAP_V1

using UnityEngine;
using System.Collections;
using System;

public class AmazonStoreV1 : MonoBehaviour, IStore 

{
    public void Init()
    {
        // Copy initialization steps from AmazonIAPEventListener and AmazonIAPUIManager

        DebugLogger.LogMessage("Attempting to initialize Amazon v1 store.");
    }
    
    public void AttemptToPurchaseWater() 
    {
        DebugLogger.LogMessage("Attempting to purchase Water from Amazon v1 store.");
    }
    //performs a purchase attempt for the air item
    public void AttemptToPurchaseAir() 
    {
        DebugLogger.LogMessage("Attempting to purchase Air from Amazon v1 store.");
    }
        //performs a purchase attempt for the water item
    public void AttemptToPurchaseFire()
     {
        DebugLogger.LogMessage("Attempting to purchase Fire from Amazon v1 store.");
    }
        
    //performs a purchase attempt for the air item
    public void AttemptToPurchaseEarth()
     {
        DebugLogger.LogMessage("Attempting to purchase Earth from Amazon v1 store.");
    }
    
        //performs a purchase attempt for the water item
    public void AttemptToPurchaseEnergy()
     {
        DebugLogger.LogMessage("Attempting to purchase Energy from Amazon v1 store.");
    }
}

#endif