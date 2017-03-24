using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeUIManager : MonoBehaviour {

	private PlayerData player;

	public Text balance;

	public GameObject girlView;
	public GameObject boyView;

	//Boy panels
	public GameObject bp0;
	public GameObject bp1;
	public GameObject bp2;
	public GameObject bp3;

	//Girl panels
	public GameObject gp0;
	public GameObject gp1;
	public GameObject gp2;
	public GameObject gp3;

	// Use this for initialization
	void Start () {
		player = GameManager.instance.getPlayerData();

        balance.text = formatCurrencyString(GameManager.instance.getPlayerData().getBalance());
        //? panels = girlView.GetComponents<upgradePanel>();

		balance.text = "Total: $" + player.getBalance();

		if (player.getGender() == 1) //female = 1
        {
            showGirlView();
			//dark
			if (player.getSkinColor () == 0) {
				setFemaleTexture (gp0, 3, 0);
				setFemaleTexture (gp1, 6, 0);
				setFemaleTexture (gp2, 9, 0);
				setFemaleTexture (gp3, 10, 0);
			}
			//medium
			else if (player.getSkinColor () == 1) {
				setFemaleTexture (gp0, 4, 1);
				setFemaleTexture (gp1, 7, 1);
				setFemaleTexture (gp2, 9, 1);
				setFemaleTexture (gp3, 10, 1);
			}
			//light
			else {
				setFemaleTexture (gp0, 5, 2);
				setFemaleTexture (gp1, 8, 2);
				setFemaleTexture (gp2, 9, 2);
				setFemaleTexture (gp3, 10, 2);
			}
        }
        else
        {
            showBoyView();
			//dark
			if (player.getSkinColor () == 0) {
				setMaleTexture (bp0, 3, 0);
				setMaleTexture (bp1, 6, 0);
				setMaleTexture (bp2, 9, 0);
				setMaleTexture (bp3, 10, 0);
			}
			//medium
			else if (player.getSkinColor () == 1) {
				setMaleTexture (bp0, 4, 1);
				setMaleTexture (bp1, 7, 1);
				setMaleTexture (bp2, 9, 1);
				setMaleTexture (bp3, 10, 1);
			}
			//light
			else {
				setMaleTexture (bp0, 5, 2);
				setMaleTexture (bp1, 8, 2);
				setMaleTexture (bp2, 9, 2);
				setMaleTexture (bp3, 10, 2);
			}
        }

		/*
		//dark
		if (player.getSkinColor () == 0) {
			setMaleTexture (bp0, 0, 0);
			setMaleTexture (bp1, 0, 0);
			setMaleTexture (bp2, 0, 0);
			setMaleTexture (bp3, 0, 0);
		}
		//medium
		else if (player.getSkinColor () == 1) {
			setMaleTexture (bp0, 0, 1);
			setMaleTexture (bp1, 0, 1);
			setMaleTexture (bp2, 0, 1);
			setMaleTexture (bp3, 0, 1);
		}
		//light
		else {
			setMaleTexture (bp0, 0, 2);
			setMaleTexture (bp1, 0, 2);
			setMaleTexture (bp2, 0, 2);
			setMaleTexture (bp3, 0, 2);
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
        

	}

	private void showGirlView() {
        girlView.SetActive(true);
        boyView.SetActive(false);
	}

	private void showBoyView() {
        girlView.SetActive(false);
        boyView.SetActive(true);
	}
		
	private void setUpgrades() {

	}

	private void buyItem() {
		
	}

    private String formatCurrencyString(float amount)
    {
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.CurrencyNegativePattern = 1;
        return amount.ToString("C2", nfi);
    }

	private void setMaleTexture(GameObject player, int outfitIndex, int skinColor)
	{

		player.transform.FindChild("NoGlasses").transform.GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = GameManager.instance.maleBodyList[outfitIndex];
		player.transform.FindChild("NoGlasses").transform.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = GameManager.instance.maleFaceList[skinColor];

	}

	private void setFemaleTexture(GameObject player, int outfitIndex, int skinColor)
	{

		player.transform.FindChild("FemaleModel").transform.GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = GameManager.instance.femaleFaceList[skinColor];      //face
		player.transform.FindChild("FemaleModel").transform.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = GameManager.instance.femaleFaceList[skinColor];      //face
		player.transform.FindChild("FemaleModel").transform.GetComponent<SkinnedMeshRenderer>().materials[2].mainTexture = GameManager.instance.femaleBodyList[outfitIndex];      //Body

	}

}
