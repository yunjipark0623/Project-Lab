using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage2Camera : MonoBehaviour {
    GameObject player;
    public float yy = 7.0f;
    public float zz = -10.0f;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(1f, player.transform.position.y + yy, zz);
    }
}
