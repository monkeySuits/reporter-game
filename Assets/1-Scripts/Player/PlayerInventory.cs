using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for storing player collectable items
 */

namespace devlog98.Backdoor {

#pragma warning disable 649

    public class PlayerInventory : MonoBehaviour {
        public static PlayerInventory instance; // reference to singleton
        private List<CollectableItem> inventory = new List<CollectableItem>(); // list of collectable items

        // singleton setup
        private void Awake() {
            if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
            }
        }

        // store collected item on inventory
        public void CollectableFound(CollectableItem item) {
            inventory.Add(item);
            item.gameObject.SetActive(false);
        }

        // returns current inventory
        public List<CollectableItem> Inventory() {
            return inventory;
        }
    }
}