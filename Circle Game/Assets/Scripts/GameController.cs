using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
    bool isDown = false;
    [SerializeField]
    GameObject CirclePrefab;
    [SerializeField]
    Text scoreBox;
    [SerializeField]
    Text textLog;

    private CircleController currntController;
    private GameObject obj;
    private SpriteRenderer sp;
    private float currentSpeed = 0.2F;
    private const int totalDrops = 10;
    private int dropCount = 0;
    private const float minSpeed = 0.4F;
    private const float maxSpeed = 2.5F;
     
    private float x, y;
    private float dx;
    private float dy;
    private float dottedScale;
    private int score;
    private float filledScale;
    
    void Start () {
        
        Application.targetFrameRate = 60;
        currentSpeed = minSpeed;
        int a = Random.Range(1, 3);
        if (a == 1)
            CreateGrowingCirlce();
        else if (a == 2)
            CreateDecreasingCircle();


        scoreBox.text = "0";
        score = 0;
    }
     void setSpeed()
    {
        textLog.text = currentSpeed+"";
        float increment = Random.Range(- 0.05f, 0.1f);
        currentSpeed += increment;
        dropCount++;
        if(dropCount > totalDrops)
        {
            Debug.Log("DROP");
            currentSpeed = Random.Range((minSpeed + currentSpeed) * 0.25f, (minSpeed + currentSpeed) * 0.75f);
             dropCount = 0;
            
        }
        if (currentSpeed > maxSpeed)
            currentSpeed = maxSpeed;
        if (currentSpeed < minSpeed)
            currentSpeed = minSpeed;

    }


   public void Done(bool done) {
        if (done) {
            this.score += 1;
            scoreBox.text = score.ToString();
            int a = Random.Range(1, 2);
            if (a == 1)
                CreateGrowingCirlce();
            else if (a == 2)
                CreateDecreasingCircle();

        }

        else {
            GameOver();

        }
    }


    public void GameOver() {
        SceneManager.LoadScene(0);
        

    }



    void CreateDecreasingCircle() {
        setSpeed();
        dottedScale = Random.Range(0.2F, 0.5F);
        filledScale = Random.Range(dottedScale + 0.15F, 1F);
        dx = Random.Range(-1F, 1F);
        dy = Random.Range(-2.5F, 1.3F);
        obj = Instantiate(CirclePrefab);
        currntController = obj.GetComponent<CircleController>();
        obj.transform.position = new Vector3(dx, dy, 1);
        currntController.SetDottedScale(dottedScale, dottedScale, 1);
        currntController.SetFilledScale(filledScale, filledScale, 1);
        currntController.SetSpeed(currentSpeed);

        currntController.isGrowingCircle(false);

    }

    void CreateGrowingCirlce () {
        setSpeed();
        dottedScale = Random.Range(0.5F, 1F);
        dx = Random.Range(-1F, 1F);
        dy = Random.Range(-2.5F, 1.3F);
        obj = Instantiate(CirclePrefab);
        currntController = obj.GetComponent<CircleController>();
        obj.transform.position = new Vector3(dx, dy, 1);
        currntController.SetDottedScale(dottedScale,dottedScale,1);
        currntController.SetSpeed(currentSpeed);
        currntController.isGrowingCircle(true);
    }

	void Update () {
	    if(Input.GetMouseButtonDown(0) && !isDown)
        {
            isDown = true;
            OnMouseDown();

        }
        if (Input.GetMouseButtonUp(0))
        {
            isDown = false;
            OnMouseUp();

        }
    }



    void OnMouseDown()
    {
        currntController.SetPressed(true);
    }


    void OnMouseUp()
    {
        currntController.SetPressed(false);
    }
}
