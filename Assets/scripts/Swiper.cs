using UnityEngine;
using System.Collections;
using System;

public class Swiper : MonoBehaviour, ISwipeable
{
    bool isMoving = false;
        float timer = 0;
        Vector3 start;
        Vector3 end;

        private RectTransform rt;

        // Use this for initialization
        void Start ()
        {
            rt = this.GetComponent<RectTransform>();

        }
        
        // Update is called once per frame
        void Update ()
        {
            
        } 
    
    // public void OnTap(Vector3 startPosition)
    public void OnSwipe(Vector2 direction, float time, Vector3 worldPosition)
    {
        // if(Input.GetKeyDown(KeyCode.L))
        //     {
                // isMoving = true;

                // start = rt.anchoredPosition;
                // end = start;
                // end.x +=rt.rect.width;
            // }

            if(isMoving == true)
            {
                timer += Time.deltaTime;

                rt.anchoredPosition = Vector3.Lerp(start, end, timer);

                if(timer > 1)
                {
                    isMoving = false;
                }
            }
    }
    
    /*
    Billy's Schedule!
    
    Tuesday 180 - RM 705 - noon to 5pm
    Thursday 180 - RM 705 - noon to 3pm
    Thursday 180 - RM 808 - 3.40pm to 5.30pm
    */
    
    // public void MoveTo(Vector3 worldPosition)
    // {
    //     worldPosition.z = this.transform.position.z;
    //     this.transform.position = worldPosition;
    // }
    
    // public void SwipeOutScreen(Vector3 outOfScreen)
    // {
        
    // }
        
}

