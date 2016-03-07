using UnityEngine;
using System.Collections;

public interface ISwipeable
{
    /// <summary>
    /// called when a swipe moves across this object
    /// </summary>
    /// <param name="worldPosition">The position the touch occurred in world space</param>
    /// <param name="direction">The speed and direction of the touch</param>
    /// <param name = "time"></param>
    //void OnSwipe(int direction);    // A swipe in only axis, either up or down.

   // void OnSwipe(Vector2 direction);    // A swipe in any direction.

    //void OnSwipe(Vector2 direction, Vector3 worldPosition);     // A swipe in a particular place in any direction.

    void OnSwipe(Vector2 direction, float time, Vector3 worldPosition);
}
