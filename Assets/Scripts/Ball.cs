using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] PaddleMovement paddle;

    Vector2 ballToPaddleDifference;
    bool ballLaunched = false;

    [SerializeField]
    private AudioClip[] ballSounds;

    private AudioSource audioSource;
    private Rigidbody2D ballRigidbody;

    [SerializeField]
    private float maxBounceTweak = 0.2f;

	// Use this for initialization
	void Start () {
        ballToPaddleDifference = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        ballRigidbody = GetComponent<Rigidbody2D>();
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
        Vector2 bounceTweak = new Vector2(
            Random.Range(0, maxBounceTweak),
            Random.Range(0, maxBounceTweak));

        if (ballLaunched) {
            int soundIndex = UnityEngine.Random.Range(0, ballSounds.Length);
            audioSource.PlayOneShot(ballSounds[soundIndex]);

            ballRigidbody.velocity += bounceTweak;
        }
    }

    public void lockBall() {
        this.ballLaunched = false;
    }
}
