﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControll : MonoBehaviour
{
    Transform playerTransform;
    float offsetx;

    List<GameObject> stars;
    List<GameObject> grounds;
    List<GameObject> trees;
    List<GameObject> fans;

    bool treeCreated;
    public float timeLapse;
    float treeGapIneterval;
    float fanGapInterval;
    bool fanCreated;
    //float camWidth, camHeight;

    const float PLAYER_VERTICAL_LIMIT = 14.0f;

    float groundTop, roofBottom;
    public int scorex = 0;
    GameObject playerx;
    GameObject Top;
    int cnt = 1;
    
    
    Vector3 toppos;
    Vector3 position;
    float startingPosition;
    


    // Use this for initialization
    void Start()
    {

        //Camera cam = Camera.main;
        //camHeight = 2f * cam.orthographicSize;
        //camWidth = camHeight * cam.aspect;

        groundTop = -PLAYER_VERTICAL_LIMIT / 2;
        //Debug.Log("GROUND TOP : " + groundTop);

        roofBottom = PLAYER_VERTICAL_LIMIT / 2;
        //Debug.Log("roof bottom : " + roofBottom);

        //Debug.Log("camera width : " + camWidth);
        //Debug.Log("camera height : " + camHeight);

        playerx = GameObject.FindGameObjectWithTag("Player");

        stars = new List<GameObject>();
        grounds = new List<GameObject>();
        trees = new List<GameObject>();
        playerTransform = playerx.transform;
        offsetx = transform.position.x - playerTransform.position.x;

        Top = GameObject.FindGameObjectWithTag("Top");
        toppos = Top.transform.position;
        toppos.y =  roofBottom  +  1.3f;
        Top.transform.position = toppos;
         
         

        GameObject[] initGrounds = GameObject.FindGameObjectsWithTag("ground");
        //Debug.Log("init grounds length : " + initGrounds.Length);
        //sorting the grounds on the basis of their x position
        GameObject temp;
        for (int i = 0; i < initGrounds.Length; i++)
        {
            for (int j = i + 1; j < initGrounds.Length; j++)
            {
                if (initGrounds[i].transform.position.x > initGrounds[j].transform.position.x)
                {
                    temp = initGrounds[i];
                    initGrounds[i] = initGrounds[j];
                    initGrounds[j] = temp;
                }
            }
            RectTransform groundRect = (RectTransform)initGrounds[i].transform;
            float groundHeight = groundRect.rect.height;
            //Debug.Log("ground height : " + groundHeight);
            Vector3 groundPosition = groundRect.position;
            float deltaY = groundTop - groundPosition.y - groundHeight;
            groundPosition.y += deltaY;
            //Debug.Log("ground top after render : " + (groundPosition.y + groundHeight / 2));
            initGrounds[i].transform.position = groundPosition;
            grounds.Add(initGrounds[i]);

            //Debug.Log("grounds [" + i + "] x : " + grounds[i].transform.position.x);


        }

        createStar(true);
        Vector3 position = playerTransform.position;
        float initialTreeX = -5;
        for (int i = 0; i < 5; i++)
        {
            position.x += initialTreeX + (treevelocity.TREE_GAP_X * i);
            createTree(position);
        }
        treeCreated = true;
        timeLapse = 0.0f;
        treeGapIneterval = treevelocity.TREE_GAP_X / playerx.GetComponent<playercontroll>().move.x;

        fanGapInterval = fanRotation.FAN_GAP_X / playerx.GetComponent<playercontroll>().move.x;
        fans = new List<GameObject>();
        fans.Add((GameObject)Instantiate(Resources.Load("fan_prefab")));


        startingPosition = transform.position.x;
    }

    public float getGroundTop()
    {
        return groundTop;
    }

    public float getRoofBottom()
    {
        return roofBottom;
    }

    // Update is called once per frame
    void Update()
    {

        timeLapse += Time.deltaTime;
        

        
        if (transform.position.x-toppos.x > 17.82f) {


            
            toppos.x += (transform.position.x- startingPosition);
            startingPosition = transform.position.x;
            
        }
        Top.transform.position = toppos;
        

        Vector3 pos = transform.position;
        pos.x = playerTransform.position.x + offsetx;
        transform.position = pos;

        if (grounds != null && grounds.Count > 4)
        {
            //Debug.Log("grounds count : " + grounds.Count);
            GameObject fifthLastGround = grounds[grounds.Count - 5];
            float fifthLastGroundX = fifthLastGround.transform.position.x;
           // Debug.Log("last ground x : " + fifthLastGroundX);
            //Debug.Log("camera x : " + pos.x);
            if (fifthLastGroundX < pos.x)
            {
                //Debug.Log("last ground started");
                //Debug.Log("last ground x : " + fifthLastGroundX);
                //Debug.Log("camera x : " + pos.x);
                float lastGroundWidth = ((RectTransform)fifthLastGround.transform).rect.width * 5;
                Vector3 newLastGroundPosition = fifthLastGround.transform.position;
                //Debug.Log("last ground width : " + lastGroundWidth);
                newLastGroundPosition.x = newLastGroundPosition.x + lastGroundWidth - 2;
                GameObject newLastGround = (GameObject)Instantiate(Resources.Load("Ground"));
                newLastGround.transform.position = newLastGroundPosition;
                grounds.Add(newLastGround);
                //Debug.Log(grounds.Count);
            }
            if (grounds.Count == 9)
            {
                GameObject tempObject = grounds[0];
                grounds.RemoveAt(0);
                Destroy(tempObject);
            }
        }
        //Debug.Log("time lapse : " + timeLapse + " & treegap interval : " + treeGapIneterval);
        if (timeLapse % treeGapIneterval < 0.1f)
        {
            if (!treeCreated)
            {
                Vector3 position = playerTransform.position;
                position.x += 34;
                createTree(position);
                treeCreated = true;
                //Debug.Log("tree created");
            }
        }
        else
        {
            treeCreated = false;
        }

        if (timeLapse % fanGapInterval < 0.1f)
        {
            if (fans.Count == 6)
            {
                GameObject tempFan = fans[0];
                fans.RemoveAt(0);
                Destroy(tempFan);
            }
            if (!fanCreated)
            {
                
                GameObject fan = (GameObject)Instantiate(Resources.Load("fan_prefab"));
                position = fan.transform.position;
                position.x += fanRotation.FAN_GAP_X*(cnt++);
                fan.transform.position = position;
                
                fans.Add(fan);

                //Debug.Log(fans.Count);

                fanCreated = true;
                scorex++;
            }
        }
        else
        {
            fanCreated = false;
        }


    }

    public void createStar(bool fullDistance)
    {
        
        GameObject star = (GameObject)Instantiate(Resources.Load("star_prefab"));

        
        Vector3 starPosition = star.transform.position;
        if (stars.Count == 2)
        {
            GameObject tmpStar = stars[0];
            stars.RemoveAt(0);
            Destroy(tmpStar);
        }
        stars.Add(star);

        if (fullDistance)
        {
            float lightDuration = LightControll.DURATION;
            float xVelocity = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroll>().move.x;
            float lightDistance = lightDuration * xVelocity;
            lightDistance = Random.Range(lightDistance / 2, lightDistance);
            float playerPosition = playerTransform.position.x;
            
            
            
           starPosition.x = lightDistance + playerPosition;

            

            starPosition.y = Random.Range(roofBottom, groundTop) ;
            
            star.transform.position = starPosition;
        }

      






    }

    private void createTree(Vector3 position)
    {
        GameObject tree = (GameObject)Instantiate(Resources.Load("tree"));
        position.y = tree.transform.position.y;
        tree.transform.position = position;
        if (trees.Count == 10)
        {
            GameObject tempTree = trees[0];
            trees.RemoveAt(0);
            Destroy(tempTree);
        }
        //Debug.Log(trees.Count);
        trees.Add(tree);

        
    }
    

}
