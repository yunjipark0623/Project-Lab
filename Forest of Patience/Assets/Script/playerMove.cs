using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour {

    public float movePower = 5f;
    public float jumpPower = 7f;
    public float AttackedX = -2.5f;
    public float AttackedY = 2f;

    Rigidbody2D rigid;
    Animator animator;
    BoxCollider2D collider;

    Vector3 movement;
    bool isJumping = false;

	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
        collider = gameObject.GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetAxisRaw("Horizontal") == 0) {
            animator.SetBool("isMoving", false);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0) {
            animator.SetBool("isMoving", true);
        }
        else if(Input.GetAxisRaw("Horizontal") > 0) {
            animator.SetBool("isMoving", true);
        }

        if(Input.GetButtonDown("Jump") && !animator.GetBool("isJumping")) {
            isJumping = true;
            animator.SetBool("isJumping", true);//jumping flag
            animator.SetTrigger("doJumping");
            //collider.enabled = false;
        }
	}

    void FixedUpdate() {
        Move();
        Jump();
    }

    void Move() {
        Vector3 moveVelocity = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal") < 0) {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);//Left Flip
        }
        else if(Input.GetAxisRaw("Horizontal") > 0) {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);//Right Flip
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Jump() {
        if(!isJumping) {
            return;
        }
        //collider.enabled = false;
        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
        //collider.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Attach : " + other.gameObject.layer);

        if(other.gameObject.layer == 8 && rigid.velocity.y < 0) {
            animator.SetBool("isJumping", false);
            animator.SetBool("doJumping", false);
        }

        //if (other.gameObject.tag == "Spike")
        //{
        //    Vector2 attackedVelocity = Vector2.zero;
        //    if (other.gameObject.transform.position.x > transform.position.x)
        //        attackedVelocity = new Vector2(-1.75f, 2f);
        //    else
        //        attackedVelocity = new Vector2(1.75f, 2f);
        //    animator.SetBool("isJumping", true);
        //    rigid.AddForce(attackedVelocity, ForceMode2D.Impulse);
        //}
        if (other.gameObject.tag == "Spike")
        {
            Debug.Log("pop");
            Vector2 attackedVelocity = Vector2.zero;
            if (other.gameObject.transform.position.x > transform.position.x)
                attackedVelocity = new Vector2(AttackedX, AttackedY);
            else
                attackedVelocity = new Vector2(-AttackedX, AttackedY);
            animator.SetBool("isJumping", true);
            rigid.AddForce(attackedVelocity, ForceMode2D.Impulse);
        }
        else if (other.gameObject.tag == "ShootingMonster")
        {
            Vector2 attackedVelocity = Vector2.zero;
            if (other.gameObject.transform.position.x > transform.position.x)
                attackedVelocity = new Vector2(AttackedX, AttackedY);
            else
                attackedVelocity = new Vector2(-AttackedX, AttackedY);
            animator.SetBool("isJumping", true);
            rigid.AddForce(attackedVelocity, ForceMode2D.Impulse);
        }
    }



    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Detach : " + other.gameObject.layer);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ShootingMonster")
        {
            Vector2 attackedVelocity = Vector2.zero;
            if (other.gameObject.transform.position.x > transform.position.x)
                attackedVelocity = new Vector2(AttackedX, AttackedY);
            else
                attackedVelocity = new Vector2(-AttackedX, AttackedY);
            animator.SetBool("isJumping", true);
            rigid.AddForce(attackedVelocity, ForceMode2D.Impulse);
        }
        else if (other.gameObject.tag == "log" || other.gameObject.tag == "ground")
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("doJumping", false);
        }
    }
}
