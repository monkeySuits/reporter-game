using MoreMountains.Feedbacks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MoreMountains.Tools;

/*
 * Used to go to next level
 * It might need collectable items as keys to unlock it
 */

namespace devlog98.Backdoor {

#pragma warning disable 649

    public class Door : MonoBehaviour, IMouse {
        [SerializeField] private List<CollectableItem> keys = new List<CollectableItem>(); // list of collectable items needed to use exit
        private bool doorUnlocked;
        public string flagName;
        [SerializeField] private string doorLockedHint;
        FlagSaver flagSaver;
        MMSaveLoadTester saveManager;

        [Header("Feedbacks")]
        [SerializeField] private MMFeedbacks doorLockedFeedback; // feedbacks
        [SerializeField] private MMFeedbacks doorUnlockedFeedback;
        [SerializeField] private MMFeedbacks doorLoadFeedback;

        private void Start() {
            flagSaver = this.GetComponent<FlagSaver>();
            saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<MMSaveLoadTester>();
            LoadFlag();
        }
        public void OnMouseDown(InputAction.CallbackContext context) {
            if (!doorUnlocked) {
                foreach (CollectableItem key in keys) {
                    if (!PlayerInventory.instance.Inventory().Contains(key)) {
                        doorLockedFeedback.PlayFeedbacks();
                        PlayerHUD.instance.ShowHint(doorLockedHint);
                        return;
                    }
                }
                //PlayerInventory.instance.RemoveItem(key);
                doorUnlockedFeedback.PlayFeedbacks();
                doorUnlocked = true;

                // Set flag status then save
                flagSaver.SaveFlag(flagName);
            }
        }

        public void LoadFlag(){
            // Find if flag is already done in List of Flags in level, then Load
            int length = saveManager.SaveObject.levels[saveManager.SaveObject.curLevel].progressionFlags.Count;

            for (int i = 0; i < length; i++)
            {
                if (saveManager.SaveObject.levels[saveManager.SaveObject.curLevel].progressionFlags[i].name == flagName)
                {
                    if(saveManager.SaveObject.levels[saveManager.SaveObject.curLevel].progressionFlags[i].done == true){
                        doorLoadFeedback.PlayFeedbacks();
                        doorUnlocked = true;
                        break;
                    }

                }
            }
        }

        // unused methods
        public void OnMouseDrag(InputAction.CallbackContext context) { }
        public void OnMouseUp(InputAction.CallbackContext context) { }
    }
}