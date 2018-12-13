using UnityEngine;

public class collisionHandler : MonoBehaviour
{

	public dinoMovement dinoMotionContoller;
	public GameObject dino;
	public GameObject controller;
	// function to be called on collision
	void OnCollisionEnter(Collision coll)
	{
		if (coll.collider.CompareTag("Obstacle"))
		{ 
			dinoMotionContoller.enabled = false;
			controller.GetComponent<GameController>().isRunning = false;
			dino.GetComponent<Rigidbody>().isKinematic = true;
		}
	}
}
