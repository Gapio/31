using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuckenemyai : MonoBehaviour
{
    public Transform footBall;

    float speed = 6.9f;
    Vector3 footBallBack;

    const float EPSILON = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        footBallBack = (footBall.position - transform.position).normalized;

        if((transform.position - footBall.position).magnitude > EPSILON)
        {
            transform.Translate(footBallBack * Time.deltaTime * speed);
        }
    }
}
