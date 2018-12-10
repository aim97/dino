using UnityEngine;

public class followDino : MonoBehaviour
{
	public Transform dino;
	public Vector3 offset;
	
	// Use this for initialization
	void Start ()
	{
		offset = new Vector3(0, 15, -30);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = dino.position + offset;
	}
}
