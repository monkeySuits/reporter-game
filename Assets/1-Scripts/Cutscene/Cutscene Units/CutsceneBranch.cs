using devlog98.Backdoor;
using System;
using System.Collections.Generic;
using UnityEngine;

/*
 * Branches main cutscene on multiple different cutscenes, based on Collectable Items the Player is carrying
 * 
 * The order of check is the same as in the Inspector, so you need to put the default cutscene (one without conditions) as the last one
 */

namespace MSuits.Cutscene.Unit {
    public class CutsceneBranch : CutsceneUnit {
        [SerializeField] private List<CutsceneBranchPath> cutscenePaths;
        private Cutscene currentCutscene;

        public override void ExecuteStart() {
            bool unlockedCutscene = false;
            foreach (CutsceneBranchPath cutscenePath in cutscenePaths) {
                unlockedCutscene = true;

                foreach (CollectableItem key in cutscenePath.keys) {
                    if (!PlayerInventory.instance.Inventory().Contains(key)) {
                        unlockedCutscene = false;
                        break;
                    }
                }

                if (unlockedCutscene) {
                    currentCutscene = cutscenePath.cutscene;
                    break;
                }
            }

            if (currentCutscene != null) {
                currentCutscene.StartCutscene();
            }
            else {
                isFinished = true;
            }
        }

        public override void ExecuteUpdate() {
            if (currentCutscene != null && !currentCutscene.hasStarted) {
                isFinished = true;
            }
        }

        // unused methods
        public override void ExecuteEnd() { }

        /*
         * Cutscene container to be used solely by Cutscene Branch
         * It has a cutscene and its respective conditions to be played, as keys
         */
        [Serializable]
        public class CutsceneBranchPath {
            public Cutscene cutscene;
            public List<CollectableItem> keys;
        }
    }
}