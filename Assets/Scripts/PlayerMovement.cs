using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardForce = 2000.0f;
    public float sidewaysForce = 450.0f;

    private Rigidbody rb;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>() ?? throw new MissingComponentException("No Rigidbody on player !");
    }

    void FixedUpdate()
    {
        this.rb.AddForce(new Vector3(0f, 0f, this.forwardForce * Time.deltaTime));

        if (Input.GetKey(KeyCode.Q)) 
        {
            this.rb.AddForce(new Vector3(-this.sidewaysForce * Time.deltaTime, 0f, 0f));
        }

        if (Input.GetKey(KeyCode.D)) 
        {
            this.rb.AddForce(new Vector3(this.sidewaysForce * Time.deltaTime, 0f, 0f));
        }
    }
}
