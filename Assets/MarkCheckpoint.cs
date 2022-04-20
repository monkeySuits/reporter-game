using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

public class MarkCheckpoint : MonoBehaviour
{
    MMSaveLoadTester saveScript;
    public Vector3 checkpointPos;
    // Start is called before the first frame update
    void Start()
    {
        saveScript = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<MMSaveLoadTester>();
    }

    public void SaveCheckpoint(){
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
       saveScript.SaveObject.posX =  checkpointPos.x;
       saveScript.SaveObject.posY =  checkpointPos.y;
       saveScript.SaveObject.posZ =  checkpointPos.z;

       saveScript.Save();
    }


}
