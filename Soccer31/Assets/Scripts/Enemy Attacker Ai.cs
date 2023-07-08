using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackerAi : MonoBehaviour
{
    public Transform footBall;
    public Transform footBallLeft;
    public Transform footBallRight;
    public Transform currenTarget;

    float speed = 6.9f;

    Vector3 lookDirection;

    const float EPSILON = 0.1f;

    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        lookDirection = (footBall.position - transform.position).normalized;

        if (footBall.position.x < 3.1)
        {
           /* if ((transform.position - footBall.position).magnitude > EPSILON)
            {
                transform.Translate(lookDirection * Time.deltaTime * speed);
            }*/

            if(footBall.position.z > 3.31f)
            {
                currenTarget = footBallRight;
                lookDirection = (footBallRight.position - transform.position).normalized;
                if ((transform.position - footBallRight.position).magnitude > EPSILON)
                {
                    transform.Translate(lookDirection * Time.deltaTime * speed);
                }
            }
            else if(footBall.position.z < 3.31f)
            {
                currenTarget = footBallLeft;
                lookDirection = (footBallLeft.position - transform.position).normalized;
                if ((transform.position - footBallLeft.position).magnitude > EPSILON)
                {
                    transform.Translate(lookDirection * Time.deltaTime * speed);
                }
            }
        }
        else if (0 > footBall.position.x && footBall.position.x < 3.31f)
        {
            if ((transform.position - footBall.position).magnitude > EPSILON)
            {
                transform.Translate(lookDirection * Time.deltaTime * speed/1.5f);
            }
        }
        else if (transform.position.x < 6.9f)
        {
            transform.Translate(speed / 1.31f * Time.deltaTime, 0, 0);
        }
    }
}
