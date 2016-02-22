using UnityEngine;
using System.Collections;

public interface IDraggable 
{
    /// <summary>
    /// called when a touch moves across this object
    /// </summary>
    /// <param name="worldPosition">The position the touch occurred in world space</param>
    /// <param name="dragVelocity">The speed and direction of the touch</param>
    void OnDrag(Vector3 worldPosition, Vector2 dragVelocity);
}
