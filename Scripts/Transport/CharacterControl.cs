using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public float moveSpeed = 10f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        transform.Translate(transform.rotation * (Vector3.forward));
        //rb.AddRelativeForce (movement* moveSpeed);
    }


    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}