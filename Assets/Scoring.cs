using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {
    GameObject scorebox = GameObject.FindGameObjectWithTag("Score");
    
    
    

	// Use this for initialization
	void Start () {
        string score = scorebox.GetComponent(TextMesh).text
        
	
	}
	
	// Update is called once per frame
	void Update () {
        int scr = 0;
        scr++;
        string txt = scr.ToString();
        score.text = txt;
        scr++;
        Debug.Log("scr");
	
	}
}
