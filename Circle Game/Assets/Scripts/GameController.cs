using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    bool isDown = false;
    [SerializeField]
    GameObject CirclePrefab;
    private CircleController currntController;

    private float speed = 0;
    private float x, y;
    private float dx;
    private float dy;
    private GameObject obj;
    private SpriteRenderer sp;
    private float s;
    private bool destroyFlag;
    
    // Use this for initialization
    void Start () {
        
        Application.targetFrameRate = 60;
        create();
        sp = obj.GetComponentInChildren<SpriteRenderer>();
        destroyFlag = false;
    }

    

    public void destroy()
    {

        destroyFlag = true;

    }

    void create ()
    {
        speed = Random.Range(2.0F, 5.0F);
        s = Random.Range(0.5F, 1F);
        dx = Random.Range(-1.5F, 1.5F);
        dy = Random.Range(-4F, 4F);
        obj = Instantiate(CirclePrefab);
        currntController = obj.GetComponent<CircleController>();
        obj.transform.position = new Vector3(dx, dy, 1);
        currntController.SetDottedScale(s,s,1);
        currntController.SetSpeed(speed);



    }


    void Dop(float op)
    {
        sp.color = new Color(0f, 128f, 0f, op);

    }
	
	// Update is called once per frame
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


        if (destroyFlag)
        {
            float op = sp.color.a;
            if (op == 0)
            {
                Object.Destroy(obj);
                destroyFlag = false;
            }
            else
            {
                op--;
                Dop(op);
            }


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
