using UnityEngine;
using System.Collections;

public class DragScript : MonoBehaviour {

	public GameObject target;
	private Plane plane;
	private Vector3 v3Offset;
	bool gameStarted, flossStringPicked;

	//public GameObject StartButton;

	void Start () 
	{
		gameStarted = false;
		flossStringPicked = false;
	}

	 void Update ()
	{
		if (gameStarted && flossStringPicked) 
		{
			float AngleRad = Mathf.Atan2 (target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x);            
			float AngleDeg = (180 / Mathf.PI) * AngleRad;            
			this.transform.rotation = Quaternion.Euler (0, 0, AngleDeg);
		}
     }

	void OnMouseDown ()
	{
		if (gameStarted) 
		{
			plane.SetNormalAndPosition(Camera.main.transform.forward, transform.position);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float dist;
			plane.Raycast (ray, out dist);
			v3Offset = transform.position - ray.GetPoint (dist);  
		}

	}
	
	void OnMouseDrag ()
	{
		if (gameStarted) 
		{
			flossStringPicked = true;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float dist;
			plane.Raycast (ray, out dist);
			Vector3 v3Pos = ray.GetPoint (dist);
			transform.position = v3Pos + v3Offset;  
		}
	}

	public void OnStartFlossClicked()
	{
		gameStarted = true;
	}

	public void EnableMe (GameObject obj)
	{
		obj.SetActive (true);
	}

	public void DisbleMe (GameObject obj)
	{
		obj.SetActive (false);
	}

}
