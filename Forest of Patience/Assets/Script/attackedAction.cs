using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackedAction : MonoBehaviour {
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = gameObject.GetComponentInChildren<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Spike"){
            Vector2 attackedVelocity = Vector2.zero;
            if (other.gameObject.transform.position.x > transform.position.x)
                attackedVelocity = new Vector2(-2f, 7f);
            else
                attackedVelocity = new Vector2(2f, 7f);
            rigid.AddForce(attackedVelocity, ForceMode2D.Impulse);
            
        }

    }
}
