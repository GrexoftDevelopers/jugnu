using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class Star : MonoBehaviour {
    //Vector3 cameposition;
    Camera cam;
    float height;
    float width;
    GameObject star;
    
    Vector3 position;



    // Use this for initialization
    void Start () {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        //transform.position = new Vector3(-(cameposition.x + (width / 2)), cameposition.y, 0);

        position = transform.position;
        
        position.x -= transform.position.x % fanRotation.FAN_GAP_X + fanRotation.FAN_GAP_X / 2;
       
        transform.position = position;
       


    }
	
	// Update is called once per frame
	void Update () {

        

       // if (Vector3.Distance(transform.position, Camera.main.transform.position) > (width+LightControll.DURATION))
       if (transform.position.x < (Camera.main.transform.position.x - width/2))
        {
            Destroy(gameObject);
            //GameObject star = (GameObject)Instantiate(Resources.Load("star_prefab"));

            // star.transform.position = new Vector3((cameposition.x + (width / 2) + Random.Range(1, 2)), Random.Range(2, -2), 0);
            cam.GetComponent<CameraControll>().createStar(true);
            transform.position = new Vector3((Camera.main.transform.position.x + (width / 2) + Random.Range(1, 2)), Random.Range(2, -2), 0);


        }
        
        
        

        //cameposition = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        // Debug.Log(cameposition);
        //Debug.Log(transform.position.x);



            //Vector3 playerPosition = player.transform.position;
            //if (playerPosition.x > transform.position.x) {
            //    Debug.Log("star left");
            //}

    }
    //void OnTriggerEnter2D(Collider2D cl)
    //{
    //    if (cl.gameObject.tag == "fan")
    //    {

    //        Vector3 p = gameObject.transform.position;
    //        if (p.x >= cl.gameObject.transform.position.x) { p.x = cl.gameObject.transform.position.x + 1.45f; Debug.Log("left"); }
    //        else if (p.x < cl.gameObject.transform.position.x) { p.x = cl.gameObject.transform.position.x - 1.45f; Debug.Log("right"); }
    //        gameObject.transform.position = p;

    //    }
    //}
}
