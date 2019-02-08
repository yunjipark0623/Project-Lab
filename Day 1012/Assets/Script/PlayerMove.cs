using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CharacterState
{
    Idle = 0,
    Run,
    Attack,
    AttackRun,
    Max
}

enum LayerState 
{
    Field = 8,
    Enemy = 9,
    Max
}

public class PlayerMove : MonoBehaviour {
    public float moveSpeed = 3.0f;
    public float rotateSpeed = 150.0f;
    public Animator ani;
    public float attackTime = 0.0f;
    public CharacterController controller;
    public Vector3 movePos;
    public int layerMask = (1 << 8) + (1 << 9);
    public Transform attackPoint;
    public Transform movePoint;

	void Start () {
        ani = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        movePos = controller.transform.position;
        attackPoint = GameObject.FindGameObjectWithTag("AttackPoint").transform;
        movePoint = GameObject.FindGameObjectWithTag("MovePoint").transform;
        attackPoint.gameObject.SetActive(false);
        movePoint.gameObject.SetActive(false);

	}
	
	void Update () {
        RaycastHit hitinfo;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitinfo, 100.0f, layerMask))
            {
                int layer = hitinfo.collider.gameObject.layer;
                if (layer == 9)
                {
                    attackPoint.position = hitinfo.point;
                    attackPoint.gameObject.SetActive(true);
                    movePos = hitinfo.point;
                }
                else
                {
                    movePoint.position = hitinfo.point;
                    movePoint.gameObject.SetActive(true);
                    movePos = hitinfo.point;
                    ani.SetInteger("state", (int)CharacterState.Run);
                }
                //int layer = hitinfo.collider.gameObject.layer;
                //Debug.Log("layer" + layer + " and " + hitinfo.point);
            }
        }

        if (ani.GetInteger("state") == (int)CharacterState.AttackRun)
        {
            if (MoveUtil.MoveFrame(controller, movePos, moveSpeed, rotateSpeed) < 1.5)
            {
                ani.SetInteger("state", (int)CharacterState.Attack);
                attackPoint.gameObject.SetActive(false);
                attackTime = 0;
            }
        }

        if(ani.GetInteger("state") == (int)CharacterState.Attack)
        {
            attackTime += Time.deltaTime;
            //if(attackTime > 3.0f)
                //ani.SetInteger
        }

        //if (transform.position != movePos)
        //{
        //    Vector3 normal = movePos - transform.position;
        //    normal.Normalize();
        //    controller.Move(normal * moveSpeed * Time.deltaTime);
        //    ani.SetInteger("state", 1);
        //}
        //else
            //ani.SetInteger("state", 0);

        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        //if (h != 0.0f || v != 0.0f)
        //{  
        //    controller.Move(transform.forward * v * moveSpeed * Time.deltaTime);
        //    transform.Rotate(0, h * rotateSpeed * Time.deltaTime, 0);
        //    ani.SetInteger("state", 1);
        //}
        //else
        //{
        //    ani.SetInteger("state", 0);
        //}
    }
}
