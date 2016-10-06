using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    private int coins;
    [SerializeField]
    Text CoinsBox;
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        coins = PlayerPrefs.GetInt(Helpers.COINS_KEY, 0);
        CoinsBox.text = coins.ToString();

    }
}
