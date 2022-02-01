using MoreMountains.Feedbacks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Used to go to next level
 * It might need collectable items as keys to unlock it
 */

namespace devlog98.Backdoor {

#pragma warning disable 649

    public class Door : MonoBehaviour, IMouse {
        [SerializeField] private List<CollectableItem> keys = new List<CollectableItem>(); // list of collectable items needed to use exit
        private bool doorUnlocked;

        [Header("Feedbacks")]
        [SerializeField] private MMFeedbacks doorLockedFeedback; // feedbacks
        [SerializeField] private string doorLockedHint;
        [SerializeField] private MMFeedbacks doorUnlockedFeedback;

        public void OnMouseDown(InputAction.CallbackContext context) {
            if (!doorUnlocked) {
                foreach (CollectableItem key in keys) {
                    if (!PlayerInventory.instance.Inventory().Contains(key)) {
                        doorLockedFeedback.PlayFeedbacks();
                        PlayerHUD.instance.ShowHint(doorLockedHint);
                        return;
                    }
                }

                foreach(CollectableItem key in keys){
                    //PlayerInventory.instance.RemoveItem(key);
                    doorUnlockedFeedback.PlayFeedbacks();
                    doorUnlocked = true;
                    return;
                }
            }
        }

        // unused methods
        public void OnMouseDrag(InputAction.CallbackContext context) { }
        public void OnMouseUp(InputAction.CallbackContext context) { }
    }
}