using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemRotate : MonoBehaviour {
    float rotateSpeed = 100.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
	}
}
