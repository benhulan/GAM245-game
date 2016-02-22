using UnityEngine;
using System.Collections;
using System;

public class Dragger : MonoBehaviour, ITappable, IDraggable
{
    public void OnTap(Vector3 worldPosition)
    {
        MoveTo(worldPosition);
    }
    public void OnDrag(Vector3 worldPosition, Vector2 dragVelocity)
    {
        MoveTo(worldPosition);
    }
    public void MoveTo(Vector3 worldPosition)
    {
        worldPosition.z = this.transform.position.z;
        this.transform.position = worldPosition;
    }
}
