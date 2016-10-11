using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Soomla.Store;

public class SplashController : MonoBehaviour {
    float timmer;
	// Use this for initialization
	void Start () {
        timmer = 0;
		int mute = PlayerPrefs.GetInt(Helpers.MUTE_KEY, 0);
        if(mute == 1)
        {
            AudioListener.volume = 0F;
        }
        else
        {
            AudioListener.volume = 1.0F;
        }

    }
	
	// Update is called once per frame
	void Update () {

		timmer += Time.deltaTime;
        if (timmer >= 1.5f)
        {
			SceneManager.LoadSceneAsync(Helpers.HOME_SCENE_INDEX);
        }
	
	}
}
