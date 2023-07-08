using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : Player
{
    [SerializeField] float forwardforce;
    [SerializeField] float triangleSize;

    float currentTriangleTimer;


    public override void Move()
    {
        //transform.position += Vector3.left * Time.deltaTime * speed;

        currentTriangleTimer += Time.deltaTime;

        if (currentTriangleTimer >= triangleSize)
        {
            transform.Rotate(0, 120, 0);
            currentTriangleTimer = 0;
        }


        transform.position += transform.forward * force * Time.deltaTime;
        //velocity = ((transform.right * Mathf.Sin(Time.time * frequency) * force) + transform.forward * forwardforce) * Time.deltaTime;
    }
}
