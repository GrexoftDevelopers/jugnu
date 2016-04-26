using UnityEngine;
using System.Collections;

public class playercontroll : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 move;
    bool didfly = false;
    public bool gotstar = false;
    public Sprite mysprite;
    
    

    // Use this for initialization
    void Start () {
        if (Screen.width == 480){
            transform.position = new Vector3(-5, 0, 0);
        }
       
        
        

                	
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
            gotstar = true;

            
        }
        if (col.gameObject.name == "Cube")
        {
            Destroy(gameObject);
            
            
        }
       
    }
    
}
