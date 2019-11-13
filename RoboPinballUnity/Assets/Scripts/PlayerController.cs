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

	private bool IsBall;

	public float speed;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

    void FixedUpdate ()
	{
		//Movimiento
		
		axis.x = Input.GetAxis("Horizontal");														
		axis.y = Input.GetAxis("Vertical");

		movement = new Vector3 (axis.x, 0.0f, axis.y);

		rb.AddForce(movement * speed);
	}
}
