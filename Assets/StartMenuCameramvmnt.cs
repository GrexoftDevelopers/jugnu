using UnityEngine;
using System.Collections;

public class StartMenuCameramvmnt : MonoBehaviour {
    Vector3 movement;
    Vector3 position;

	// Use this for initialization
	void Start () {
        position = transform.position;
        Time.timeScale = 1;
	
	}
	
	// Update is called once per frame
	void Update () {
        position.x += 9.6f*Time.deltaTime;
        transform.position = position;
	
	}
}
