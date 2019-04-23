using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] PaddleMovement paddle;

    Vector2 ballToPaddleDifference;
    bool ballLaunched = false;
	// Use this for initialization
	void Start () {
        ballToPaddleDifference = transform.position - paddle.transform.position;
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 13f);
            ballLaunched = true;
        }
    }
}
