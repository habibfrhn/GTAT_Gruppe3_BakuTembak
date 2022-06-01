using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacterController2D : MonoBehaviour
{
   [SerializeField] private float m_JumpForce = 900f;							// jumping force
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// variable to control how smooth the movement
	[SerializeField] public bool m_AirControl = true;							// moving while on air or not
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// empty to check if the player on the ground or not

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	public bool m_Grounded;            // variable to check if the plaer on the ground or not
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // which way currently the player facing
	private Vector3 m_Velocity = Vector3.zero;
	public int jumps = 0;


	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		//groundcheck
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool jump)
	{

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			//move
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// smoothing out the movement
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			
			if (move > 0 && !m_FacingRight)
			{
				// flip the player.
				Flip();
			}
			
			else if (move < 0 && m_FacingRight)
			{
				// flip the player.
				Flip();
			}
		}

        // double jump condition
        if(jumps>0)
		{
			jump=false;
			if(m_Grounded)
			{
				jumps=0; // count to 0 whenever on ground
			}
		}

        if (jump && m_Grounded)
		{
			// Add a vertical force to the player.
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
		else if (jump && !m_Grounded && jumps <= 0) // limit the jump to 2 times
		{
			// Add a vertical force to the player.
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce+250f));
			jumps++;
		}
        
	}
			

	private void Flip()
	{
		// Switch facing
		m_FacingRight = !m_FacingRight;		
		
        //rotate the player in y-axis
		transform.Rotate(0f, 180f, 0f);
	}
}
	

