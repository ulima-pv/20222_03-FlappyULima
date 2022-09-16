using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeMovement : MonoBehaviour
{
    public float speed;
    public float gap;

    private float mUpperLimit;
    private float mLowerLimit;

    private Vector3 mScreenBounds;
    private Vector2 mTubeSize;
    private Transform mUpperTube;
    private Transform mLowerTube;

    private void Start()
    {
        mScreenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, 0f)
        );

        mUpperTube = transform.Find("UpperTube");
        mLowerTube = transform.Find("LowerTube");

        mTubeSize = mUpperTube.GetComponent<SpriteRenderer>().bounds.size;
    }

    private void Update()
    {
        transform.position -= Vector3.right * speed * Time.deltaTime;
        if (transform.position.x < -3f)
        {
            // Deberia reposicionarse
            ReposicionarX();
            ReposicionarY();
        }

        
    }

    private void ReposicionarX()
    {
        transform.position = new Vector3(
            4.5f,
            transform.position.y,
            0f
        ); ;
    }

    private void ReposicionarY()
    {
        mLowerLimit = mScreenBounds.y - (mTubeSize.y / 2f);
        mUpperLimit = -mScreenBounds.y + mTubeSize.y + gap + (mTubeSize.y / 2f);

        var posY = Random.Range(mLowerLimit, mUpperLimit);


        mUpperTube.position = new Vector3(
            4.5f,
            posY,
            0f
        );

        mLowerTube.position = new Vector3(
            4.5f,
            posY - mTubeSize.y - gap,
            0f
        );
    }

}
