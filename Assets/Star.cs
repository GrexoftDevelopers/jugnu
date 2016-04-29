using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Star : MonoBehaviour {

    GameObject player;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {

        //Vector3 playerPosition = player.transform.position;
        //if (playerPosition.x > transform.position.x) {
        //    Debug.Log("star left");
        //}
	
	}
}
