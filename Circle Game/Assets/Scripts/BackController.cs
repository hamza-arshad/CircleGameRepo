using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackController : MonoBehaviour {
    [SerializeField]
    bool isQuit;
    [SerializeField]
    int destScene;
	
	void Start () {
	
	}
	
	
    public void LoadScene(int index) {

        SceneManager.LoadScene(index);

    }
    

	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

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
