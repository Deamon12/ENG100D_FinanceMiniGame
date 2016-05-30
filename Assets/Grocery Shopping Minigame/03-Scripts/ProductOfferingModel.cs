using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

//part of Grocery game
public class ProductOfferingModel {
	enum TintColor {
		Red,
		Green,
		Blue,
	}

	//list used to quickly get the correct price for each item:
	static int[] BasePrices = { 2, 4, 5, 1, 5, 5, 1, 1, 2, 5, 3, 3, 2, 3, 4, 3, 2, 5, 3, 2, 4, 4, 1, 5 };
	static int[,] BrandPrices = new int[BasePrices.Length, 3];

	int[] prices;
	int productID;
	GameObject product;
	GameObject[] gameObjects;


	public ProductOfferingModel(GameObject prod, int prodId) {
		Debug.Log ("Creating offering with ID: " + prodId);
		productID = prodId;
		product = prod;
		gameObjects = generateGameObjects();
	}

	public GameObject[] getGameObjects() {
		return gameObjects;
	}

	public int getPriceForIndex(int idx) {
		return prices [idx];
	}

	private GameObject[] generateGameObjects() {
		// We'll have between 1 and 3 brands (can't fit more than 3 on screen)
		int numBrands = Random.Range(1, 4);
		GameObject[] retObjs = new GameObject[numBrands];
		prices = new int[numBrands];

		int basePrice = BasePrices[productID];

		Random rndGen = new Random ();
		// Generate a list of 0-2 shuffled, e.g. (0,1,2), (1,0,2), etc.
		ArrayList randomColors = generateRandomInts(0, 2);

		Vector3[] spawnPositions = getSpawnPositions (numBrands);
		for (int currBrand = 0; currBrand < numBrands; currBrand++) {
			GameObject obj = generateObject(product, spawnPositions[currBrand], currBrand);

			//Apply the tint
			obj.GetComponent<Renderer> ().material = generateTintMaterial((TintColor)randomColors[currBrand]);
            obj.name = obj.name + currBrand;
			retObjs[currBrand] = obj;

			if (BrandPrices [productID, (int)randomColors[currBrand]] > 0) {
				Debug.Log("Using Old Brand Price: " + BrandPrices [productID, (int)randomColors[currBrand]] + " for color: " + (int)randomColors[currBrand] + " for product: " + productID);
				prices [currBrand] = BrandPrices [productID, (int)randomColors[currBrand]];
			} else {
				// Add between $0 and $5 to the base price
				prices [currBrand] = basePrice + Random.Range (0, 6);
				BrandPrices [productID, (int)randomColors[currBrand]] = prices [currBrand];
				Debug.Log("Creating New Brand Price: " + BrandPrices [productID, (int)randomColors[currBrand]] + " for color: " + (int)randomColors[currBrand] + " for product: " + productID);
			}
		}

		return retObjs;
	}

	//Generate lis of random numbers inclusive of min and max with no repeats
	private ArrayList generateRandomInts(int min, int max) {
		ArrayList nums = new ArrayList ();
		while (nums.Count < (max - min + 1)) {
			int randNum = Random.Range (min, max + 1);
			if (!nums.Contains (randNum)) {
				nums.Add (randNum);
			}
		}
		return nums;
	}

	private Material generateTintMaterial(TintColor tintColor) {
		Color tint = new Color (0, 0, 0, 1); //default to white
		switch (tintColor) {
			case TintColor.Red:
			tint = new Color(1,0,0,1);
			break;

			case TintColor.Green:
			tint = new Color(0,1,0,1);
			break;

			case TintColor.Blue:
			tint = new Color(0,0,1,1);
			break;
		}

		Material newMaterial = new Material(Shader.Find("Sprites/Default"));
		newMaterial.color = tint;
		return newMaterial;
	}

	private GameObject generateObject(GameObject prod, Vector3 spawnPos, int brandNum) {
		GameObject newObj = (GameObject)GameObject.Instantiate(prod, spawnPos, new Quaternion());
		Text text = newObj.AddComponent<Text>();
		text.text = "$" + prices [brandNum];
					text.fontSize = 20;
					text.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
					text.color = Color.red;
		((ProductAction)newObj.GetComponent<ProductAction>()).brandId = brandNum;
		return newObj;
	}

	public static Vector3[] getSpawnPositions(int numPositions) {
		Vector3[] spawnPositions = null;
		if (numPositions == 1) {
			spawnPositions = new [] {new Vector3(0,3,0)};
		} else if (numPositions == 2) {
			spawnPositions = new [] {new Vector3(0,3,0), new Vector3(0,1,0)};
		} else if (numPositions == 3) {
			spawnPositions = new [] {new Vector3(0,3,0), new Vector3(0,1,0), new Vector3(0,-1,0) };
		}

		return spawnPositions;
	}
}
