using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float moveHorizontal;
	private float moveVertical;
	private Vector2 axis;
	private Rigidbody rb;
	private Vector3 movement;

    private Transform playerTransform;
    private Transform cameraTransform;

    private bool rotating;

    private bool IsBall;

	public float speed;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();

        playerTransform = transform;
        cameraTransform = Camera.main.transform;
    }

    void FixedUpdate ()
	{
        Vector3 dir = transform.position - cameraTransform.position;
        dir.y = 0;

        if(dir.normalized != transform.forward.normalized)
        {
            if((Input.GetAxis("Horizontal") != 0) || Input.GetAxis("Vertical") != 0)
            {
                transform.rotation = Quaternion.LookRotation(dir);
                rotating = true;
            }
            else if ((Input.GetAxis("Horizontal") == 0) || Input.GetAxis("Vertical") == 0)
            {
                transform.rotation = Quaternion.LookRotation(dir);
                rotating = false;
            }
        }
        //Movimiento
		
		axis.x = Input.GetAxis("Horizontal");														
		axis.y = Input.GetAxis("Vertical");

		movement = new Vector3 (axis.x, 0.0f, axis.y);

		rb.AddForce(movement * speed);

        Debug.DrawRay(transform.position, dir, Color.blue);
        Debug.DrawRay(transform.position, transform.forward, Color.green);
	}
}
