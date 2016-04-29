using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{
    Vector3 cameposition;
    Camera cam;
    float height;
    float width;


    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        transform.position = new Vector3(-(cameposition.x + (width / 2)), cameposition.y, 0);


    }

    // Update is called once per frame
    void Update()
    {
        cameposition = GameObject.FindGameObjectWithTag("MainCamera").transform.position;

    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Star")
        {
            GameObject star = (GameObject)Instantiate(Resources.Load("star_prefab"));

            star.transform.position = new Vector3((cameposition.x + (width / 2) + Random.Range(1, 2)), Random.Range(2, -2), 0);
            Destroy(coll.gameObject);


        }
        else
        {
            Destroy(coll.gameObject);
        }
    }
}
