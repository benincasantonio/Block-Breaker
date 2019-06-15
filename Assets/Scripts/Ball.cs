using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] PaddleMovement paddle;

    Vector2 ballToPaddleDifference;
    bool ballLaunched = false;

    [SerializeField]
    private AudioClip[] ballSounds;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        ballToPaddleDifference = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!ballLaunched) {
            this.lockBallToPaddle();
            launchBall();
        }
    }

    private void lockBallToPaddle() {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + ballToPaddleDifference;
    }

    private void launchBall() {
        if(Input.GetMouseButtonDown(0)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 9f);
            ballLaunched = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (ballLaunched) {
            int soundIndex = UnityEngine.Random.Range(0, ballSounds.Length);
            audioSource.PlayOneShot(ballSounds[soundIndex]);
        }
    }

    public void lockBall() {
        this.ballLaunched = false;
    }
}
