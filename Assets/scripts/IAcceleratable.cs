using UnityEngine;
using System.Collections;

public interface IAcceleratable
{
    void OnAccelerometerUpdate(Vector3 deltaRotation);

    //void OnAccelerometerUpdate(Quaternion currentGyroscopeReading);
}
