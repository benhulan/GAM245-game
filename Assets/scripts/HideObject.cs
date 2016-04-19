using UnityEngine;
using System.Collections;

public class HideObject : MonoBehaviour {

	public float sec = 1f;
     void Start()
     {
         if (this.gameObject.activeInHierarchy)
             this.gameObject.SetActive(true);
 
         StartCoroutine(LateCall());
     }
 
     IEnumerator LateCall()
     {
 
         yield return new WaitForSeconds(sec);
 
         this.gameObject.SetActive(false);
         //Do Function here...
     }
}
