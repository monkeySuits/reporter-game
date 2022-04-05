using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
public class FlagSaver : MonoBehaviour
{
    MMSaveLoadTester saveManager;
    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<MMSaveLoadTester>();

    }

    public void SaveFlag(string flagName)
    {
        // Find Acquired Item in List of Objects in level, then Save
        int length = saveManager.SaveObject.levels[saveManager.SaveObject.curLevel].progressionFlags.Count;

        for (int i = 0; i < length; i++)
        {
            if (saveManager.SaveObject.levels[saveManager.SaveObject.curLevel].progressionFlags[i].name == flagName)
            {
                saveManager.SaveObject.levels[saveManager.SaveObject.curLevel].progressionFlags[i].done = true;
                saveManager.Save();
                break;
            }
        }
    }
}
