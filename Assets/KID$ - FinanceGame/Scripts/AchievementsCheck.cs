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
	public Text msg;

    public GameObject myRichesStars;
	public GameObject bigPlayerStars;
	public GameObject shopaholicStars;
	public GameObject responsibleStars;
	public GameObject clumsynessStars;
	public GameObject iGotPowerStars;

	public GameObject myRichesRibbon;
	public GameObject bigPlayerRibbon;
	public GameObject shopaholicRibbon;
	public GameObject responsibleRibbon;
	public GameObject clumsynessRibbon;
	public GameObject iGotPowerRibbon;
	public GameObject[] ribbons = new GameObject[6];

    public Sprite oneStar;
    public Sprite twoStars;
    public Sprite threeStars;

	private const float LEVEL_ONE_REWARD = 4;
	private const float LEVEL_TWO_REWARD = 8;
	private const float LEVEL_THREE_REWARD = 20;

    // Use this for initialization
    void Start () {
		
        //setup the ribbons accoringdly
		ribbons[0] = myRichesRibbon;
		ribbons[1] = bigPlayerRibbon;
		ribbons[2] = shopaholicRibbon;
		ribbons[3] = responsibleRibbon;
		ribbons[4] = clumsynessRibbon;
		ribbons[5] = iGotPowerRibbon;

		//setup the text counter under each achievement category dynmacially 
		Text myRichesCounter = myRichesText.GetComponent<Text> ();
		myRichesCounter.text = GameManager.instance.getPlayerData().getTotalMoneyEarned().ToString() + "/100";
		Text bigPlayerCounter = bigPlayerText.GetComponent<Text> ();
		bigPlayerCounter.text = GameManager.instance.getPlayerData().getHighestAmountCollected().ToString() + "/6";
		Text shopaholicCounter = shopaholicText.GetComponent<Text> ();
		shopaholicCounter.text = GameManager.instance.getPlayerData().getMoneySpent().ToString() + "/100";
		Text responsiblCounter = responsibleText.GetComponent<Text> ();
		responsiblCounter.text = GameManager.instance.getPlayerData().getNumOfBillsPaid().ToString()  + "/30";
		Text clumsynessCounter = clumsynessText.GetComponent<Text> ();
		clumsynessCounter.text = GameManager.instance.getPlayerData().getNumOfCollisions().ToString() + "/10";
		Text iGotPowerCounter = iGotPowerText.GetComponent<Text> ();
		iGotPowerCounter.text = GameManager.instance.getPlayerData().getNumUpgrade().ToString() + "/20";

		//get the default star images
		Image myRichesImage = myRichesStars.GetComponent<Image>();
		Image bigPlayerImage = bigPlayerStars.GetComponent<Image>();
		Image shopaholicImage = shopaholicStars.GetComponent<Image>();
		Image responsibleImage = responsibleStars.GetComponent<Image>();
		Image clumsynessImage = clumsynessStars.GetComponent<Image>();
		Image iGotPowerImage = iGotPowerStars.GetComponent<Image>();

		//get the counter for each achievement in playerData
		float myRiches = GameManager.instance.getPlayerData().getTotalMoneyEarned();
		float bigPlayer = GameManager.instance.getPlayerData().getHighestAmountCollected();
		float shopaholic = GameManager.instance.getPlayerData().getMoneySpent();
		float responsible = GameManager.instance.getPlayerData().getNumOfBillsPaid();
		float clumsyness = GameManager.instance.getPlayerData().getNumOfCollisions();
		float iGotPower = GameManager.instance.getPlayerData().getNumUpgrade();

		//checks for total money earned
		if (myRiches >= 4.0 && myRiches < 34.0) {
			Debug.Log ("in here 1");
			myRichesImage.sprite = oneStar;
			distributeReward (0, LEVEL_ONE_REWARD);
		} else if (myRiches >= 34.0 && myRiches < 100.0) {
			myRichesImage.sprite = twoStars;
			distributeReward (1, LEVEL_TWO_REWARD);
		} else if (myRiches >= 100.0) {
			myRichesImage.sprite = threeStars;
			distributeReward (2, LEVEL_THREE_REWARD);
		}
		
		//checks for the max of money earned in one game
		if (bigPlayer >= 2.0 && bigPlayer < 4.0){
			bigPlayerImage.sprite = oneStar;
			distributeReward (3, LEVEL_ONE_REWARD);
		} else if (bigPlayer >= 4.0 && bigPlayer < 6.0){
			bigPlayerImage.sprite = twoStars;
			distributeReward (4, LEVEL_TWO_REWARD);
		} else if (bigPlayer >= 6.0){
            bigPlayerImage.sprite = threeStars;
			distributeReward (5, LEVEL_THREE_REWARD);
		}

		//checks for money spent
		if (shopaholic >= 4.0 && shopaholic < 34.0) {
			shopaholicImage.sprite = oneStar;
			distributeReward (6, LEVEL_ONE_REWARD);
		} else if (shopaholic >= 34.0 && shopaholic < 100.0) {
			shopaholicImage.sprite = twoStars;
			distributeReward (7, LEVEL_TWO_REWARD);
		}  else if (shopaholic >= 100.0){
            shopaholicImage.sprite = threeStars;
			distributeReward (8, LEVEL_THREE_REWARD);
		}
		
		//checks for number of bills paid
		if (responsible >= 5 && responsible < 15.0){
			responsibleImage.sprite = oneStar;
			distributeReward (9, LEVEL_ONE_REWARD);
		} else if (responsible >= 15.0 && responsible < 30.0){
			responsibleImage.sprite = twoStars;
			distributeReward (10, LEVEL_TWO_REWARD);
		} else if (responsible >= 30.0){
            responsibleImage.sprite = threeStars;
			distributeReward (11, LEVEL_THREE_REWARD);
		}
		
		//checks for number of deaths in total
		if (clumsyness>= 2.0 && clumsyness < 5.0){
			clumsynessImage.sprite = oneStar;
			distributeReward (12, LEVEL_ONE_REWARD);
		} else if (clumsyness >= 5.0 && clumsyness < 10.0){
			clumsynessImage.sprite = twoStars;
			distributeReward (13, LEVEL_TWO_REWARD);
		} else if (clumsyness >= 10.0){
            clumsynessImage.sprite = threeStars;
			distributeReward (14, LEVEL_THREE_REWARD);
		}
		
		//checks for number of upgrades purchased
		if (iGotPower >= 3.0 && iGotPower < 8.0){
			iGotPowerImage.sprite = oneStar;
			distributeReward (15, LEVEL_ONE_REWARD);
		} else if (iGotPower >= 8 && iGotPower < 20.0){
			iGotPowerImage.sprite = twoStars;
			distributeReward (16, LEVEL_TWO_REWARD);
		} else if (iGotPower >= 20.0){
            iGotPowerImage.sprite = threeStars;
			distributeReward (17, LEVEL_THREE_REWARD);
		}
    }

	// Update is called once per frame
	void Update () {
		
	}

	private void distributeReward(int i, float rewardMoney){
		bool temp = GameManager.instance.getPlayerData ().getRewardsClaimed (i);
		Debug.Log ("in here 1.5");
		if (temp == false) {
			Debug.Log ("in here 2");
			ribbons[i/3].GetComponent<Button>().interactable = true; 
			ribbons[i/3].GetComponent<Button>().onClick.AddListener(() => addMoneyOnClick(i, rewardMoney));
		}
	}

	private void addMoneyOnClick(int i, float tempMoney){
		Debug.Log ("added Money: " + tempMoney);
		BankEntry tempEntry = new BankEntry (tempMoney, "Reward", true);                  //create a temporary entry to add,set isReward to true
		GameManager.instance.getPlayerData ().addBankEntry (tempEntry);         //add the temp entry to the player BankEntry
		GameManager.instance.getPlayerData ().setRewardsClaimed (i,true);		//set the rewardsClaimed[i] to true;
		ribbons[i/3].GetComponent<Button>().onClick.RemoveListener(() => something());
		ribbons[i/3].GetComponent<Button>().interactable = false; 				//disable the button
		StartCoroutine ( ShowPopup ("you just got $" + tempMoney + " as a reward", 4));
	}
		
	IEnumerator ShowPopup (string message, float delay)
	{
		msg.GetComponent<Text>().text = message;
		msg.GetComponent<Text>().enabled = true;
		yield return new WaitForSeconds (delay);
		msg.GetComponent<Text>().enabled = false;
	}

	public void something()
	{
		Debug.Log("listener destoryed");
	}

	void Destroy()
	{
		ribbons[0].GetComponent<Button>().onClick.RemoveListener(() => something());
		ribbons[1].GetComponent<Button>().onClick.RemoveListener(() => something());
		ribbons[2].GetComponent<Button>().onClick.RemoveListener(() => something());
		ribbons[3].GetComponent<Button>().onClick.RemoveListener(() => something());
		ribbons[4].GetComponent<Button>().onClick.RemoveListener(() => something());
		ribbons[5].GetComponent<Button>().onClick.RemoveListener(() => something());
	}
		
}
