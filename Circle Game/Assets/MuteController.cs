using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MuteController : MonoBehaviour {
	[SerializeField]
	Sprite muteImage;
	[SerializeField]
	Sprite unmuteImage;

	[SerializeField]
	Image image;
	SoundController sound;
	void Start() {
		sound = GameObject.FindGameObjectWithTag ("fxController").GetComponent<SoundController> ();
		int mute = PlayerPrefs.GetInt(Helpers.MUTE_KEY);
		if(mute == 0)
		{
			image.sprite = unmuteImage;
		}
		else
		{
			image.sprite = muteImage;

		}
	}



	public void MuteClicked() {

		int mute = PlayerPrefs.GetInt(Helpers.MUTE_KEY);
		if(mute == 1)
		{
			AudioListener.volume = 1.0F;
			PlayerPrefs.SetInt(Helpers.MUTE_KEY, 0);
			image.sprite = unmuteImage;
		}
		else
		{
			AudioListener.volume = 0F;
			PlayerPrefs.SetInt(Helpers.MUTE_KEY, 1);
			image.sprite = muteImage;

		}
		sound.click ();
	}
}
