using UnityEngine;
using System.Collections;

public class BGmusic : MonoBehaviour {

    GameObject player;
    public AudioClip music;

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().clip = music;
        GetComponent<AudioSource>().volume = 0.2f;
        
        GetComponent<AudioSource>().Play();




    }
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");

        if (!player.GetComponent<playercontroll>().getIsGame())
        {
            GetComponent<AudioSource>().Stop();
        }
        

    }
}
