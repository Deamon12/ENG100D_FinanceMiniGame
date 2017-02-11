using UnityEngine;
using System.Collections;

public class FoodHandler : MonoBehaviour {
	int numberOfClean = 5;

	public bool SemiTarget;

	void Start ()
	{
		SemiTarget = false;
	}
	void OnTriggerEnter2D ()
	{		
		SemiTarget = true;
	}

	void Update ()
	{
		if (!MouthTriggerHandler.resetAllSemiTarget)
			SemiTarget = false;

		if (SemiTarget && TargetHItHandler.mainTargetHit && MouthTriggerHandler.resetAllSemiTarget) 
		{
			numberOfClean--;
			if (numberOfClean == 0) {
				Destroy (gameObject);
				TargetHItHandler.totalFoodCleared++;
			}
			TargetHItHandler.mainTargetHit = false;

		}

	}
}
