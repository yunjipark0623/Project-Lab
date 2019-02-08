using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveY : MonoBehaviour {
    GameObject player;
    public float yy = 7.0f;
    public float zz = -10.0f;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
    }

    void LateUpdate()
    {
        transform.position = new Vector3(0.1f, player.transform.position.y + yy, zz);
    }

}
