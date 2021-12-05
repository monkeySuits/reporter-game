using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Collectables used to go through level exit
 */

namespace devlog98.Backdoor {

#pragma warning disable 649

    public class CollectableItem : MonoBehaviour, IMouse {
        [Header("Feedbacks")]
        [SerializeField] private MMFeedbacks collectFeedback; // feedbacks
        [SerializeField] private string collectHint;

        // be collected by player
        public void OnMouseDown(InputAction.CallbackContext context) {
            collectFeedback.PlayFeedbacks();
            PlayerHUD.instance.ShowHint(collectHint);
            PlayerInventory.instance.CollectableFound(this);
        }

        // unused methods
        public void OnMouseDrag(InputAction.CallbackContext context) { }
        public void OnMouseUp(InputAction.CallbackContext context) { }
    }
}