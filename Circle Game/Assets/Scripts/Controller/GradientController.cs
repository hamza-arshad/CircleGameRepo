using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public struct GradientColors {
	[SerializeField] public Color Top;
	[SerializeField] public Color Bottom;
}

public class GradientController : MonoBehaviour {

	[SerializeField] List<GradientColors> Gradients;
	[SerializeField] List<GradientColors> DarkGradients;
	[SerializeField] float speed = 1;
	private Color topCurrentColor;
	private int ColorIndex;
	private Color bottomCurrentColor;

	bool isLight = true;

	// Use this for initialization
	void Start() {
		UpdateSize ();
		ColorIndex = Random.Range (0, Gradients.Count);
		isLight = true;
		topCurrentColor = Gradients [ColorIndex].Top;
		bottomCurrentColor = Gradients [ColorIndex].Bottom;
		ColorIndex = Random.Range (0, DarkGradients.Count);
		UpdateColors ();
	}

	float Distance(Color a, Color b) {
		Vector3 cA = new Vector3 (a.r, a.g, a.b);
		Vector3 cB = new Vector3 (b.r, b.g, b.b);
		return Vector3.Distance (cA, cB);
	}

	void UpdateSize() {
		Vector3 mySize = GetComponent<Renderer> ().bounds.size;
		float destHeight = Camera.main.orthographicSize * 2;
		float destWidth = Camera.main.aspect * destHeight;
		float scaleX = destWidth / mySize.x;
		float scaleY = destHeight / mySize.y;
		transform.localScale = new Vector3 (scaleX, scaleY, 1);

	}


	void UpdateColors () {
		MeshFilter thisMeshFilter = GetComponent<MeshFilter>();
		thisMeshFilter.mesh.colors = new Color[]{ topCurrentColor, bottomCurrentColor, topCurrentColor,bottomCurrentColor  };


	}

	public void Tick() {
		Color topDest = Gradients [ColorIndex].Top;
		Color bottomDest = Gradients [ColorIndex].Bottom;
		if (isLight) {
			topDest = DarkGradients [ColorIndex].Top;
			bottomDest = DarkGradients [ColorIndex].Bottom;
		}
		topCurrentColor = Color.Lerp (topCurrentColor, topDest, Time.deltaTime*speed);
		bottomCurrentColor = Color.Lerp (bottomCurrentColor, bottomDest, Time.deltaTime*speed);
		if (Distance (topDest, topCurrentColor) < 0.01f) {
			isLight = !isLight;
			if (!isLight) {
				ColorIndex = Random.Range (0, Gradients.Count);
			} else {
				ColorIndex = Random.Range (0, DarkGradients.Count);
			}

		}
		UpdateColors ();
	}

}
