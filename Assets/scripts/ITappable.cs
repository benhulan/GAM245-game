using UnityEngine;
using System.Collections;

/// <summary>Declaring a new interface called ITappable
/// This guarantees the presence of 1 or more functions on anything
/// that conforms to this interface
/// </summary>
public interface ITappable
{
/// <summary>
/// Called when this object is tapped by the user
///</summary>
void OnTap(Vector3 initialPosition);

}
