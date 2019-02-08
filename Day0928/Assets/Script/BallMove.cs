using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {
    public float movePower = 5.0f;
    Rigidbody rigid;
	// Use this for initialization
	void Awake () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0.0f || v != 0.0f) {
            Vector3 moveVec = new Vector3(h * movePower * Time.deltaTime, 0, v * movePower * Time.deltaTime);
            rigid.AddForce(moveVec, ForceMode.Impulse);
        }
        
	}
    float point = 0.0f;
    void OnTriggerEnter(Collider collider) {
        point += 10.0f;
        Debug.Log(point.ToString());
        Destroy(collider.gameObject);
    }
}
