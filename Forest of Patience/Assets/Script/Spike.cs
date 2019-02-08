using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour
{
    private float moveSpeed = 4.0f;

    void Start()
    {
        Destroy(gameObject, 10);
    }
    void Update()
    {
        float SpikeX = moveSpeed * Time.deltaTime;
        transform.Translate(-SpikeX, 0, 0);
    }
}