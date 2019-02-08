using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public Transform playerTransForm;
	public float smoothTime = 0.7f;
	protected Vector3 currentVelosity = Vector3.zero;

	void Awake()
	{
		playerTransForm = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Vector3.SmoothDamp(transform.position, playerTransForm.position, ref currentVelosity, smoothTime);
		transform.rotation = Quaternion.Slerp(transform.rotation, playerTransForm.rotation, Time.deltaTime * 2);

	}
}
