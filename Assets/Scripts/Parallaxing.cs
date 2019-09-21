using UnityEngine;

public class Parallaxing : MonoBehaviour {

	private Transform target;
	private GameObject cam;
	public Vector3 offset;
	
	
	// Update is called once per frame
	void Update () 
	{
        cam = GameObject.FindGameObjectWithTag("Player");
        target = cam.transform;
        transform.position = new Vector3(target.transform.position.x, 0, 0) + offset;
	}
}
