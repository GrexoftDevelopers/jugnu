using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class Star : MonoBehaviour {
    Vector3 cameposition;
    Camera cam;
    float height;
    float width;
    GameObject star;



    // Use this for initialization
    void Start () {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        //transform.position = new Vector3(-(cameposition.x + (width / 2)), cameposition.y, 0);

      

    }
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(transform.position, Camera.main.transform.position) > width)
        {
            GameObject star = (GameObject)Instantiate(Resources.Load("star_prefab"));

            star.transform.position = new Vector3((cameposition.x + (width / 2) + Random.Range(1, 2)), Random.Range(2, -2), 0);
            Destroy(gameObject);
        }


        cameposition = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
       // Debug.Log(cameposition);
        //Debug.Log(transform.position.x);

      

        //Vector3 playerPosition = player.transform.position;
        //if (playerPosition.x > transform.position.x) {
        //    Debug.Log("star left");
        //}

    }
}
