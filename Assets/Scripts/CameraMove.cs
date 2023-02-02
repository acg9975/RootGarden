using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 playerPos;
    Vector3 newPos;
    [SerializeField]
    [Range(10, 150f)]
    float maxSpeed = 10f;// 150 is a good speed for this
    [SerializeField]
    [Range(0.00001f, 1.5f)]//0.1 should be a good speed for this
    float smoothTime = .5f;
    Vector3 velocity = Vector3.zero;

    void Start()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //update player pos, then smoothdamp towards the position
        float playerPosX = GameObject.Find("Player").transform.position.x;
        float playerPosY = GameObject.Find("Player").transform.position.y;
        playerPos = new Vector3(playerPosX, playerPosY, transform.position.z);
        newPos = transform.position;
        Vector3 smoothedPos = Vector3.SmoothDamp(newPos, playerPos, ref velocity, smoothTime, maxSpeed);
        transform.position = smoothedPos;
    }
}
