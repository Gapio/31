using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 2;

    public float bounceForce;
    public float ballbounceForce;


    public Vector3 velocity;

    private void Start()
    {
        velocity = transform.forward * force * Time.deltaTime;
        Debug.Log(velocity);
    }

    void Update()
    {
        LookAtVelocity();
        Move();

        transform.position += new Vector3(velocity.x, 0, velocity.z);
    }

    public virtual void Move()
    {

    }

    public virtual void LookAtVelocity()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("WeeWoo");
        if (collision.gameObject.tag == "Ball") collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.gameObject.transform.position - transform.position).normalized * ballbounceForce);
        if (collision.gameObject.tag == "HorizontalWall")
        {
            velocity = new Vector3(velocity.x, velocity.y, -velocity.z);

        }
        else if (collision.gameObject.tag == "VerticalWall")
        {
            velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
        }
    }

}
