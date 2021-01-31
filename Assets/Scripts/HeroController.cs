using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
	public float torque = 50;
	public float force = 25;
	public float headOffset = -0.5f;
	public float horizontalVelocityLimit = 2;
	
	private Rigidbody rb;
	private Transform lastCoin;

	// Start is called before the first frame update
	void Start()
	{
// 		lastCoin = transform;
		rb = GetComponent<Rigidbody>();
// 		wc = GetComponent<WheelCollider>();
	}

	// Update is called once per frame
	void Update()
	{
	}
    
	void FixedUpdate()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		rb.AddTorque(transform.right * torque * verticalInput);
		float f = force * (horizontalVelocityLimit - Mathf.Abs(rb.velocity.x)); 
		rb.AddForce(transform.right * f * horizontalInput);
		
	}
	
// 	private void OnCollisionEnter(Collision collision)
// 	{
// 		Debug.Log("OnCollisionEnter");
// 	}

	void OnTriggerExit(Collider other)	// OnTriggerStay, OnTriggerExit
	{
// 		Debug.Log("Trigger enter !");
		CoinController cc = other.gameObject.GetComponent<CoinController>();
		if (null == cc.objectToFollow)
		{
			cc.objectToFollow = (null == lastCoin) ? transform : lastCoin;
			lastCoin = other.gameObject.transform;
		}
	}
}
