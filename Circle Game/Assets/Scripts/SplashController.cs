using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour {
    int timmer;
	// Use this for initialization
	void Start () {
        timmer = 0;
	}
	
	// Update is called once per frame
	void Update () {

        timmer++;
        if (timmer >= (3 * 60))
        {
            SceneManager.LoadScene(Helpers.HOME_SCENE_INDEX);
        }
	
	}
}
