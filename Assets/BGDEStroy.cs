using UnityEngine;
using System.Collections;

public class BGDEStroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(transform.position, Camera.main.transform.position) > 50)
        {
            Destroy(gameObject);
        }

    }
}
