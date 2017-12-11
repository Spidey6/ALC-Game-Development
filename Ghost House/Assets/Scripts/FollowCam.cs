using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	public Transform target;
	public Vector3 defaultDistance = new Vector3(0f, 2f, -10f);
	public float distanceDamp = 10f;
	public float rotationalDamp = 10f;

	Transform myT;


	void Awake()
	{
		myT = transform;
	}



	void LateUpdate()
	{
		Vector3 toPros = target.position + (target.rotation * defaultDistance);
		Vector3 curPros = Vector3.Lerp(myT.position, toPros, distanceDamp * Time.deltaTime);
		myT.position = curPros;

		Quaternion toRot = Quaternion.LookRotation(target.position - myT.position, target.up);
		Quaternion curRot = Quaternion.Slerp(myT.rotation, toRot, rotationalDamp * Time.deltaTime);
		myT.rotation = curRot;
	}
}
