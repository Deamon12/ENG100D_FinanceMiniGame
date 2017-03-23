using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCreateScript : MonoBehaviour {


    public Button boyButton;
    public Button girlButton;

    public Button darkButton;
    public Button midButton;
    public Button lightButton;

    public Sprite selected;
    public Sprite unselected;

    public Button doneButton;

    private int genderSelected = 1;
    private int colorSelected = -1;

    private Color32 selectedColor = new Color32(133, 210, 52, 255);

    // Use this for initialization
    void Start () {

        boyButton.onClick.AddListener(boyClick);                //0
        girlButton.onClick.AddListener(girlClick);              //1
        

        darkButton.onClick.AddListener(darkClick);              //0
        midButton.onClick.AddListener(midClick);                //1
        lightButton.onClick.AddListener(lightClick);            //2

        doneButton.onClick.AddListener(doneClick);


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Gotta be a better way....

    private void girlClick()
    {
        genderSelected = 1;
        girlButton.GetComponent<Image>().sprite = selected;
        boyButton.GetComponent<Image>().sprite = unselected;
    }

    private void boyClick()
    {
        genderSelected = 0;
        boyButton.GetComponent<Image>().sprite = selected;
        girlButton.GetComponent<Image>().sprite = unselected;
    }

    private void darkClick()
    {
        colorSelected = 0;
        darkButton.GetComponent<Image>().color = selectedColor;
        midButton.GetComponent<Image>().color = Color.white;
        lightButton.GetComponent<Image>().color = Color.white;
    }

    private void midClick()
    {
        colorSelected = 1;
        darkButton.GetComponent<Image>().color = Color.white;
        midButton.GetComponent<Image>().color = selectedColor;
        lightButton.GetComponent<Image>().color = Color.white;
    }

    private void lightClick()
    {
        colorSelected = 2;
        darkButton.GetComponent<Image>().color = Color.white;
        midButton.GetComponent<Image>().color = Color.white;
        lightButton.GetComponent<Image>().color = selectedColor;
    }

    private void doneClick()
    {
        if(colorSelected != -1)
        {
            GameManager.instance.setPlayerOptions(genderSelected, colorSelected, colorSelected); //outfitIndex 0-2, the default skins. This will change with upgrades.
            gameObject.SetActive(false);
        }
        else
        {
            GameManager.instance.showErrorDialog("Please select a skin tone");
        }
        

    }

}
