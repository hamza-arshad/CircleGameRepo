using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    GameObject game;
    GameController gameController;
    GameObject iapController;
    iAPHandler iapScript;
    void Start() {

        game = GameObject.Find("GameController");
        if (game)
        {
            gameController = game.GetComponent<GameController>();
        }

        iapController = GameObject.Find("IAPController");
        if (iapController)
        {
            iapScript = iapController.GetComponent<iAPHandler>();
        }

    }


    public void PlayButton() {
        SceneManager.LoadScene(Helpers.MAIN_SCENE_INDEX);

    }

    public void HomeButton() {

        SceneManager.LoadScene(Helpers.HOME_SCENE_INDEX);

    }

    public void CountinueButton() {


        bool flag = gameController.CountinueGame();

        if (!flag)
            SceneManager.LoadScene(Helpers.STORE_SCENE_INDEX);
    }

    public void BuyPackage1()
    {
        iapScript.Package1Clicked();
    }

    public void BuyPackage2()
    {
        iapScript.Package2Clicked();
    }

    public void BuyPackage3()
    {
        iapScript.Package3Clicked();
    }

    public void BuyPackage4()
    {
        iapScript.Package4Clicked();
    }



}
