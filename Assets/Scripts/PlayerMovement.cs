using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerSpeed = 3f;
    [SerializeField] [Range(1f, 6f)] float walkSpeedRaw = 3f;
    [SerializeField]
    float movementEffect = 1f;
    // Update is called once per frame
    void Update()
    {
        isSprinting();
        PlayerMove();
    }


    private void isSprinting()
    {
        playerSpeed = (Input.GetKey(KeyCode.LeftShift)) ? sprintSpeed() : walkSpeed();
    }
    private float walkSpeed()
    {
        return (walkSpeedRaw  * movementEffect)* Time.deltaTime;
    }

    private float sprintSpeed()
    {
        return (walkSpeedRaw * 2) * Time.deltaTime;
    }
    //walkspeedraw is normal walk speed
    //sprintspeed is twice the current walk cspeed
    //isSprinting checks to see if player is holding down shift
    //  if they are, it uses the sprintspeed
    //  if they are not, it uses the walkspeed
    //we use this so it is easier to affect speed in the future
    private void PlayerMove()
    {
        Vector3 newPos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            newPos.y += playerSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            newPos.y -= playerSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= playerSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            newPos.x += playerSpeed;
        }

        transform.position = newPos;
    }
}
