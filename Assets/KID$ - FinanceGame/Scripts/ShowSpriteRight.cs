using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSpriteRight : MonoBehaviour {

	public Sprite sprite0;
	public Sprite sprite1;
	public Sprite sprite2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void click1()
	{
			GameObject go = new GameObject ("BronzeStar");
			go.transform.localScale += new Vector3 (22, 11, 0);
			go.transform.localPosition = new Vector3 (42, 8, 0);
			SpriteRenderer renderer = go.AddComponent<SpriteRenderer> ();
			renderer.sprite = sprite0;
	}
	public void click2()
	{
			GameObject go = new GameObject ("BronzeStar");
			go.transform.localScale += new Vector3 (22, 11, 0);
			go.transform.localPosition = new Vector3 (42, 8, 0);
			SpriteRenderer renderer = go.AddComponent<SpriteRenderer> ();
			renderer.sprite = sprite1;
	}
	public void click3()
	{
			GameObject go = new GameObject ("BronzeStar");
			go.transform.localScale += new Vector3 (22, 11, 0);
			go.transform.localPosition = new Vector3 (42, 8, 0);
			SpriteRenderer renderer = go.AddComponent<SpriteRenderer> ();
			renderer.sprite = sprite2;
	}
}
