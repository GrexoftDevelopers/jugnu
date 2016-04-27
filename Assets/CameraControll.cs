using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControll : MonoBehaviour {
    Transform playerTransform;
    float offsetx;
    Vector3 playerVelocity;
    const float TREE_UPPER_Z = 5;
    const float TREE_LOWER_Z = 1;

    List<GameObject> stars;
    List<GameObject> grounds;

    
    

	// Use this for initialization
	void Start () {        

        GameObject playerx = GameObject.FindGameObjectWithTag("Player");

        stars = new List<GameObject>();
        grounds = new List<GameObject>();
        playerTransform = playerx.transform;
        offsetx = transform.position.x - playerTransform.position.x;

        playerVelocity = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroll>().move;
        GameObject[] initGrounds = GameObject.FindGameObjectsWithTag("ground");
        Debug.Log("init grounds length : " + initGrounds.Length);
        //sorting the grounds on the basis of their x position
        GameObject temp;
        for (int i = 0; i < initGrounds.Length; i++) {
            for (int j = i + 1; j < initGrounds.Length; j++) {
                if (initGrounds[i].transform.position.x > initGrounds[j].transform.position.x) {
                    temp = initGrounds[i];
                    initGrounds[i] = initGrounds[j];
                    initGrounds[j] = temp;
                }
            }            
            grounds.Add(initGrounds[i]);
            Debug.Log("grounds [" + i + "] x : " + grounds[i].transform.position.x);

            
        }

        float screenWidth = Screen.width;
        Debug.Log("screen width : " + screenWidth);

        createStar(true);

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x = playerTransform.position.x + offsetx;
        transform.position = pos;

        GameObject[] trees = GameObject.FindGameObjectsWithTag("BT");
        if (trees != null && trees.Length > 0) {
            //Debug.Log("number of trees : " + trees.Length);
            Vector3 treePosition;
            for (int i = 0; i < trees.Length; i++) {
                treePosition = trees[i].transform.position;
                float zDisplacementPercent = (treePosition.z - TREE_LOWER_Z) / (TREE_UPPER_Z - TREE_LOWER_Z);
                //Debug.Log("zDisplacementPercent : " + zDisplacementPercent);
                float xVelocity = zDisplacementPercent * playerVelocity.x * 0.5f;
                //Debug.Log("player velocity : " + playerVelocity);
                //Debug.Log("tree velocity of " + i + "th tree : " + xVelocity);
                treePosition.x += xVelocity * Time.deltaTime;
                trees[i].transform.position = treePosition;
            }
        }

        if (grounds != null && grounds.Count > 4) {
            Debug.Log("grounds count : " + grounds.Count);
            GameObject fifthLastGround = grounds[grounds.Count - 5];
            float fifthLastGroundX = fifthLastGround.transform.position.x;
            //Debug.Log("last ground x : " + fifthLastGroundX);
            //Debug.Log("camera x : " + pos.x);            
            if (fifthLastGroundX < pos.x) {
                //Debug.Log("last ground started");
                //Debug.Log("last ground x : " + fifthLastGroundX);
                //Debug.Log("camera x : " + pos.x);
                float lastGroundWidth = ((RectTransform)fifthLastGround.transform).rect.width * 5;
                Vector3 newLastGroundPosition = fifthLastGround.transform.position;
                //Debug.Log("last ground width : " + lastGroundWidth);
                newLastGroundPosition.x = newLastGroundPosition.x + lastGroundWidth - 2;
                GameObject newLastGround = Instantiate(fifthLastGround);
                newLastGround.transform.position = newLastGroundPosition;
                grounds.Add(newLastGround);
            }
            //if (grounds.Count == 8) {
            //    GameObject tempObject = grounds[0];
            //    grounds.RemoveAt(0);
            //    Destroy(tempObject);
            //}
        }


	}

    public void createStar(bool fullDistance)
    {
        GameObject star = (GameObject)Instantiate(Resources.Load("star_prefab"));

        Vector3 starPosition = star.transform.position;

        stars.Add(star);

        if (fullDistance) {
            float lightDuration = LightControll.DURATION;
            float xVelocity = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroll>().move.x;
            float lightDistance = lightDuration * xVelocity;
            lightDistance = Random.Range(lightDistance / 2, lightDistance);
            float playerPosition = playerTransform.position.x;
            starPosition.x = lightDistance + playerPosition;
            star.transform.position = starPosition;
        }

        
    }

}
