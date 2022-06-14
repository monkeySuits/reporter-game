using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using UnityEngine.SceneManagement;

public class MenuSaveHandler : MonoBehaviour
{

    MMSaveLoadTester saveScript;
    
    void Start()
    {
        saveScript = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<MMSaveLoadTester>();
        FirstSave();
    }

    void FirstSave(){
        saveScript.saveIndex = 0;
        saveScript.Save();
    }

    public void EnterLoadGame(){
        saveScript.saveIndex = 1;
        saveScript.Load();
        SceneManager.LoadScene(saveScript.SaveObject.curLevelIndex);

    }

    public void EnterNewGame(){
        saveScript.saveIndex = 1;
        saveScript.Save();

        SceneManager.LoadScene(1);
    }
    
}
