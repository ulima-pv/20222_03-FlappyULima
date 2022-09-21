using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMovement : MonoBehaviour
{
    public float scrollSpeed;

    private Vector3 initialPos;
    private float mNewPos;
    private bool mRunning = true;


    void Start()
    {
        initialPos = transform.position;
        BirdController.Instance.AddDelegate(OnBirdCollisionDelegate);
    }

    public void OnBirdCollisionDelegate(object sender, EventArgs e)
    {
        mRunning = false;
    }

    void Update()
    {
        if (mRunning)
        {
            mNewPos = Mathf.Repeat(scrollSpeed * Time.time, 5.6f);

            transform.position = initialPos - Vector3.right * mNewPos;
        }
        
    }
}
