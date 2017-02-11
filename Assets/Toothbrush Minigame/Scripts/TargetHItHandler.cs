using UnityEngine;
using System.Collections;

public class TargetHItHandler : MonoBehaviour {

	static public bool mainTargetHit;
	static public int totalFoodCleared;
	public GameObject gameOverBtn;
	public DragScript DragScriptObj;
	void Start ()
	{
		totalFoodCleared = 0;
		mainTargetHit = false;
	}
	void OnTriggerEnter2D ()
	{		
		mainTargetHit = true;
	}
	void Update ()
	{		
		if (TargetHItHandler.totalFoodCleared >= 5)
			DragScriptObj.EnableMe (gameOverBtn);
	}
}
