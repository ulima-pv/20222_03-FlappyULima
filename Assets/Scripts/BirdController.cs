using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static BirdController Instance { private set; get;}

    public float force = 100f;
    private Rigidbody2D mRb;

    private event EventHandler  mOnBirdCollision;
    private bool mRunning = true;
    private int mPuntaje = 0;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
        mRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (mRunning && Input.GetMouseButtonDown(0))
        {
            mRb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Parar el juego
        mRunning = false;
        mOnBirdCollision?.Invoke(this, EventArgs.Empty);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        mPuntaje++;     
    }

    public void AddDelegate(EventHandler handler)
    {
        mOnBirdCollision += handler;
    }
}
