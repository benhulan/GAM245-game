using UnityEngine;
using UnityEngine;
using System.Collections;

public class Slide : MonoBehaviour
{
   
    
    bool isMoving = false;
    float timer = 0;
    Vector3 start;
    Vector3 end;

    private RectTransform rt;

    // Use this for initialization
    void Start ()
    {
        //rt = this.GetComponent<RectTransform>();
        rt =  GameObject.FindWithTag("page").GetComponent<RectTransform>();

    }
    
    // Update is called once per frame
    void Update ()
    {

        
        if(Input.GetKeyDown(KeyCode.L))
        {
            isMoving = true;

            start = rt.anchoredPosition;
            end = start;
            end.x +=rt.rect.width;
        } else if(Input.GetKeyDown(KeyCode.R))
        {
            isMoving = true;

            start = rt.anchoredPosition;
            end = start;
            end.x -=rt.rect.width;
        }

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
}