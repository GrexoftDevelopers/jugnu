using UnityEngine;
using System.Collections;

public class fanRotation : MonoBehaviour {

    public const float FAN_GAP_X = 16.0f;

	// Use this for initialization
	void Start () {
        CameraControll cameraControll = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControll>();
        RectTransform fanRect = (RectTransform)transform;
        float lowerY = cameraControll.getGroundTop() - (fanRect.rect.height / 2) + 0.5f;
        float upperY = cameraControll.getRoofBottom() - (fanRect.rect.height / 2) - 0.5f;

        float y = lowerY + Random.Range(0, upperY-lowerY);
        Vector3 position = fanRect.position;
        position.y = y;
        transform.position = position;

	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(0,0,-45) * Time.deltaTime*10);

    }
}
