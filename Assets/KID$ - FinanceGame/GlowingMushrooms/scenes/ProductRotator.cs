using UnityEngine;
using System.Collections;

public class ProductRotator : MonoBehaviour {

	public int speed = 10;
	public float rotation;

	private Vector3 rotateAmount;
	// Use this for initialization
	void Start () {
	
	}
	
	void Update() 
	{		
		//transform.Rotate(Vector3.right * Time.deltaTime * speed);
		rotateAmount = Vector3.up * Time.deltaTime * speed;
	
		transform.Rotate(rotateAmount, Space.World);
		rotation += rotateAmount.y;
		print (rotation);
		if (rotation > 360.0f) {			
			UnityEditor.EditorApplication.isPlaying = false;
		}

	}

}
