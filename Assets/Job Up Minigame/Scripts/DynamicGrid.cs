using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/* For the FinishedGameScreen, simply makes the ScrollView dynamic */
public class DynamicGrid : MonoBehaviour {

	// Use this for initialization
	void Start () {
        RectTransform parent = gameObject.GetComponent<RectTransform>();
        GridLayoutGroup content = gameObject.GetComponent<GridLayoutGroup>();

        content.cellSize = new Vector2(parent.rect.width, 100);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
