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
    float JumpResistance = 0;
    
    GameObject Canvas;
    GameObject scoretxt;
    GameObject highscoretxt;
    GameObject GamePlayed;
    int highScore;
    int gamecount;
    public AudioClip wing;
    public AudioClip hitSound;
    public AudioClip starColl;
    public Image prog;
    public Image starProg;




    

    bool isGame;
    
    

    Vector3 xVelocityCurrent, xPositionPrevious;
    



    // Use this for initialization
    void Start () {
        

        highScore = PlayerPrefs.GetInt("HighScore");
        gamecount = PlayerPrefs.GetInt("GameCount");
        
        

        

        ScoreValue = ScoreValue.GetComponent<Text>();

        Canvas = GameObject.FindGameObjectWithTag("PauseMenu");
        Canvas.GetComponent<Canvas>().enabled = false;
        scoretxt = GameObject.FindGameObjectWithTag("ScoreValue");
        highscoretxt = GameObject.FindGameObjectWithTag("HighScoreValue");
        GamePlayed = GameObject.FindGameObjectWithTag("GamePlayed");
        

        GetComponent<Animator>().speed = 1.5f;
        












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
        score = cameraControl.scorex-1;

        scoretxt.GetComponent<Text>().text = ScoreValue.text = score.ToString();
        highscoretxt.GetComponent<Text>().text = highScore.ToString();

        if (score>highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        prog.fillAmount =  (12-JumpResistance)/12;
        

        starProg.fillAmount = GetComponentInChildren<LightControll>().lt.range / 160;

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        
        

        if (didfly)
        {

            didfly = false;
            AudioSource.PlayClipAtPoint(wing, transform.position);
            if (velocity.y < 0)
            {
                velocity.y = 0;

            }

            //if (jump > 0)
            //{
            //    jump -= 2;
                

            //}

            
            


           
                velocity.y = 12 - JumpResistance;
           

            
            
            



        }


        //Debug.Log("velocity : " + velocity.y);





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
        

        //score++;

        

        //Debug.Log("xVelocity current : " + xVelocityCurrent);


    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Star")
        {
            AudioSource.PlayClipAtPoint(starColl, transform.position);
            Destroy(col.gameObject);
            lightControl.resetLight();
            cameraControl.createStar(true);
            
            score += 5;
            JumpResistance = 0;
            
            
        }
        if (col.gameObject.tag == "ground" || col.gameObject.tag == "Top")
        {
            
          
            isGame = false;
            gamecount++;
            PlayerPrefs.SetInt("GameCount", gamecount);
            GamePlayed.GetComponent<Text>().text = gamecount.ToString();
            gameOver();


        }
        if (col.gameObject.tag == "fan")
        {
            velocity.y = -40f;
            cameraControl.scorex -= 5;

            //JumpResistance += 1f;



            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            //fanRotation fan = gameObject.GetComponent<fanRotation>();
            //fan.GetComponent<AudioSource>().Play();
            
        }
       
    }    

    public bool getIsGame() {
        return isGame;
    }

    public Vector3 getCurrentXVelocity() {
        return xVelocityCurrent;
    }
    private void gameOver()
    {
        
        Time.timeScale = 0;
        
        //Destroy(gameObject);
        Canvas.GetComponent<Canvas>().enabled = true;
        

        }
        

    }
    

