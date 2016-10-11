using UnityEngine;
using System.Collections;

public class fanRotation : MonoBehaviour {

    public const float FAN_GAP_X = 8.0f;
    //playercontroll posx;
    
    float y;
    int x;
    






    // Use this for initialization
    void Start () {

        int p = PlayerPrefs.GetInt("ypos");
        CameraControll cameraControll = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControll>();
        //posx = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroll>();
        RectTransform fanRect = (RectTransform)transform;
        float lowerY = cameraControll.getGroundTop() - (fanRect.rect.height / 2) + 1.5f;
        float upperY = cameraControll.getRoofBottom() - (fanRect.rect.height / 2) + 1.5f;
        
        float h = (upperY - lowerY);
        x = Random.Range(0 , 4);
        //Debug.Log("x : " + x);
        //Debug.Log("p : " + p);
        if (p == x)
        {
            if (x == 3) x = 0;
            else x++;
        }




        y = lowerY + (h / 3) * x;
        
        PlayerPrefs.SetInt("ypos", x);

 
        

        

        //float y = Random.Range(lowerY, upperY);
        Vector3 position = fanRect.position;
        position.y = y;
        
        

        
        
        transform.position = position;

        

        
        

	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(0,0,45) * Time.deltaTime*20);
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > 50)
        {
            Destroy(gameObject);
        }



        
        

    }
    
}
