using devlog98.Backdoor;
using UnityEngine;

/*
 * Locks or unlocks Player on cutscene
 */

namespace MSuits.Cutscene.Unit {
    public class CutscenePlayerLock : CutsceneUnit {
        [SerializeField] private bool lockPlayer;

        public override void ExecuteStart() {
            PlayerLock.instance.LockPlayer(lockPlayer);
            isFinished = true;
        }

        // unused methods
        public override void ExecuteUpdate() { }
        public override void ExecuteEnd() { }
    }
}