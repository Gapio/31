using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackerAi : MonoBehaviour
{
    public Transform Football;

    float speed = 6.9f;

    Vector3 lookDirection;

    const float EPSILON = 0.1f;
        
    private void Update()
    {
        lookDirection = (Football.position - transform.position).normalized;

        //if other side of the pitch
        if (Football.position.z < 0)
        {
            if ((transform.position - Football.position).magnitude > EPSILON)
            {
                transform.Translate(lookDirection * Time.deltaTime * speed);
            }
        }
        else if (0 > Football.position.z || Football.position.z < 9.31f)
        {
            if ((transform.position - Football.position).magnitude > EPSILON)
            {
                transform.Translate(lookDirection * Time.deltaTime * speed/1.69f);
            }
        }
        else if (transform.position.z < 9.31f)
        {
            transform.Translate(0, 0, speed/1.31f * Time.deltaTime);
        }
    }
    //if (ball is on the players side)

}
