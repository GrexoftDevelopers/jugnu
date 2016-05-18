using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playercontroll : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 move;
    bool didfly = false;
    //public bool gotstar = false;
    public Sprite mysprite;
    LightControll lightControl;
    CameraControll cameraControl;
    public int score;
    public Text ScoreValue;
    public GameObject Canvas;
    public GameObject scoretxt;
    public int[] highScore;
    public Button but;
    

    bool isGame;

    Vector3 xVelocityCurrent, xPositionPrevious;



    // Use this for initialization
    void Start () {
        ScoreValue = ScoreValue.GetComponent<Text>();

        Canvas = GameObject.FindGameObjectWithTag("PauseMenu");
        Canvas.GetComponent<Canvas>().enabled = false;
        scoretxt = GameObject.FindGameObjectWithTag("ScoreValue");
        but = gameObject.GetComponent<Button>();
        

        
        
        
        
        
        
        
       
        isGame = true;

        
        
        lightControl = GameObject.FindGameObjectWithTag("Jugnoo_light").GetComponent<LightControll>();
        cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControll>();
        xPositionPrevious = Vector3.zero;
        xVelocityCurrent = Vector3.zero;


    }

    void Update ()
    {

       


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            didfly = true;          


        }
        if (Input.GetKeyDown(KeyCode.Escape) && isGame)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
               
                
            }
            else if (Time.timeScale == 0 && isGame)
            {
                Time.timeScale = 1;
               
            }

        }

        scoretxt.GetComponent<Text>().text = ScoreValue.text = score.ToString();
       




    }
	
	// Update is called once per frame
	void FixedUpdate () {        

        if (didfly)
        {
            didfly = false;
            if (velocity.y < 0)
            {
                velocity.y = 0;
            }
            
            velocity.y = 12;

        }



       

        
    

        float zAngle = 0;
        if (velocity.y < 0) {
            zAngle = Mathf.Lerp(0, -45, -velocity.y / 5f);
        }
        transform.rotation = Quaternion.Euler(0,0,zAngle);
            
            

        
        
        
        
        velocity += gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        transform.position += move * Time.deltaTime;


        
        if (velocity.y > 0)
        {
            GetComponent<Animator>().enabled = true;
            
        }
        else if (velocity.y < 0)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = mysprite;
        }

        Vector3 pos = transform.position;
        if (xPositionPrevious.Equals(Vector3.zero))
        {
            xVelocityCurrent = pos / Time.deltaTime;
        }
        else {
            xVelocityCurrent = (pos - xPositionPrevious) / Time.deltaTime;
        }
        xPositionPrevious = pos;

        score++;

        if (!isGame)
        {
            gameOver();
        }

        //Debug.Log("xVelocity current : " + xVelocityCurrent);


    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Star")
        {
            Destroy(col.gameObject);
            lightControl.resetLight();
            cameraControl.createStar(true);
            
            
        }
        if (col.gameObject.tag == "ground")
        {
            //Destroy(gameObject);
            isGame = false;
            
            
        }
        if (col.gameObject.tag == "fan")
        {
            velocity.y = -40f;
        }
       
    }    

    public bool getIsGame() {
        return isGame;
    }

    public Vector3 getCurrentXVelocity() {
        return xVelocityCurrent;
    }
    public void gameOver()
    {
        int i = 0;
        Time.timeScale = 0;
        Canvas.GetComponent<Canvas>().enabled = true;
        highScore[i] = score;
            i++;
        foreach (int a in highScore) {
            Debug.Log("/n"+a);

        }
        

    }
    
}
