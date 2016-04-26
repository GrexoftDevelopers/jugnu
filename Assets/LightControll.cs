using UnityEngine;
using System.Collections;

public class LightControll : MonoBehaviour
{
    public float duration = 3.0F;
    public float originalRange;
    public Light lt;
  

    

    void Start()
    {
        

        lt = GetComponent<Light>();
        originalRange = lt.spotAngle;
        
        
        

    }
    void Update()
        
    {
          if (GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroll>().gotstar == true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroll>().gotstar = false;

            lt.range = 160f;
        }
         
        
        
        lt.range -= 0.5f;

    }
}
