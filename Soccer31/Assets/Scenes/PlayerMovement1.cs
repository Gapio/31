using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : Player
{
    //ZigZag
    [SerializeField] float frequency = 10.0f; // Speed of sine movement
    //[SerializeField] float magnitude = 0.5f; //  Size of sine movement

    public override void Move()
    {
        //transform.position += Vector3.left * Time.deltaTime * speed;
        velocity = transform.right * Mathf.Sin(Time.time * frequency) * force * Time.deltaTime;
    }

    public override void LookAtVelocity()
    {
        //Vector3 target = new Vector3(velocity.x, 0.0f, velocity.z);
        //transform.LookAt(target + transform.position);
    }
}
