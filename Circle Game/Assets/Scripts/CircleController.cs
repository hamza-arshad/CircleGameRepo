using UnityEngine;
using System.Collections;



public class CircleController : MonoBehaviour {
    [SerializeField]
    GameObject filledCircle;
    [SerializeField]
    GameObject dottedCircle;

    [SerializeField]
    GameObject plus;
    
    [SerializeField]
    GameObject minus;
    [SerializeField]
    float DyingSpeed=1;

    GameObject game;
    GameController controller;
    SpriteRenderer renderer1;
    SpriteRenderer renderer2;
   
    private bool died;
    private bool done;
    bool pressed;
    bool flag;
    float speed = 0;
    float time;
    
    
	void Awake () {
        pressed = false;
        flag = false;
        died = false;
        time = 1/DyingSpeed;
        dottedCircle.SetActive(true);
        plus.SetActive(true);
        renderer1 = dottedCircle.GetComponent<SpriteRenderer>();
        renderer2 = filledCircle.GetComponent<SpriteRenderer>();
        renderer1.color = new Color(255,255,255,255);
        renderer2.color = new Color(0, 0, 0, 1);
        game = GameObject.Find("GameController");
        controller = game.GetComponent<GameController>();
        
	}

    void DestroySweet()
    {
        Color c = renderer2.color;
        c = Color.Lerp(c, new Color(c.r, c.g, c.b, c.a - 1), Time.deltaTime / time);
        if (c.a <= 0)
        {
            Destroy(this.gameObject);
            return;     
        }
        renderer2.color = c;
        dottedCircle.SetActive(false);
        plus.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (died)
        {
            DestroySweet();
            return;

        }
        if (pressed)
        {
            if(plus.activeSelf == true)
                filledCircle.transform.localScale = Vector3.Lerp(filledCircle.transform.localScale, new Vector3(filledCircle.transform.localScale.x + 1, filledCircle.transform.localScale.y + 1, 1), Time.deltaTime * speed);
            else
                filledCircle.transform.localScale = Vector3.Lerp(filledCircle.transform.localScale, new Vector3(filledCircle.transform.localScale.x - 1, filledCircle.transform.localScale.y - 1, 1), Time.deltaTime * speed);
            flag = true; 
        }
        if(!pressed && flag)
        {
            float fx = filledCircle.transform.localScale.x;
            float dx = dottedCircle.transform.localScale.x;
            float per = dx * 0.055F;
            float minX = dx - per;
            float maxX = dx + per;

            if(fx>=minX && fx<= maxX)
            {
                
                
                renderer2.color = new Color(0f, 128f, 0f, 1f);
                done = true;
                
            }
            else
            {
                
                renderer2.color = new Color(1f, 0f, 0f, 1f);
                done = false;
                controller.GameOver();
            }


            died = true;
            flag = false;
            controller.Done(done);

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

    public void SetFilledScale(float x, float y, float z)
    {

        filledCircle.transform.localScale = new Vector3(x, y, z);

    }
    public void isGrowingCircle(bool isGrowing)
    {
        plus.SetActive(isGrowing);
        minus.SetActive(!isGrowing);
    }
    

}
