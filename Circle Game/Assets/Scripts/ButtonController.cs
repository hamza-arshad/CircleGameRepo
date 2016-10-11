using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    GameObject game;
    GameController gameController;
    GameObject backController;
    BackController backScript;
    GameObject iapController;
    iAPHandler iapScript;
	SoundController sound;
    void Start() {
		sound = GameObject.FindGameObjectWithTag ("fxController").GetComponent<SoundController> ();
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

        backController = GameObject.Find("BackController");
        if (backController)
        {
            backScript = backController.GetComponent<BackController>();
        }

    }


    public void PlayButton() {
        SceneManager.LoadScene(Helpers.MAIN_SCENE_INDEX);
		sound.click ();

    }

    public void HomeButton() {

        SceneManager.LoadScene(Helpers.HOME_SCENE_INDEX);
		sound.click ();

    }

    public void CountinueButton() {
		sound.click ();

        bool flag = gameController.CheckCoins();
        if (flag)
            gameController.CountinueGame();
        else
            gameController.displayStorePanel(true);

        
        
    }

    public void BuyPackage1()
    {
		sound.click ();
        if(iapScript == null)
        {
            iapScript = GameObject.Find("IAPController").GetComponent<iAPHandler>();
        }
        iapScript.Package1Clicked();
    }

    public void BuyPackage2()
    {
		sound.click ();
        if (iapScript == null)
        {
            iapScript = GameObject.Find("IAPController").GetComponent<iAPHandler>();
        }
        iapScript.Package2Clicked();
    }

    public void BuyPackage3()
    {
		sound.click ();
        if (iapScript == null)
        {
            iapScript = GameObject.Find("IAPController").GetComponent<iAPHandler>();
        }
        iapScript.Package3Clicked();
    }

    public void BuyPackage4()
    {
		sound.click ();
        if (iapScript == null)
        {
            iapScript = GameObject.Find("IAPController").GetComponent<iAPHandler>();
        }
        iapScript.Package4Clicked();
    }

    public void StoreButton() {
		sound.click ();
        SceneManager.LoadScene(Helpers.STORE_SCENE_INDEX);

    }

    public void BackButtonStore() {
		sound.click ();
        backScript.LoadScene(1);

    }

    public void BackButtonStorePrefab()
    {
		sound.click ();
            gameController.displayStorePanel(false);
    }

    public void HelpButton()
    {
		sound.click ();
        SceneManager.LoadScene(Helpers.HELP_SCREEN_INDEX);

    }

    public void ShareButton()
    {
		sound.click ();
        Share.ShareMessage("MyScore", "http://playstore", "Hey check my best score on Circles. Can you do better?", Application.persistentDataPath + "/MyScore.png", "http://playstore");

    }

    public void MuteButton() {

        int mute = PlayerPrefs.GetInt(Helpers.MUTE_KEY);
        if(mute == 1)
        {
            AudioListener.volume = 1.0F;
            PlayerPrefs.SetInt(Helpers.MUTE_KEY, 0);
        }
        else
        {
            AudioListener.volume = 0F;
            PlayerPrefs.SetInt(Helpers.MUTE_KEY, 1);
        }
		sound.click ();


    }


}
