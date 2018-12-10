using UnityEngine;

public class collisionHandler : MonoBehaviour
{

	public dinoMovement dinoMotionContoller;

	public GameObject controller;
	// function to be called on collision
	void OnCollisionEnter(Collision coll)
	{
		if (coll.collider.CompareTag("Obstacle"))
		{
			Debug.Log("collision occured");
			dinoMotionContoller.enabled = false;
			controller.GetComponent<gameController>().isRunning = false;
		}
	}
}
