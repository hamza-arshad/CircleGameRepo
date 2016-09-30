using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class GameController : MonoBehaviour {
    bool isDown = false;
    [SerializeField]
    GameObject CirclePrefab;
    [SerializeField]
    Text scoreBox;


    private CircleController currntController;
    private GameObject obj;
    private SpriteRenderer sp;
    private float speed = 0;
    private float x, y;
    private float dx;
    private float dy;
    private float s;
    private int score;
    
    void Start () {
        
        Application.targetFrameRate = 60;
        create();
        scoreBox.text = "0";
        score = 0;
    }

   public void Done(bool done) {
        if (done) {
            this.score += 1;
            scoreBox.text = score.ToString();
            create();
        }
        else {
            GameOver();

        }
    }


    void GameOver() {
        
        

    }

    void create () {
        
        s = Random.Range(0.5F, 1F);
        dx = Random.Range(-1.5F, 1.5F);
        dy = Random.Range(-3F, 2F);
        obj = Instantiate(CirclePrefab);
        currntController = obj.GetComponent<CircleController>();
        obj.transform.position = new Vector3(dx, dy, 1);
        currntController.SetDottedScale(s,s,1);
        currntController.SetSpeed(s*1.5F);
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
