using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody2D playerRigidbody;

	[SerializeField]
	private float movementSpeed;


    // Start is called before the first frame update
    void Start()
    {
		playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		float horizontal = Input.GetAxis("Horizontal");
		HandleMovement(horizontal);
    }

	private void HandleMovement(float horizontal)
	{
		playerRigidbody.velocity = new Vector2(horizontal * movementSpeed, playerRigidbody.velocity.y);
	}
}
