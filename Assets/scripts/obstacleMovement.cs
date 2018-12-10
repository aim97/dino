using UnityEngine;

public class obstacleMovement : MonoBehaviour
{
	public Rigidbody rb;
	public float forwardForce;
	public GameObject obstacle;
	
	public GameObject gameController;
	
	// Use this for initialization
	void Start (){
		forwardForce = 10;
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		gameController gc = gameController.GetComponent<gameController>();
		if (gc.isRunning)
		{
			rb.AddForce(forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
			if (obstacle.transform.position.x > 10)
			{
				Destroy(obstacle);
			}

			forwardForce += 0.001f * Time.deltaTime;
		}
	}
}
