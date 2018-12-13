using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
	public GameObject player;
	public GameObject condor;
	public GameObject cactus;
	public string gameSceneName;
	public bool isRunning;
	public GameObject me;

	public Text curScoreLabel;
	public Text maxScoreLabel;
	public Text gameStateLabel;
	
	private float startTime;
	private float obstacleStartPos;
	private int maxScore = 0;
	private int curScore;
	private bool flag;
	
	
	// Use this for initialization
	void Start () {
		// add a new obstacle at a random location every second
		resetGameState();
		InvokeRepeating("AddObstacles", 0, 0.5f);
	}

	void Update()
	{
		if (isRunning)
			curScore = (int) (Time.time - startTime);
		else
		{
			gameStateLabel.text = "GAME OVER :P";
		}
		curScoreLabel.text = curScore.ToString("0");
		maxScoreLabel.text = maxScore.ToString("0");
	}


	void AddObstacles()
	{
		if (player.transform.position.y < 0) isRunning = false;
		
		if (isRunning)
		{
			// this function is used to add obstacles at random positions
			float attackCenter = player.transform.position.z;
			float threshold = Random.Range(-5.0f, 5.0f);
			GameObject c;
			if (threshold > 0) // add cactus
			{
				Vector3 loc = new Vector3(obstacleStartPos, 0f, Random.Range(-20.0f + attackCenter, 20.0f + attackCenter));
				c = Instantiate(cactus, loc, Quaternion.identity);
				c.transform.Rotate(new Vector3(0, 90, 0));
				c.GetComponent<obstacleMovement>().gameController = me;
				c.tag = "Obstacle";
			}
			else // add condor
			{
				Vector3 loc = new Vector3(obstacleStartPos, Random.Range(5.0f, 1.0f), Random.Range(-20.0f + attackCenter, 20.0f + attackCenter));
				c = Instantiate(condor, loc, Quaternion.identity);
				c.transform.Rotate(new Vector3(0, 90, 0));
				c.GetComponent<obstacleMovement>().gameController = me;
				c.tag = "Obstacle";
			}
		}
		else if(flag)
		{
			maxScore = Math.Max(maxScore, curScore);
			player.GetComponent<Animator>().SetBool("isWalking",false);
			flag = false;
			PlayerPrefs.SetInt("maxScore", maxScore);
		}
		if (!flag && Input.GetKey(KeyCode.Space))
		{
			SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
			//restartScene();
		}
	}

	void restartScene()
	{
		// removing old game objects
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Obstacle");
		foreach(GameObject enemy in enemies)
			Destroy(enemy);
		
		// reseting player location
		player.GetComponent<dinoMovement>().resetDino();
		player.GetComponent<dinoMovement>().enabled = true;
		
		// reseting labels
		gameStateLabel.text = "";
		
		// reset overall game state by calling start function which will reset curScore
		// and start invoking add obstacles repeatedly
		resetGameState();
	}

	void resetGameState()
	{
		flag = true;
		gameSceneName = "scene2";
		curScore = 0;
		if (!PlayerPrefs.HasKey("maxScore"))
		{
			maxScore = 0;
		}
		else
		{
			maxScore = PlayerPrefs.GetInt("maxScore");
		}
		obstacleStartPos = -100;
		isRunning = true;
		startTime = Time.time;
	}
}
