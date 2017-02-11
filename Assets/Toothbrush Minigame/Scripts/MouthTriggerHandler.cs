using UnityEngine;
using System.Collections;

public class MouthTriggerHandler : MonoBehaviour {

	public static bool resetAllSemiTarget;

	void OnTriggerEnter2D ()
	{		
		MouthTriggerHandler.resetAllSemiTarget = true;
	}
	void OnTriggerExit2D(Collider2D other) 
	{
		MouthTriggerHandler.resetAllSemiTarget = false;
    }
}
