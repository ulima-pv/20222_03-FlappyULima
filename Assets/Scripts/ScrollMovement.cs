using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMovement : MonoBehaviour
{
    public float scrollSpeed;

    private Vector3 initialPos;
    private float mNewPos;

    void Start()
    {
        initialPos = transform.position;
    }

    void Update()
    {
        mNewPos = Mathf.Repeat(scrollSpeed * Time.time, 5.6f);

        transform.position = initialPos - Vector3.right * mNewPos;
    }
}
