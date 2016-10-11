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
    SpriteRenderer filledRenderer;
    SpriteRenderer dottedRenderer;
   
    private bool done;
    bool pressed;
    bool flag;
    float speed = 0;
    float time;
	bool dying = false;
    
	bool diedRight = true;
	float timeSinceDyingBegin = 0.0f;
	int blinks = 0;
	void Awake () {
        pressed = false;
        flag = false;
        dying = false;
        time = 1/DyingSpeed;
        dottedCircle.SetActive(true);
        plus.SetActive(true);
		dottedRenderer = dottedCircle.GetComponent<SpriteRenderer>();
		filledRenderer = filledCircle.GetComponent<SpriteRenderer>();
		dottedRenderer.color = new Color(255,255,255,255);
		filledRenderer.color = new Color(0, 0, 0, 1);
        game = GameObject.Find("GameController");
        controller = game.GetComponent<GameController>();
        
	}
	void StartDie() {
		dying = true;
		plus.SetActive(false);
		minus.SetActive(false);
		timeSinceDyingBegin = 0;
		if (diedRight) {
			// Put it above next circle
			dottedCircle.SetActive(false);
			filledRenderer.sortingOrder = 1;
			controller.Done (true);
		} else {
			dottedRenderer.color = new Color (0, 255, 0, 1);
		}
	}
	void DestroyEvil() {
		timeSinceDyingBegin += Time.deltaTime;
		int totalBlinks = 10;
		float blinkTime = Helpers.TIME_TO_DIE / totalBlinks;
		if (blinks > totalBlinks) {
			controller.Done (false);
			Destroy (gameObject);
			return;
		}
		if (timeSinceDyingBegin > blinkTime) {
			timeSinceDyingBegin = 0;
			blinks++;
			dottedCircle.SetActive (!dottedCircle.activeSelf);
		}

	}
    void DestroySweet()
    {
	
		Color c = filledRenderer.color;
        c = Color.Lerp(c, new Color(c.r, c.g, c.b, c.a - 1), Time.deltaTime / time);
        if (c.a <= 0)
        {
            Destroy(this.gameObject);
            return;     
        }
		filledRenderer.color = c;
       
    }
	
	// Update is called once per frame
	void Update () {
		
		if (dying) {
			if (diedRight)
				DestroySweet ();
			else
				DestroyEvil ();
			return;
		}
        if (pressed)
        {
            if(plus.activeSelf == true)
                filledCircle.transform.localScale = Vector3.Lerp(filledCircle.transform.localScale, new Vector3(filledCircle.transform.localScale.x + 1, filledCircle.transform.localScale.y + 1, 1), Time.deltaTime * speed);
            else
                filledCircle.transform.localScale = Vector3.Lerp(filledCircle.transform.localScale, new Vector3(filledCircle.transform.localScale.x - 1, filledCircle.transform.localScale.y - 1, 1), Time.deltaTime * speed);
            flag = true; 

			float fx = filledCircle.transform.localScale.x;
			if (fx > 5 || (fx < 0.1f && minus.activeSelf))
				pressed = false;
        }
        if(!pressed && flag)
        {
			float fx = filledCircle.transform.localScale.x;
			float dx = dottedCircle.transform.localScale.x;
			Debug.Log ("Filled: " + fx + ", Required: " + dx);
			// Gets the Width of Dots
			float per = Helpers.DOTS_WIDTH_PERCENT*dx;// (1/dx) * 0.055F;

			Debug.Log("Dots Width: " + per);
			// Adds tolerance level
			per += Helpers.CIRCLE_ACCEPTED_DIFFERENCE ;

			Debug.Log("Total Tolerance" + per);


			
            float minX = dx - per;
            float maxX = dx + per;

            if(fx>=minX && fx<= maxX)
            {
                
                
				filledRenderer.color = new Color(0f, 128f, 0f, 1f);
                done = true;
                
            }
            else
            {
                
				filledRenderer.color = new Color(1f, 0f, 0f, 1f);
                done = false;
                //controller.GameOver();
            }


            flag = false;
			diedRight = done; 
			StartDie ();

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
