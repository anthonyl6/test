using UnityEngine;

public class Ball : MonoBehaviour {

	[SerializeField] Paddle paddle1;
	[SerializeField] float xPush = 2f;
	[SerializeField] float yPush = 15f;
	[SerializeField] float zPush = 1f;
	[SerializeField] AudioClip[] ballSounds;
	[SerializeField] float randomFactor = 0.2f;

	//state
	Vector3 paddleToBallVector;
	bool hasStarted = false;

	//cached component references
	AudioSource myAudioSource;
	Rigidbody2D myRigidBody2D;
	Level level;
	Collider2D MyCollider2D;

	// Use this for initialization
	void Start () 
	{
		paddleToBallVector = transform.position - paddle1.transform.position;
		myAudioSource = GetComponent<AudioSource>();
		myRigidBody2D = GetComponent<Rigidbody2D>();
		countNumberOfBalls();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!hasStarted) 
		{
			LockBallToPaddle();
			LaunchOnMouseClick();
		}	
	}

	public void countNumberOfBalls()
	{
		level = FindObjectOfType<Level>();

		if(tag == "Ball")
		{
			level.CountBalls();
		}
	}

	private void LaunchOnMouseClick() 
	{
		MyCollider2D = GetComponent<Collider2D>();

		if (Input.GetMouseButtonDown(0)) 
		{
			myRigidBody2D.velocity = new Vector3 (xPush, yPush, zPush);
			hasStarted = true;
			MyCollider2D.enabled = true;
		}
	}
	private void LockBallToPaddle() {
		
		Vector3 paddlePos = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, transform.position.z);
		transform.position = paddlePos + paddleToBallVector;
		
	}
	private void OnCollisionEnter2D(Collision2D collision) 
	{
		Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

		if(hasStarted) 
		{
			AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
			myAudioSource.PlayOneShot(clip);
			myRigidBody2D.velocity += velocityTweak;
		}
	}
}
