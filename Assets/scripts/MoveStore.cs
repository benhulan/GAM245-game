using UnityEngine;
using System.Collections;


public class MoveStore : MonoBehaviour
{
    bool storeIsMoving = false;
    float timer = 0;
    Vector3 start;
    Vector3 end;
    
    private InputManager im;
    public RectTransform rtStore;

    // Use this for initialization
    void Start ()
    {
        rtStore = GameObject.FindWithTag("store").GetComponent<RectTransform>();
        im = GameObject.Find("inputManager").GetComponent<InputManager>();
    }
    
    void Update (){

        if(storeIsMoving == true)
        {
            timer += Time.deltaTime;

            rtStore.anchoredPosition = Vector3.Lerp(start, end, timer);

            if(timer > 1)
            {
                storeIsMoving = false;
            }
        }
    }
    // Update is called once per frame
 
    public void _MoveStoreleft ()
    {
        
        storeIsMoving = true;

        start = rtStore.anchoredPosition;
        end = start;
        end.x += rtStore.rect.width;
    
      
    }
    
     public void _MoveStoreRight ()
    {

            storeIsMoving = true;

            start = rtStore.anchoredPosition;
            end = start;
            end.x -= rtStore.rect.width;
   

      
    }

}
