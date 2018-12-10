using UnityEngine;
using UnityEngine.Serialization;

public class dinoMovement : MonoBehaviour
{
	[FormerlySerializedAs("rb")] public Rigidbody DinoRb;
	public Transform dinoTr;
	public float jumpForce = 200;
	public float sideForce = 100;

	public GameObject gameController;
	
	// Use this for initialization
	void Start ()
	{
		// you better attach the Gameobject rigid body to DinoRb from  unity when every thing is done
		DinoRb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameController gc = gameController.GetComponent<gameController>();
		if (gc.isRunning)
		{
			if (Input.GetKey(KeyCode.Space) && dinoTr.transform.position.y < 2)
			{
				DinoRb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
			}

			if (Input.GetKey(KeyCode.LeftArrow))
			{
				DinoRb.AddForce(0, 0, -sideForce * Time.deltaTime, ForceMode.VelocityChange);
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				DinoRb.AddForce(0, 0, sideForce * Time.deltaTime, ForceMode.VelocityChange);
			}
		}
	}
}
