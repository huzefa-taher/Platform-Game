using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPlatform : MonoBehaviour {
    public float speed;
    public float jumpPower;

    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float xVelocity = speed * Input.GetAxis("Horizontal");
        float yVelocity = rb.velocity.y;

        if(Input.GetAxis("Vertical") > 0 && isGrounded())
        {
            yVelocity = jumpPower;
        }
        Vector3 Velocity = new Vector3(xVelocity, yVelocity, 0);
        rb.velocity = Velocity;
    }

    bool isGrounded()
    {
        int layerMask = LayerMask.GetMask("Platform");
        return Physics.Raycast(transform.position, Vector3.down, 0.6f, layerMask);
    }
}
