using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
	public float followSpeed = 10;
	public float rotSpeed = 5;
	public float distance = 1.5f;
// 	public Vector3 offset;
	[HideInInspector] public Transform objectToFollow = null;
	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (null != objectToFollow)
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, rotSpeed * Time.deltaTime);
			Vector3 dir = transform.position - objectToFollow.position;
			dir.y = 0;
			Vector3 targetPos = objectToFollow.position + distance * dir.normalized;
			targetPos.y = transform.position.y;
// 			Vector3 _targetPos = objectToFollow.position
// 									+ Vector3.right * offset.x
// // 									+ Vector3.up * offset.y
// 									+ Vector3.forward * offset.z;
// 			_targetPos.y = offset.y;
			transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
		}
	}
	
// 	void OnTriggerEnter(Collider other)	// OnTriggerStay, OnTriggerExit
// 	{
// 		GetComponent<MeshCollider>().isTrigger = false;
// 	}
}
