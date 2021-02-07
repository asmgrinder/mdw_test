using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
	public float followSpeed = 10;
	public float rotSpeed = 5;
	public float distance = 1.5f;
	[HideInInspector] public int index = 0;
	[HideInInspector] public static int maxIndex;
	private static List<Vector3> trajectory = new List<Vector3>();
	
	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (index > 0)
		{
			float prevDist = 0;
			float dist = -1;
			Vector3 lastPoint = new Vector3(0, 0, 0);
			foreach (Vector3 point in trajectory)
			{
				if (dist >= 0)
				{
					dist += (point - lastPoint).magnitude;
				}
				else
				{
					dist = 0;
				}
				if (dist > index * distance
					&& dist != prevDist)
				{
					Vector3 newPos = Vector3.Lerp(lastPoint, point, (index * distance - prevDist) / (dist - prevDist));
					transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
					break;
				}
				lastPoint = point;
				prevDist = dist;
			}
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, rotSpeed * Time.deltaTime);
			
			reduceTail();
		}
	}
	
	private void reduceTail()
	{
		if (trajectory.Count > 0)
		{
			float dist = 0;
			for (int i = 1; i < trajectory.Count; i++)
			{
				dist += (trajectory[i] - trajectory[i - 1]).magnitude;
				if (dist > (2 + maxIndex) * distance)
				{
					while (i < trajectory.Count)
					{
						trajectory.RemoveAt(i);
					}
					break;
				}
			}
		}
	}
	
	public static void AddTrajectoryPoint(Vector3 Point)
	{
		trajectory.Insert(0, Point);
	}
	
	public bool IsAttached()
	{
		return index > 0;
	}
	
	public void Attach(int Index)
	{
		index = Index;
		maxIndex = Mathf.Max(maxIndex, index);
	}
}
