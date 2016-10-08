using UnityEngine;
using admob;

public class MobileAdsManager : MonoBehaviour {

	static int count = 0;
    static bool isInit = false;
	// Use this for initialization
	void Start () {
        if (!isInit)
        {
            InitInterstitial();
            GameEventManager.GameOver += showInterstitial;
        }
	}

	// Update is called once per frame
	void Update () {

	}

	public static void showInterstitial()
	{
        count++;
		if(count%5 == 0)
		{
            Debug.Log("Not good");
            if (Admob.Instance().isInterstitialReady())
            {
                Admob.Instance().showInterstitial();
                Admob.Instance().loadInterstitial();
            }
            else
            {
                Admob.Instance().loadInterstitial();
                count--;

            }
        }
	}

	private void InitInterstitial()
	{
		#if UNITY_ANDROID
		    string adUnitId = "ca-app-pub-2451592142781660/4705472337";
#elif UNITY_IPHONE
		    string adUnitId = "ca-app-pub-2451592142781660/9135671935";
#else
		    string adUnitId = "unexpected_platform";
#endif

        Admob.Instance().initAdmob("", adUnitId);
        Admob.Instance().loadInterstitial();
        isInit = true;
    }
}
