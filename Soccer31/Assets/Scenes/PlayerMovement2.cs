using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : Player
{
    [SerializeField] float forwardforce;

    public override void LookAtVelocity()
    {
        currentTriangleTimer += Time.deltaTime;

        if (currentTriangleTimer >= triangleSize)
        {
            transform.Rotate(0, 120, 0);
            currentTriangleTimer = 0;
        }


        //Vector3 target = new Vector3(velocity.x, 0.0f, velocity.z);
        //transform.LookAt(target + transform.position);
    }

    //[SerializeField] float frequency = 10.0f; // Speed of sine movement
    //[SerializeField] float magnitude = 0.5f; //  Size of sine movement
    [SerializeField] float triangleSize;

    float currentTriangleTimer;


    public override void Move()
    {
        //transform.position += Vector3.left * Time.deltaTime * speed;

        velocity = transform.forward * force * Time.deltaTime;
        //velocity = ((transform.right * Mathf.Sin(Time.time * frequency) * force) + transform.forward * forwardforce) * Time.deltaTime;
    }
}
