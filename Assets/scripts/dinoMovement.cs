using UnityEngine;
using UnityEngine.Serialization;

public class dinoMovement : MonoBehaviour
{
	[FormerlySerializedAs("rb")] public Rigidbody DinoRb;
	public Transform dinoTr;
	public float jumpForce = 200;
	public float sideForce = 100;
	//public float speed = 5; 
	
	public GameObject gameController;

	private Animator anim;
	private float motionLim;
	
	// Use this for initialization
	void Start ()
	{
		motionLim = 10;
		// you better attach the Gameobject rigid body to DinoRb from  unity when every thing is done
		DinoRb = GetComponent<Rigidbody>();
		DinoRb.freezeRotation = true;
		anim = gameObject.GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameController gc = gameController.GetComponent<GameController>();
		if (gc.isRunning)
		{
			anim.SetBool("isWalking",true);
			if (Input.GetKey(KeyCode.Space) && dinoTr.transform.position.y < 2)
			{
				DinoRb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
			}

			if (Input.GetKey(KeyCode.LeftArrow) && dinoTr.position.z > -motionLim)
			{
				DinoRb.AddForce(0, 0, -sideForce * Time.deltaTime, ForceMode.VelocityChange);
				//transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
			}

			if (Input.GetKey(KeyCode.RightArrow) && dinoTr.position.z < motionLim)
			{
				DinoRb.AddForce(0, 0, sideForce * Time.deltaTime, ForceMode.VelocityChange);
			}
		}
	}

	public void resetDino()
	{
		dinoTr.position = new Vector3(0, 1.6f, 0);
		DinoRb.isKinematic = false;
	}
}
