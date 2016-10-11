using UnityEngine;
using System.Collections;

public class Directional : MonoBehaviour {
    public Light directionalLight;
    public Light pointLight;

    public float thresholdRange = 140.0f;
    public float lowerThreshold = 100.0f;
    const float MAX_INTENSITY = 4.0f;
    float rangeRange;

    // Use this for initialization
    void Start () {
        directionalLight = GetComponent<Light>();
        //Debug.Log("inside on start of dircetional light. this is : " + this.ToString());
        pointLight = GameObject.FindGameObjectWithTag("Jugnoo_light").GetComponent<Light>();
        rangeRange = thresholdRange - lowerThreshold;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("range is : " + pointLight.range);
        if (pointLight.range < thresholdRange && pointLight.range > lowerThreshold)
        {
            directionalLight.intensity = ((pointLight.range - lowerThreshold) / rangeRange) * MAX_INTENSITY;
        }
        else if (pointLight.range <= lowerThreshold) {
            directionalLight.intensity = 0.0f;
        }
        else
        {
            directionalLight.intensity = MAX_INTENSITY;
        }
	
	}
}
