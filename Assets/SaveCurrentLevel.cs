using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using UnityEngine.SceneManagement;

public class SaveCurrentLevel : MonoBehaviour
{

    public int level;
    MMSaveLoadTester saveManager;

    private void Start() {
        saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<MMSaveLoadTester>();
        SaveLevel();
    }
    public void SaveLevel(){
        saveManager.SaveObject.curLevel = level;
        saveManager.SaveObject.curLevelIndex = SceneManager.GetActiveScene().buildIndex;

    }
}
