using UnityEngine;
using System.Collections;

public class Directional : LightControll {
    public Light directional;

	// Use this for initialization
	void Start () {
        directional = GetComponent<Light>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (lt.range < 140)
        {
            directional.intensity -= 0.02f;
        }
        if(lt.range > 140)
        {
            directional.intensity = 4f;
        }
	
	}
}
