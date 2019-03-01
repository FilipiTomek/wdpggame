using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
	bool crouchCheck;


	void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
			if (animator.GetBool("IsCrouching") == false)
			{
				jump = true;
				animator.SetBool("IsJumping", true);
				crouchCheck = false;
			}
        }

        if(Input.GetButtonDown("Crouch"))
        {
			if(crouchCheck == true)
			{
				crouch = true;
			}
        } else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

		if (Input.GetButtonDown("Attack"))
		{
			animator.SetTrigger("IsAttacking");
		}

	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
		crouchCheck = true;
	}

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
	}
}
