using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {

    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + 7f, 0.01f, -10f);
    }
}
