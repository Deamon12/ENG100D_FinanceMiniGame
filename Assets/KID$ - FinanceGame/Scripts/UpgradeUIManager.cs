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

	//Boy buttons
	public Button bb0;
	public Button bb1;
	public Button bb2;
	public Button bb3;

	//Girl buttons
	public Button gb0;
	public Button gb1;
	public Button gb2;
	public Button gb3;

	//Button prices
	public int price1 = 30;
	public int price2 = 50;
	public int price3 = 100;
	public int price4 = 100;

	// Use this for initialization
	void Start () {
		player = GameManager.instance.getPlayerData();

        balance.text = formatCurrencyString(GameManager.instance.getPlayerData().getBalance());
        //? panels = girlView.GetComponents<upgradePanel>();

		//balance.text = "Total: $" + player.getBalance();

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

		setUpgrades ();

	}
	
	// Update is called once per frame
	void Update () {
		setUpgrades ();
        //balance.text = "Total: $" + player.getBalance();
        balance.text = formatCurrencyString(GameManager.instance.getPlayerData().getBalance());

    }

    private void showGirlView() {
        girlView.SetActive(true);
        boyView.SetActive(false);
	}

	private void showBoyView() {
        girlView.SetActive(false);
        boyView.SetActive(true);
	}
		
	private void showError() {
		print ("error");
		GameManager.instance.showErrorDialog ("Not enough money");
	}

	private void setUpgrades() {
		//Panel 1
		if (player.getUpgradeIndex (0) == 0) {
			if (player.getBalance () < price1) {
				bb0.onClick.RemoveAllListeners ();
				bb0.onClick.AddListener (showError);
			} else {
				bb0.onClick.RemoveAllListeners ();
				bb0.onClick.AddListener (buyItem1);
			}
		} else {
			bb0.GetComponent<Text> ().text = "Set";
			bb0.onClick.RemoveAllListeners ();
			bb0.onClick.AddListener (chosenUpgrade1);
		}

		//Panel 2
		if (player.getUpgradeIndex (1) == 0) {
			if (player.getBalance () < price2) {
				bb1.onClick.RemoveAllListeners();
				bb1.onClick.AddListener (showError);
			} else {
				bb1.onClick.RemoveAllListeners();
				bb1.onClick.AddListener (buyItem2);
			}
		} else {
			bb1.GetComponent<Text> ().text = "Set";
			bb1.onClick.RemoveAllListeners();
			bb1.onClick.AddListener (chosenUpgrade2);
		}
			
		//Panel 3
		if (player.getUpgradeIndex (2) == 0) {
			if (player.getBalance () < price3) {
				bb2.onClick.RemoveAllListeners();
				bb2.onClick.AddListener (showError);
			} else {
				bb2.onClick.RemoveAllListeners();
				bb2.onClick.AddListener (buyItem3);
			}
		} else {
			bb2.GetComponent<Text> ().text = "Set";
			bb2.onClick.RemoveAllListeners();
			bb2.onClick.AddListener (chosenUpgrade3);
		}

		//Panel 4
		if (player.getUpgradeIndex (3) == 0) {
			if (player.getBalance () < price4) {
				bb3.onClick.RemoveAllListeners();
				bb3.onClick.AddListener (showError);
			} else {
				bb3.onClick.RemoveAllListeners();
				bb3.onClick.AddListener (buyItem4);
			}
		} else {
			//bb3.GetComponent<Text> ().text = "Set";
			bb3.onClick.RemoveAllListeners();
			bb3.onClick.AddListener (chosenUpgrade4);
		}
	}

	private void buyItem1() {
		BankEntry bought = new BankEntry (-price1, "Bought first upgrade", DateTime.Now);
		player.addBankEntry (bought);
		player.setUpgradeIndex (0);
	}

	private void buyItem2() {
		BankEntry bought = new BankEntry (-price2, "Bought second upgrade", DateTime.Now);
		player.addBankEntry (bought);
		player.setUpgradeIndex (1);
	}

	private void buyItem3() {
		BankEntry bought = new BankEntry (-price3, "Bought third upgrade", DateTime.Now);
		player.addBankEntry (bought);
		player.setUpgradeIndex (2);
	}

	private void buyItem4() {
		BankEntry bought = new BankEntry (-price4, "Upgrade4", DateTime.Now);
		player.addBankEntry (bought);
		player.setUpgradeIndex (3);
        chosenUpgrade4();
	}

	private void chosenUpgrade1() {
		//dark
		if (player.getSkinColor () == 0) {
			player.setOutfitIndex (3);
		}
		//medium
		else if (player.getSkinColor () == 1) {
			player.setOutfitIndex (4);
		}
		//light
		else {
			player.setOutfitIndex (5);
		}
	}

	private void chosenUpgrade2() {
		//dark
		if (player.getSkinColor () == 0) {
			player.setOutfitIndex (6);
		}
		//medium
		else if (player.getSkinColor () == 1) {
			player.setOutfitIndex (7);
		}
		//light
		else {
			player.setOutfitIndex (8);
		}
	}

	private void chosenUpgrade3() {
		player.setOutfitIndex (9);
	}
		
	private void chosenUpgrade4() {
        GameManager.instance.getPlayerData().setOutfitIndex(10); //player.setOutfitIndex (10);
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
        print("skincolor: "+skinColor);
		player.transform.FindChild("Female2_Pigtail").transform.GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = GameManager.instance.femaleFaceList[skinColor];      //face
		player.transform.FindChild("Female2_Pigtail").transform.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = GameManager.instance.femaleFaceList[skinColor];      //face
		player.transform.FindChild("Female2_Pigtail").transform.GetComponent<SkinnedMeshRenderer>().materials[2].mainTexture = GameManager.instance.femaleBodyList[outfitIndex];      //Body

	}

}
