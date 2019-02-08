using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CharacterState
{
    Idle =0,
    Run,
    Attack,
    Max
}
public class PlayerMove : MonoBehaviour {
    public float moveSpeed = 3.0f;
    public float rotateSpeed = 150.0f;
    public Animator ani;
    public float attackTime = 0.0f;
    public CharacterController controller;
    public Vector3 movePos;
    public int layerMask;
    public Transform attackPoint;
    public Transform movePoint;

	void Start () {
        controller = GetComponent<CharacterController>();
        ani = GetComponent<Animator>();
        layerMask = (1 << 8) + (1 << 9);
        movePos = controller.transform.position;
        attackPoint = GameObject.FindGameObjectWithTag("AttackPoint").transform;
        movePoint = GameObject.FindGameObjectWithTag("MovePoint").transform;
        attackPoint.gameObject.SetActive(false);
        movePoint.gameObject.SetActive(false);
    }
	
	void Update () {
        RaycastHit hitInfo;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray =
                Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, 100.0f, layerMask))
            {
                int layer = hitInfo.collider.gameObject.layer;
                if (layer == 9)
                {
                    attackPoint.position = hitInfo.point;
                    attackPoint.gameObject.SetActive(true);
                    movePos = hitInfo.point;
                    ani.SetInteger("state", (int)CharacterState.AttackRun);
                }
                else
                {
                    movePoint.position = hitInfo.point;
                    movePoint.gameObject.SetActive(true);
                    movePos = hitInfo.point;
                    ani.SetInteger
                }
                movePos = hitInfo.point;
                ani.SetInteger("state", 1);
            }
        }

        if (ani.GetInteger("state")==1)
        {
            if (MoveUtil.MoveFrame(controller, movePos, moveSpeed,
                rotateSpeed) == 0)
                ani.SetInteger("state", 0);
        }

        /*
        if (transform.position != movePos)
        {
            Vector3 normal = movePos - transform.position;
            normal.Normalize();
            controller.Move(normal * moveSpeed * Time.deltaTime);
            ani.SetInteger("state", 1);
        }
        else
            ani.SetInteger("state", 0);
            */
        /*
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        if (h != 0.0f || v != 0.0f)
        {  
            controller.Move(transform.forward * v * moveSpeed * Time.deltaTime);
            transform.Rotate(0, h * rotateSpeed * Time.deltaTime, 0);
            ani.SetInteger("state", 1);
        }
        else
        {
            ani.SetInteger("state", 0);
        }
        */
    }
}
