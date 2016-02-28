using UnityEngine;
using System.Collections;

public interface ISwipeable
{
    //void OnSwipe(int direction);    // A swipe in only axis, either up or down.

   // void OnSwipe(Vector2 direction);    // A swipe in any direction.

    //void OnSwipe(Vector2 direction, Vector3 worldPosition);     // A swipe in a particular place in any direction.

    void OnSwipe(Vector2 direction, float time, Vector3 worldPosition);
}
