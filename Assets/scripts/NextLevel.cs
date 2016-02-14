using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	public string sceneToLoad = null;
    //public static void LoadScene(int sceneBuildIndex, SceneManagement.LoadSceneMode mode = LoadSceneMode.Single);
	public void _NextLevelButton()
	{

		Debug.Log ("Clicked the button");
		//loads the level indicated in the variable after clicking on the button
		SceneManager.LoadScene(sceneToLoad);
	}

}
