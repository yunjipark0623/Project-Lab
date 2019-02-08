using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logCollision : MonoBehaviour {
    Animator animator;
    Rigidbody2D rigid;
    BoxCollider2D col;

    bool isJumping = false;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponentInChildren<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Jump") && !animator.GetBool("isJumping")) {
            col.isTrigger = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player" && rigid.velocity.y < 0) {
            col.isTrigger = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "ground") {
            col.isTrigger = false;
        }
    }
}
