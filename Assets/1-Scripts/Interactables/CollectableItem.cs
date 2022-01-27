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
        [SerializeField] private Item item;

        // be collected by player
        public void OnMouseDown(InputAction.CallbackContext context) {
            Debug.Log("Pegou chave " + item.description);
            CollectItem();
        }

        // be given to player on event
        public void GivePlayer() {
            Debug.Log("Obteve " + item.description);
            CollectItem();
        }

        // put item on Player Inventory
        private void CollectItem() {
            collectFeedback.PlayFeedbacks();
            PlayerHUD.instance.ShowHint(item.collectHint);
            PlayerInventory.instance.CollectableFound(this);
            CreateInventory.instance.AddElement(this.GetComponent<CollectableItem>());
        }

        public Item getItem(){
            return item;
        }

        // unused methods
        public void OnMouseDrag(InputAction.CallbackContext context) { }
        public void OnMouseUp(InputAction.CallbackContext context) { }
    }
}