using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject player;
	public GameObject condor;
	public GameObject cactus;

	public bool isRunning;
	public GameObject me;
	
	// Use this for initialization
	void Start () {
		// add a new obstacle at a random location every second
		isRunning = true;
		InvokeRepeating("AddObstacles", 2, 1);
	}
	
	
	void AddObstacles(){
		if (isRunning)
		{
			// this function is used to add obstacles at random positions
			float attackCenter = player.transform.position.z;
			float threshold = Random.Range(-5.0f, 5.0f);
			GameObject c;
			if (threshold > 0) // add cactus
			{
				Vector3 loc = new Vector3(-40, 0f, Random.Range(-10.0f + attackCenter, 10.0f + attackCenter));
				c = Instantiate(cactus, loc, Quaternion.identity);
				c.transform.Rotate(new Vector3(0, 90, 0));
				c.GetComponent<obstacleMovement>().gameController = me;
				c.tag = "Obstacle";
			}
			else // add condor
			{
				Vector3 loc = new Vector3(-40, Random.Range(5.0f, 1.0f), Random.Range(-10.0f + attackCenter, 10.0f + attackCenter));
				c = Instantiate(condor, loc, Quaternion.identity);
				c.transform.Rotate(new Vector3(0, 90, 0));
				c.GetComponent<obstacleMovement>().gameController = me;
				c.tag = "Obstacle";
			}
		}
	}
}
