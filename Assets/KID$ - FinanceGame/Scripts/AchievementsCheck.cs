using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsCheck : MonoBehaviour {

	public GameObject myRichesText;
	public GameObject bigPlayerText;
	public GameObject shopaholicText;
	public GameObject responsibleText;
	public GameObject clumsynessText;
	public GameObject iGotPowerText;
    public GameObject myRichesStars;
	public GameObject bigPlayerStars;
	public GameObject shopaholicStars;
	public GameObject responsibleStars;
	public GameObject clumsynessStars;
	public GameObject iGotPowerStars;
    public Sprite oneStar;
    public Sprite twoStars;
    public Sprite threeStars;


    // Use this for initialization
    void Start () {

		/*
		//setup the text counter under each achievement category dynmacially 
		Text myRichesCounter = myRichesText.GetComponent<Text> ();
		myRichesCounter.text = GameManager.instance.getPlayerData().getBalance().ToString() + "/100";
		Text bigPlayerCounter = bigPlayerText.GetComponent<Text> ();
		bigPlayerCounter.text = GameManager.instance.getPlayerData().getBalance().ToString() + "/6";
		Text shopaholicCounter = shopaholicText.GetComponent<Text> ();
		shopaholicCounter.text = GameManager.instance.getPlayerData().getBalance().ToString() + "/100";
		Text responsiblCounter = responsibleText.GetComponent<Text> ();
		responsiblCounter.text = GameManager.instance.getPlayerData().getBalance().ToString() + "/30";
		Text clumsynessCounter = clumsynessText.GetComponent<Text> ();
		clumsynessCounter.text = GameManager.instance.getPlayerData().getBalance().ToString() + "/10";
		Text iGotPowerCounter = iGotPowerText.GetComponent<Text> ();
		iGotPowerCounter.text = GameManager.instance.getPlayerData().getBalance().ToString() + "/20";
		*/

		//test
		Text myRichesCounter = myRichesText.GetComponent<Text> ();
		myRichesCounter.text = "102" + "/100";
		Text bigPlayerCounter = bigPlayerText.GetComponent<Text> ();
		bigPlayerCounter.text = "5" + "/6";
		Text shopaholicCounter = shopaholicText.GetComponent<Text> ();
		shopaholicCounter.text = "40" + "/100";
		Text responsiblCounter = responsibleText.GetComponent<Text> ();
		responsiblCounter.text = "15" + "/30";
		Text clumsynessCounter = clumsynessText.GetComponent<Text> ();
		clumsynessCounter.text = "7" + "/10";
		Text iGotPowerCounter = iGotPowerText.GetComponent<Text> ();
		iGotPowerCounter.text = "3" + "/20";




		//get the default star images
		Image myRichesImage = myRichesStars.GetComponent<Image>();
		Image bigPlayerImage = bigPlayerStars.GetComponent<Image>();
		Image shopaholicImage = shopaholicStars.GetComponent<Image>();
		Image responsibleImage = responsibleStars.GetComponent<Image>();
		Image clumsynessImage = clumsynessStars.GetComponent<Image>();
		Image iGotPowerImage = iGotPowerStars.GetComponent<Image>();

		/*
		//get the counter for each achievement in playerData
		float myRiches = GameManager.instance.getPlayerData().getBalance();
		float bigPlayer = GameManager.instance.getPlayerData().getBalance();
		float shopaholic = GameManager.instance.getPlayerData().getBalance();
		float responsible = GameManager.instance.getPlayerData().getBalance();
		float clumsyness = GameManager.instance.getPlayerData().getBalance();
		float iGotPower = GameManager.instance.getPlayerData().getBalance();
		*/
		//testing
		float myRiches = 102;
		float bigPlayer = 5;
		float shopaholic = 40;
		float responsible = 15;
		float clumsyness = 7;
		float iGotPower = 3;

		//checks for total money earned
		if (myRiches >= 4.0 && myRiches < 34.0)
            myRichesImage.sprite = oneStar;
		else if (myRiches >= 34.0 && myRiches < 100.0)
            myRichesImage.sprite = twoStars;
        else
            myRichesImage.sprite = threeStars;
		
		//checks for the max of money earned in one game
		if (bigPlayer >= 2.0 && bigPlayer < 4.0)
			bigPlayerImage.sprite = oneStar;
		else if (bigPlayer >= 4.0 && bigPlayer < 6.0)
			bigPlayerImage.sprite = twoStars;
		else
			bigPlayerImage.sprite = threeStars;
		
		//checks for money spent
		if (shopaholic >= 4.0 && shopaholic < 34.0)
			shopaholicImage.sprite = oneStar;
		else if (shopaholic >= 34.0 && shopaholic < 100.0)
			shopaholicImage.sprite = twoStars;
		else
			shopaholicImage.sprite = threeStars;
		
		//checks for number of bills paid
		if (responsible >= 5 && responsible < 10.0)
			responsibleImage.sprite = oneStar;
		else if (responsible >= 15.0 && responsible < 30.0)
			responsibleImage.sprite = twoStars;
		else
			responsibleImage.sprite = threeStars;
		
		//checks for number of deaths in total
		if (clumsyness>= 2.0 && clumsyness < 5.0)
			clumsynessImage.sprite = oneStar;
		else if (clumsyness >= 5.0 && clumsyness < 10.0)
			clumsynessImage.sprite = twoStars;
		else
			clumsynessImage.sprite = threeStars;
		
		//checks for number of upgrades purchased
		if (iGotPower >= 3.0 && iGotPower < 8.0)
			iGotPowerImage.sprite = oneStar;
		else if (iGotPower >= 8 && iGotPower < 20.0)
			iGotPowerImage.sprite = twoStars;
		else
			iGotPowerImage.sprite = threeStars;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
