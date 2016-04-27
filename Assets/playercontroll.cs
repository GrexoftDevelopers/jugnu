using UnityEngine;
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

    bool isGame;



    // Use this for initialization
    void Start () {

        isGame = true;

        if (Screen.width == 480){
            transform.position = new Vector3(-5, 0, 0);
        } 
        
        lightControl = GameObject.FindGameObjectWithTag("Jugnoo_light").GetComponent<LightControll>();
        cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControll>();


    }

    void Update ()
    {

        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            didfly = true;
            

        }

        

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        
       if (didfly == true)
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


    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Star")
        {
            Destroy(col.gameObject);
            lightControl.resetLight();
            cameraControl.createStar(true);
            
        }
        if (col.gameObject.name == "Cube")
        {
            //Destroy(gameObject);
            isGame = false;
            
        }
       
    }    

    public bool getIsGame() {
        return isGame;
    }
    
}
