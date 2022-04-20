using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;

public class LoadStartingPosition : MonoBehaviour
{

    // public void LoadPosition
    public Transform player;
    public MMFeedbacks loadInFeed;


    // called first
    private void Start() {
        loadInFeed.PlayFeedbacks();
    }


    public void PositionPlayer(){
       MMSaveLoadTester saveScript = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<MMSaveLoadTester>();
       player.transform.position = new Vector3(saveScript.SaveObject.posX, saveScript.SaveObject.posY, saveScript.SaveObject.posZ);
        Debug.Log("Load Player Pos: " + saveScript.SaveObject.posX + " " + saveScript.SaveObject.posY + " " + saveScript.SaveObject.posZ);
    }

}
