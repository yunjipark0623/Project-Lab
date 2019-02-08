using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float moveSpeed = 3.0f;
    public float rotateSpeed = 150.0f;
    public Animator ani;
    public float attackTime = 0.0f;
    public CharacterController controller;

	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (ani.GetInteger("state") == 2)
        {
            attackTime += Time.deltaTime;
            if (attackTime > 1.0f)
                ani.SetInteger("state", 0);
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ani.SetInteger("state", 2);
            attackTime = 0.0f;
            return;
        }

        if (h != 0.0f || v != 0.0f)
        {
            if (ani.GetInteger("state") != 1)
                ani.SetInteger("state", 1);
            //transform.Translate(0, 0, v * moveSpeed * Time.deltaTime);
            controller.Move(transform.forward * v * moveSpeed * Time.deltaTime); 
            transform.Rotate(0, h * rotateSpeed * Time.deltaTime, 0);
        }
        else
        {
            if (ani.GetInteger("state") != 0)
                ani.SetInteger("state", 0);
        }
        //Vector3 moveVec = new Vector3(h * movePower * Time.deltaTime, 0, v * movePower * Time.deltaTime);
        //rigid.AddForce(moveVec, ForceMode.Impulse);
    }

    float point = 0.0f;
    void OnTriggerEnter(Collider collider)
    {
        point += 10.0f;
        Debug.Log(point.ToString());
        Destroy(collider.gameObject);
    }
}
