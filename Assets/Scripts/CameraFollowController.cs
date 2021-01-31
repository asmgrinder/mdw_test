using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
	public Transform objectToFollow;
	public Vector3 offset;
	public float followSpeed = 10;
	public float lookSpeed = 10;
	
	public void LookAtTarget()
	{
		Vector3 _lookDirection = objectToFollow.position - transform.position + new Vector3(0, 0.5f, 0);
		Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
	}
	
	public void MoveToTarget()
	{
		Vector3 _targetPos = objectToFollow.position
								+ Vector3.right * offset.x
								+ Vector3.up * offset.y
								+ Vector3.forward * offset.z;
		transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
	}
	
	protected void FixedUpdate()
	{
		LookAtTarget();
		MoveToTarget();
	}
}
