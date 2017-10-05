using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    public float speed = 0.25f;

    // Update is called once per frame.
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        gameObject.transform.position += h * Vector3.right * speed;
    }
}
