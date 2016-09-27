using UnityEngine;
using System.Collections;

public class CircleController : MonoBehaviour {
    [SerializeField]
    GameObject filledCircle;
    [SerializeField]
    GameObject dottedCircle;

    
    GameObject game;
    GameController controller;
    SpriteRenderer renderer1;
    SpriteRenderer renderer2;

    bool pressed;
    bool flag;
    float speed = 1;

	void Start () {
        speed = Random.Range(0.5f, 2.0f);
        pressed = false;
        flag = false;
        renderer1 = dottedCircle.GetComponent<SpriteRenderer>();
        renderer2 = filledCircle.GetComponent<SpriteRenderer>();
        renderer1.color = new Color(255,255,255,255);
        renderer2.color = new Color(255, 255, 255, 255);
        game = GameObject.Find("GameController");
        controller = game.GetComponent<GameController>();

	}
	
	// Update is called once per frame
	void Update () {

        if (pressed)
        {

            filledCircle.transform.localScale = Vector3.Lerp(filledCircle.transform.localScale, new Vector3(filledCircle.transform.localScale.x + 1, filledCircle.transform.localScale.y + 1, 1), Time.deltaTime * speed);
            flag = true; 
        }
        if(!pressed && flag)
        {
            float fx = filledCircle.transform.localScale.x;
            float dx = dottedCircle.transform.localScale.x;
            float per = dx * 0.05F;
            float minX = dx - per;
            float maxX = dx + per;

            if(fx>=minX && fx<= maxX)
            {

                Debug.Log("U Won");
                SpriteRenderer renderer = filledCircle.GetComponent<SpriteRenderer>();
                renderer.color = new Color(0f, 128f, 0f, 1f);
                controller.destroy();
                flag = false;

            }
            else
            {
                Debug.Log("U lose");
            }
             


        }



	
	}

   public void SetPressed(bool f)
    {
        pressed = f;

    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }


    public void SetDottedScale(float x, float y, float z)
    {
        dottedCircle.transform.localScale = new Vector3(x, y, z);
    }

}
