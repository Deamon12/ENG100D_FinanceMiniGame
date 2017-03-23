using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperManager : MonoBehaviour {

    public GameObject femalePlayer;
    public GameObject malePlayer;

    //public Material[] testList;

    private int gender;         //1 for female
    
	void Start () {
        gender = GameManager.instance.getPlayerData().getGender();

        gender = 1;

        if(gender == 1)
        {
            femalePlayer.SetActive(true);
            malePlayer.SetActive(false);
            setFemaleTextures();
        }
        else
        {
            femalePlayer.SetActive(false);
            malePlayer.SetActive(true);
            setMaleTextures();

        }
        

    }
	
	void Update () {

        //int selection = Random.Range(0, testList.Length);
        //malePlayer.transform.FindChild("NoGlasses").transform.GetComponent<SkinnedMeshRenderer>().material = testList[selection];
       

    }

    private void setMaleTextures()
    {
        //int selection = Random.Range(0, testList.Length);
        //maleModel.GetComponent<SkinnedMeshRenderer>().materials[0] = testList[selection];


        malePlayer.transform.FindChild("NoGlasses").transform.GetComponent<SkinnedMeshRenderer>().materials[0] = GameManager.instance.getPlayerData().getBodyMaterial();
        malePlayer.transform.FindChild("NoGlasses").transform.GetComponent<SkinnedMeshRenderer>().materials[1] = GameManager.instance.getPlayerData().getFaceMaterial();
    }

    private void setFemaleTextures()
    {
        femalePlayer.transform.FindChild("FemaleModel").transform.GetComponent<SkinnedMeshRenderer>().materials[0] = GameManager.instance.getPlayerData().getBodyMaterial();
        femalePlayer.transform.FindChild("FemaleModel").transform.GetComponent<SkinnedMeshRenderer>().materials[1] = GameManager.instance.getPlayerData().getFaceMaterial();
       // femalePlayer.transform.FindChild("FemaleModel").transform.GetComponent<SkinnedMeshRenderer>().material = testList[2];
    }

}
