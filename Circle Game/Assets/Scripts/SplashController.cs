using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Soomla.Store;

public class SplashController : MonoBehaviour {
    int timmer;
    int mute;
	// Use this for initialization
	void Start () {
        timmer = 0;
        mute = PlayerPrefs.GetInt(Helpers.MUTE_KEY, 0);
        if(mute == 1)
        {
            AudioListener.volume = 0F;
            PlayerPrefs.SetInt(Helpers.MUTE_KEY, 1);
        }
        else
        {
            AudioListener.volume = 1.0F;
            PlayerPrefs.SetInt(Helpers.MUTE_KEY, 0);
        }

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
