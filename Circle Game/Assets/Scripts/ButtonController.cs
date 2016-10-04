using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    GameObject game;
    GameController gameController;
   
    void Start() {

        game = GameObject.Find("GameController");
        if (game)
        {
            gameController = game.GetComponent<GameController>();
        }

    }


    public void PlayButton() {
        SceneManager.LoadScene(1);

    }

    public void HomeButton() {

        SceneManager.LoadScene(0);

    }

    public void CountinueButton() {


        bool flag = gameController.CountinueGame();

        if (!flag)
            Debug.Log("Insufficient Coins");
    }


}
