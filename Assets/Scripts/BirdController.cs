using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float force = 100f;
    private Rigidbody2D mRb;

    private void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mRb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }

    }
}
