using UnityEngine;
using System.Collections;

public class NextPage : MonoBehaviour
{
    bool isMoving = false;
    float timer = 0;
    Vector3 start;
    Vector3 end;
    
    private InputManager im;
    private RectTransform rt;
    public GameObject Cubo;
    
    public int pageLength = 800; 
    // Use this for initialization
    void Start ()
    {
        rt = GameObject.FindWithTag("page").GetComponent<RectTransform>();
        im = GameObject.Find("inputManager").GetComponent<InputManager>();
            Cubo = GameObject.Find("Cube");
    }
    
    void Update (){
         if(isMoving == true)
            {
                timer += Time.deltaTime;

                rt.anchoredPosition = Vector3.Lerp(start, end, timer);

                if(timer > 1)
                {
                    isMoving = false;
                }
                if(end.x <= -pageLength){
                    Debug.Log(Cubo);
                
                    Cubo.SetActive(false);
                }
            }
    }
    // Update is called once per frame
   public void _ChangePageleft ()
    {
        
        isMoving = true;

        start = rt.anchoredPosition;
        end = start;
        end.x += rt.rect.width;
    
      
    }
    
     public void _ChangePageRight ()
    {

            isMoving = true;

            start = rt.anchoredPosition;
            end = start;
            end.x -= rt.rect.width;
   

      
    }
}