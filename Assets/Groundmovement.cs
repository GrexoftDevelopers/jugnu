using UnityEngine;
using System.Collections;

public class Groundmovement : MonoBehaviour
{

    GameObject ground;

    Vector3 pos;
    

    // Use this for initialization
    void Start()
    {
        ground = GameObject.FindGameObjectWithTag("ground");
       
        pos = ground.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > 50)
        {
            pos.x += 9.6f - 9.6f*Time.deltaTime/2 ;
            
        }
       

        transform.position = pos;
        
    }

    
}