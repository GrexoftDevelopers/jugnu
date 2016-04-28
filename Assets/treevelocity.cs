using UnityEngine;
using System.Collections;

public class treevelocity : MonoBehaviour {
    Vector3 velocity;
    public Vector3 movement;
    const float TREE_UPPER_Z = 5;
    const float TREE_LOWER_Z = 1;
    playercontroll playerControl;
    public const float TREE_GAP_X = 7;

    // Use this for initialization
    void Start () {

        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroll>();
        float z = Random.Range(TREE_LOWER_Z, TREE_UPPER_Z);
        //RectTransform rectTransform = (RectTransform)transform;
        float height = 32.49f;
        //Debug.Log("Height of tree : " + height);        
        Vector3 scale = transform.localScale;
        float newScale = (TREE_UPPER_Z + TREE_LOWER_Z - z) * 0.1f;
        //Debug.Log("new scale : " + newScale);
        scale.x = newScale;
        scale.y = newScale;
        scale.z = newScale;

        transform.localScale = scale;

        float deltaY = height * ((1 - newScale) / 2);
        //Debug.Log("delta y : " + deltaY);

        Vector3 position = transform.position;
        position.z = z;
        position.y -= deltaY;
        transform.position = position;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 playerVelocity = playerControl.getCurrentXVelocity();
        Vector3 treePosition = transform.position;
        float zDisplacementPercent = (treePosition.z - TREE_LOWER_Z) / (TREE_UPPER_Z - TREE_LOWER_Z);
        //Debug.Log("zDisplacementPercent : " + zDisplacementPercent);
        float xVelocity = zDisplacementPercent * playerVelocity.x * 0.5f;
        //Debug.Log("player velocity : " + playerVelocity);
        //Debug.Log("tree velocity of " + i + "th tree : " + xVelocity);
        treePosition.x += xVelocity * Time.deltaTime;
        transform.position = treePosition;
        //Debug.Log("z position : " + treePosition.z + " & zDisplacement : " + zDisplacementPercent + " & xVelocity : " + xVelocity);





    }
}
