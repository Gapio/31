using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackerAi : MonoBehaviour
{
    public Transform footBall;
    public Transform footBallLeft;
    public Transform footBallRight;
    public Transform currenTarget;
    readonly float speed = 6.9f;

    Vector3 lookDirection;

    const float EPSILON = 0.1f;

    //Rigidbody rb;


    /*private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }*/
    private void Update()
    {
        lookDirection = (footBall.position - transform.position).normalized;

        //if other side of the pitch
        if (footBall.position.z < 3.1)
        {
           /* if ((transform.position - footBall.position).magnitude > EPSILON)
            {
                transform.Translate(lookDirection * Time.deltaTime * speed);
            }*/

            if(footBall.position.x < 0)
            {
                currenTarget = footBallRight;
                lookDirection = (footBallRight.position - transform.position).normalized;
                if ((transform.position - footBallRight.position).magnitude > EPSILON)
                {
                    transform.Translate(lookDirection * Time.deltaTime * speed);
                }
                // transform.Translate(1.69f * Time.deltaTime,0f,0f);
                //GetComponent<ConstantForce>().force = new Vector3(6f,0f,0f);
            }
            else if(footBall.position.x > 0)
            {
                currenTarget = footBallLeft;
                lookDirection = (footBallLeft.position - transform.position).normalized;
                if ((transform.position - footBallLeft.position).magnitude > EPSILON)
                {
                    transform.Translate(lookDirection * Time.deltaTime * speed);
                }
                //transform.Translate(-1.69f * Time.deltaTime, 0f, 0f);
                // GetComponent<ConstantForce>().force = new Vector3(-6f, 0f, 0f);
            }
        }
        else if (3.1 > footBall.position.z || footBall.position.z < 9.31f)
        {
            if ((transform.position - footBall.position).magnitude > EPSILON)
            {
                transform.Translate(lookDirection * Time.deltaTime * speed/1.5f);
            }
        }
        else if (transform.position.z < 9.31f)
        {
            transform.Translate(0, 0, speed/1.31f * Time.deltaTime);
        }
    }
}
