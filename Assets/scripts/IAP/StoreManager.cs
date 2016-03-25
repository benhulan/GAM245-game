using UnityEngine;
using System.Collections;

/// <summary>
/// Manages all interactions with the store, including using the right IAP plugin for the current platform.
/// </summary>
public class StoreManager : MonoBehaviour
{
    /// <summary>
    /// The version of the store to load when using the Amazon v1 plugin.
    /// </summary>
    [SerializeField] public GameObject m_amazonStoreV1Prefab = null;

    /// <summary>
    /// The store plugin that is being used.
    /// </summary>
    private IStore m_loadedStore = null;

    /// <summary>
    /// Automatically assigns default values to variables.
    /// </summary>
    private void Reset()
    {
        m_amazonStoreV1Prefab = Resources.Load<GameObject>("Amazon Store V1");
    }

    /// <summary>
    /// Find the right plugin prefab and initialize it.
    /// </summary>
    private void Awake()
    {
        // Checks if the plugin is already loaded.
        // Makes sure only one copy of the plugin ever loads.
        if (m_loadedStore != null)
        {
            DebugLogger.LogMessage("Store was already loaded, aborting load process.");
            return;
        }

        DebugLogger.LogMessage("Preparing to load desired plugin.");

#if AMAZON_IAP_V1
        DebugLogger.LogMessage("Loading Amazon V1 plugin.");
        GameObject storeClone = Instantiate(m_amazonStoreV1Prefab);
        m_loadedStore = storeClone.GetComponent<IStore>();

#elif AMAZON_IAP_V2
        // Amazon v2

#elif GOOGLE_PLAY
        // Google Play plugin

#endif
        
        if(m_loadedStore == null)
        {
            DebugLogger.LogMessage("ERROR: Store plugin did not load correctly.");
        }
        m_loadedStore.Init();
    }
    
    /// <summary>
    /// Initializes whichever store plugin is needed.
    /// </summary>
    public void OpenStorePage()
    {
        DebugLogger.LogMessage("Opening page!");
    }

    /// <summary>
    /// Deinitialize the store plugin in use.
    /// </summary>
    public void CloseStorePage()
    {

    }

    /// <summary>
    /// Attempts to purchase the standard Bomb.
    /// </summary>
    public void AttemptToPurchaseWater()
    {
        m_loadedStore.AttemptToPurchaseWater();
    }

    /// <summary>
    /// Called when a bomb is successfully purchased.
    /// </summary>
    public void OnPurchaseWater()
    {

    }

    /// <summary>
    /// Attempts to purchase the Mega bomb.
    /// </summary>
    public void AttemptToPurchaseAir()
    {
        m_loadedStore.AttemptToPurchaseAir();
    }

    /// <summary>
    /// Called when a Mega Bomb is successfully purchased.
    /// </summary>
    public void OnPurchaseAir()
    {

    }
    
        /// <summary>
    /// Attempts to purchase the Mega bomb.
    /// </summary>
    public void AttemptToPurchaseFire()
    {
        m_loadedStore.AttemptToPurchaseFire();
    }

    /// <summary>
    /// Called when a Mega Bomb is successfully purchased.
    /// </summary>
    public void OnPurchaseFire()
    {

    }
        /// <summary>
    /// Attempts to purchase the Mega bomb.
    /// </summary>
    public void AttemptToPurchaseEnergy()
    {
        m_loadedStore.AttemptToPurchaseEnergy();
    }

    /// <summary>
    /// Called when a Mega Bomb is successfully purchased.
    /// </summary>
    public void OnPurchaseEnergy()
    {

    }
        /// <summary>
    /// Attempts to purchase the Mega bomb.
    /// </summary>
    public void AttemptToPurchaseEarth()
    {
        m_loadedStore.AttemptToPurchaseEarth();
    }

    /// <summary>
    /// Called when a Mega Bomb is successfully purchased.
    /// </summary>
    public void OnPurchaseEarth()
    {

    }
}
