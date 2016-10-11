using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
	[SerializeField]
	AudioClip clickSound;

	[SerializeField]
	AudioClip fillingSound;

	[SerializeField]
	AudioClip successFillingSound;

	[SerializeField]
	AudioClip failFillingSound;

	[SerializeField]
	AudioSource source;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		source.loop = false;
	}
	public void click() {
		source.clip = clickSound;
		source.Play ();
	}
	public void fillingStarted() {
		source.clip = fillingSound;
		source.Play ();
	}
	public void fillingFailed() {
		source.clip = failFillingSound;
		source.Play ();
	}
	public void fillingSucces() {
		source.clip = successFillingSound;
		source.Play ();
	}
	

}
