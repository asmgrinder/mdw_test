using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
	public float torque = 50;
	public float force = 25;
	public float horizontalVelocityLimit = 2;
	
	private Rigidbody rb;
	private int coinsAttached = 0;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
	}
    
	void FixedUpdate()
	{
		CoinController.AddTrajectoryPoint(transform.position);
		
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		rb.AddTorque(transform.right * torque * verticalInput);
		float f = force * (horizontalVelocityLimit - Mathf.Abs(rb.velocity.x)); 
		rb.AddForce(transform.right * f * horizontalInput);
	}
	
	void OnTriggerExit(Collider other)
	{
		CoinController cc = other.gameObject.GetComponent<CoinController>();
		if (null != cc
			&& false == cc.IsAttached())
		{
			cc.Attach(++coinsAttached);
		}
	}
}
