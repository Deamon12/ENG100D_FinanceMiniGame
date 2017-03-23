using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperManager : MonoBehaviour {

    public GameObject femalePlayer;
    public GameObject malePlayer;

    private int gender;         //1 for female
    private int skinColor;
    private int outfitIndex;
    

    void Start () {
        gender = GameManager.instance.getPlayerData().getGender();
        skinColor = GameManager.instance.getPlayerData().getSkinColor();
        outfitIndex = GameManager.instance.getPlayerData().getOutfitIndex();

        //print("Gender: "+gender);
        //print("skinColor: " + skinColor);
        //print("outfitIndex: " + outfitIndex);
        
        if (gender == 1)
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
        

    }

    private void setMaleTextures()
    {
        
        malePlayer.transform.FindChild("NoGlasses").transform.GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = GameManager.instance.maleBodyList[outfitIndex];
        malePlayer.transform.FindChild("NoGlasses").transform.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = GameManager.instance.maleFaceList[outfitIndex];

        //TODO
        //malePlayer.transform.FindChild("NoGlasses").transform.GetComponent<SkinnedMeshRenderer>().materials[0] = GameManager.instance.getPlayerData().getBodyMaterial();
        //malePlayer.transform.FindChild("NoGlasses").transform.GetComponent<SkinnedMeshRenderer>().materials[1] = GameManager.instance.getPlayerData().getFaceMaterial();
    }

    private void setFemaleTextures()
    {
        
        femalePlayer.transform.FindChild("FemaleModel").transform.GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = GameManager.instance.femaleFaceList[outfitIndex];      //face
        femalePlayer.transform.FindChild("FemaleModel").transform.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = GameManager.instance.femaleFaceList[outfitIndex];      //face
        femalePlayer.transform.FindChild("FemaleModel").transform.GetComponent<SkinnedMeshRenderer>().materials[2].mainTexture = GameManager.instance.femaleBodyList[outfitIndex];      //Body
        

    }

}
