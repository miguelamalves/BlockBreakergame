﻿using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour {

    //config
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush;
    [SerializeField] float yPush;
    [SerializeField] AudioClip [] ballSounds;
    [SerializeField] float randomFactor = 0.2f;


    //state
    Vector2 distanceToBallVector;
    bool hasStarted = false;

    //cached references
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start () {
        distanceToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted) {
        LockBallWithPaddle();
        LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidbody2D.velocity = new Vector2(xPush,yPush);
            hasStarted = true;
        }
    }

    private void LockBallWithPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + distanceToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f,randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
    }

}
