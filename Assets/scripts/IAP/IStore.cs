using UnityEngine;
using System.Collections;

/// <summary>
/// A store plugin interface.
/// </summary>
public interface IStore
{
    /// <summary>
    /// Sets up the plugin as necessary.
    /// </summary>
    void Init();

    /// <summary>
    /// Performs a purchase attempt for the Bomb item.
    /// </summary>
    void AttemptToPurchaseWater();

    /// <summary>
    /// Performs a purchase attempt for the MegaBomb item.
    /// </summary>
    void AttemptToPurchaseAir();
    
    void AttemptToPurchaseEarth();
    
    void AttemptToPurchaseEnergy();
    
    void AttemptToPurchaseFire();
    
    
}
