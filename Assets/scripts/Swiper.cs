using UnityEngine;
using System.Collections;
using System;

public class Swiper : MonoBehaviour, ISwipeable
{
    public string sceneToLoad = null;
    
    public void OnSwipe(Vector2 direction, float time, Vector3 worldPosition)
    {
       //SceneManager.LoadScene(sceneToLoad);
    }
    
    public void MoveTo(Vector3 worldPosition)
    {
        worldPosition.z = this.transform.position.z;
        this.transform.position = worldPosition;
    }
        
}

