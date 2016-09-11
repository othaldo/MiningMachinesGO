using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	public void LoadScene(string levelToLoad)
    {
        //Application.LoadLevel(level);
        SceneManager.LoadScene(levelToLoad);
    }
}
