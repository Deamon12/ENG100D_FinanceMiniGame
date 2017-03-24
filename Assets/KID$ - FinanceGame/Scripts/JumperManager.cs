using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperManager : MonoBehaviour {

    public GameObject femalePlayer;
    public GameObject malePlayer;

    private int gender;         //1 for female
    private int skinColor;
    private int outfitIndex;        //9 = hazmat, 10 = snow

    public Material sunnySky;
    public Material snowSky;
    public Material fireSky;

    public GameObject toonLand;
    public GameObject lavaLand;
    public GameObject snowLand;



    void Start () {

       

        gender = GameManager.instance.getPlayerData().getGender();
        skinColor = GameManager.instance.getPlayerData().getSkinColor();
        outfitIndex = GameManager.instance.getPlayerData().getOutfitIndex();


        //gender = 1;         //test
        //outfitIndex = 9;    //test
        print("outfitIndex: "+outfitIndex );

        setupEnvironment();

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

    private void setupEnvironment()
    {
        if(outfitIndex == 9) //lava
        {
            RenderSettings.skybox = fireSky;
            toonLand.SetActive(false);
            snowLand.SetActive(false);
            lavaLand.SetActive(true);
        }
        else if(outfitIndex == 10) //snow
        {
            RenderSettings.skybox = snowSky;
            toonLand.SetActive(false);
            snowLand.SetActive(true);
            lavaLand.SetActive(false);
        }
        else
        {
            RenderSettings.skybox = sunnySky;
            toonLand.SetActive(true);
            snowLand.SetActive(false);
            lavaLand.SetActive(false);
        }


    }


    private void setMaleTextures()
    {
        
        malePlayer.transform.FindChild("NoGlasses").transform.GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = GameManager.instance.maleBodyList[outfitIndex];
        malePlayer.transform.FindChild("NoGlasses").transform.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = GameManager.instance.maleFaceList[skinColor];

        //TODO
        //malePlayer.transform.FindChild("NoGlasses").transform.GetComponent<SkinnedMeshRenderer>().materials[0] = GameManager.instance.getPlayerData().getBodyMaterial();
        //malePlayer.transform.FindChild("NoGlasses").transform.GetComponent<SkinnedMeshRenderer>().materials[1] = GameManager.instance.getPlayerData().getFaceMaterial();
    }

    private void setFemaleTextures()
    {
        
        femalePlayer.transform.FindChild("FemaleModel").transform.GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = GameManager.instance.femaleFaceList[skinColor];      //face
        femalePlayer.transform.FindChild("FemaleModel").transform.GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = GameManager.instance.femaleFaceList[skinColor];      //face
        femalePlayer.transform.FindChild("FemaleModel").transform.GetComponent<SkinnedMeshRenderer>().materials[2].mainTexture = GameManager.instance.femaleBodyList[outfitIndex];      //Body
        
    }

}
