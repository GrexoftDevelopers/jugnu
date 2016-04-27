using UnityEngine;
using System.Collections;

public class LightControll : MonoBehaviour
{
    public const float DURATION = 3.0f;
    public Light lt;

    playercontroll player;

    float deltaRange;

    float timeLapse;

    float originalRange;
  

    

    void Start()
    {

        Debug.Log("inside on start of light control. this is : " + this.ToString());

        lt = GetComponent<Light>();

        originalRange = lt.range;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroll>();

        deltaRange = lt.range / DURATION;

        Debug.Log("delta range : " + deltaRange);

        timeLapse = 0;


    }
    void Update()
        
    {

        timeLapse += Time.deltaTime;
        //Debug.Log("timeLapse : " + timeLapse);
        if (player.getIsGame()) {

            if (player.gotstar)
            {
                timeLapse = 0;

                player.gotstar = false;

                lt.range = originalRange;
            }

            lt.range = originalRange - timeLapse * deltaRange;

        }

          

    }
}
