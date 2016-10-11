using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackController : MonoBehaviour {
    [SerializeField]
    bool isQuit;
    [SerializeField]
    int destScene;
	SoundController sound;
	void Start () {
		sound = GameObject.FindGameObjectWithTag ("fxController").GetComponent<SoundController> ();
	}
	
	
    public void LoadScene(int index) {

        SceneManager.LoadScene(index);

    }
    

	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
			sound.click ();

            if (isQuit)
            {
                Application.Quit();
            }
            else
            {
                LoadScene(destScene);
            }
                


        }
	
	}
}
