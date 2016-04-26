using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {
    Transform playerTransform;
    float offsetx;
    Vector3 playerVelocity;
    const float TREE_UPPER_Z = 11;
    const float TREE_LOWER_Z = 7;
    

	// Use this for initialization
	void Start () {
        GameObject playerx = GameObject.FindGameObjectWithTag("Player");

        playerTransform = playerx.transform;
        offsetx = transform.position.x - playerTransform.position.x;

        playerVelocity = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroll>().move;

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
                Debug.Log("player velocity : " + playerVelocity);
                //Debug.Log("tree velocity of " + i + "th tree : " + xVelocity);
                treePosition.x += xVelocity * Time.deltaTime;
                trees[i].transform.position = treePosition;
            }
        }

	}
}
