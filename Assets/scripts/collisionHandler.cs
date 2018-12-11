using UnityEngine;

public class collisionHandler : MonoBehaviour
{

	public dinoMovement dinoMotionContoller;
	public GameObject dino;
	public GameObject controller;
	// function to be called on collision
	void OnCollisionEnter(Collision coll)
	{
		Debug.Log("we hit something " + coll.collider.name + " of " + coll.collider.tag);
		if (coll.collider.CompareTag("Obstacle"))
		{
			Debug.Log("collision occured"); 
			dinoMotionContoller.enabled = false;
			controller.GetComponent<GameController>().isRunning = false;
			dino.GetComponent<Rigidbody>().isKinematic = true;
		}
	}
}
