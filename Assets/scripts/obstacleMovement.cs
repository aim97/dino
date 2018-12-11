using UnityEngine;

public class obstacleMovement : MonoBehaviour
{
	public Rigidbody rb;
	public float forwardForce;
	public GameObject obstacle;
	
	public GameObject gameController;
	
	// Use this for initialization
	void Start (){
		forwardForce = 5;
		rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		GameController gc = gameController.GetComponent<GameController>();
		if (gc.isRunning)
		{
			rb.AddForce(forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		else
		{
			rb.isKinematic = true;
		}
		if (obstacle.transform.position.x > 10)
		{
			Destroy(obstacle);
		}
	}
}
