using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {
    GameObject scorebox;
    string score;
    
    
    

	// Use this for initialization
	void Start () {
        scorebox = GameObject.FindGameObjectWithTag("Score");
        score = scorebox.GetComponent<TextMesh>().text;        
	
	}
	
	// Update is called once per frame
	void Update () {
        int scr = 0;
        scr++;
        string txt = scr.ToString();
        score = txt;
        scr++;
        Debug.Log(scr);
	
	}
}
