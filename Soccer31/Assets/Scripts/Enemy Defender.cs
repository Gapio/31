using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefender : MonoBehaviour
{
    public Transform behindBall;
    readonly float speed = 6.9f;

    Vector3 lookDirection;

    const float EPSILON = 0.1f;

    private void Update()
    {
        lookDirection = (behindBall.position - transform.position).normalized;

        //if other side of the pitch
        if (behindBall.position.z > 9.31f)
        {
            if ((transform.position - behindBall.position).magnitude > EPSILON)
            {
                transform.Translate(lookDirection * Time.deltaTime * speed);
            }
        }
        else if (8.69f < behindBall.position.z && behindBall.position.z < 9.31f)
        {
            if ((transform.position - behindBall.position).magnitude > EPSILON)
            {
                transform.Translate(speed / 1.69f * Time.deltaTime * lookDirection);
            }
        }
        else if (transform.position.z < 22.31f)
        {
           transform.Translate(0, 0, (speed / 1.31f * Time.deltaTime));
        }
    }
}
