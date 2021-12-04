using UnityEngine;

/*
 * Locks and unlocks Player
 */

namespace devlog98.Backdoor {

#pragma warning disable 649

    public class PlayerLock : MonoBehaviour {
        public static PlayerLock instance; // singleton reference

        [SerializeField] private bool isLocked; // current player state

        public bool IsLocked { get => isLocked; }

        // singleton setup
        private void Awake() {
            if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
            }
        }

        // turns player components on and off
        public void LockPlayer(bool lockState) {
            isLocked = lockState;
        }
    }
}