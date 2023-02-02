using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField][Range(0,10)]
    int dmgAmount = 5;

    bool canAttack = true;
    Rigidbody2D rb;
    Vector3 vel = new Vector3(0, 0, 0);
    Vector3 playerPos;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerPos = GameObject.Find("Player").transform.position;
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //follow player if in the trigger area
        if (CompareTag("Player")) 
        {
            playerPos = GameObject.Find("Player").transform.position;
            //find the vector 
            //  get the coordinates of start point and subtract the coords of end point
            //velocityx = enemyspeed * direction of vectorx? * time.deltatime
            //velocityy = enemyspeed * direction of vectorx? * time.deltatime
            //velocity = new vector3(velx,vely,0);
            //logic is that we must find the direction of the vector on the X, and the Y and add those to a vector3
            //

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (CompareTag("Player"))
        {
            //once the player is hit
            //if the damage is 0, can never attack. can be collected
            //communicate with player interaction script,
            //allow player to collect a bunny if they have space,
            //otherwise gameobject cant be destroyed
            if (dmgAmount == 0)
            {
                //bunny interaction
                //if player can pick up object - do whatever
                /*
                if ()
                {

                }
                */
            }
            else
            {
                //communicate with player health, remove dmgamount. set canattack to false.
                //run coroutine to reset canattack
                canAttack = false;
                StartCoroutine(attackTimer());
            }

        }

        IEnumerator attackTimer()
        {
            yield return new WaitForSeconds(2f);
            canAttack = true;
        }
    }
}
