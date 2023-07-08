using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefender : MonoBehaviour
{
    public Transform behindBall;

    float speed = 6.9f;

    Vector3 lookDirection;

    const float EPSILON = 0.1f;

    private void Update()
    {
        lookDirection = (behindBall.position - transform.position).normalized;

        //if other side of the pitch
        if (behindBall.position.x > 6.9f)
        {
            if ((transform.position - behindBall.position).magnitude > EPSILON)
            {
                transform.Translate(lookDirection * Time.deltaTime * speed);
            }
        }
        else if (3.1f < behindBall.position.x && behindBall.position.x < 6.9f)
        {
            if ((transform.position - behindBall.position).magnitude > EPSILON)
            {
                transform.Translate(lookDirection * Time.deltaTime * speed / 1.69f);
            }
        }
        else if (transform.position.z < 10f)
        {
           transform.Translate((speed / 1.31f * Time.deltaTime), 0, 0);
        }
    }
}
