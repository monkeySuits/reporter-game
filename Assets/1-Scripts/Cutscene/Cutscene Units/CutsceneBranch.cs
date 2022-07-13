using MoreMountains.Tools;
using System;
using System.Collections.Generic;
using UnityEngine;

/*
 * Branches main cutscene on multiple different cutscenes, based on Collectable Items the Player is carrying
 * 
 * The order of check is the same as in the Inspector, so you need to put the default cutscene (one without conditions) as the last one
 * The exception is when you want a cutscene to always play first. Then you put it as the first one and fill the Play Only Once Flag for it to play ignoring conditions (only once)
 */

namespace MSuits.Cutscene.Unit {
    public class CutsceneBranch : CutsceneUnit {
        [SerializeField] private List<CutsceneBranchPath> cutscenePaths;
        private CutsceneBranchPath currentPath;

        public override void ExecuteStart() {
            bool unlockedCutscene = false;
            foreach (CutsceneBranchPath cutscenePath in cutscenePaths) {
                unlockedCutscene = true;

                if (cutscenePath.LoadProgression()) {
                    unlockedCutscene = false;
                    continue;
                }

                unlockedCutscene = cutscenePath.CheckConditions();

                if (unlockedCutscene) {
                    currentPath = cutscenePath;
                    break;
                }
            }

            if (currentPath != null) {
                currentPath.cutscene.StartCutscene();
            }
            else {
                isFinished = true;
            }
        }

        public override void ExecuteUpdate() {
            if (currentPath.cutscene != null && !currentPath.cutscene.hasStarted) {
                currentPath.SaveProgression();
                isFinished = true;
            }
        }

        // unused methods
        public override void ExecuteEnd() { }

        /*
         * Cutscene container to be used solely by Cutscene Branch
         */
        [Serializable]
        public class CutsceneBranchPath {
            public Cutscene cutscene; // cutscene to be played
            public string playOnlyOnceFlag; // if filled, this guarantees cutscene will only play once and then a flag will be saved stopping its repetition
            public List<CutscenePathFlag> conditions; // conditions to be met for cutscene to play

            // save when path is played
            public void SaveProgression() {
                if (String.IsNullOrEmpty(playOnlyOnceFlag)) {
                    return;
                }

                Flags progressionFlag = MMSaveLoadTester.Instance.SaveObject.GetCurrentLevel.progressionFlags.Find(x => x.name == playOnlyOnceFlag);
                if (progressionFlag == null) {
                    // create and add new progression flag if it doesn't exist
                    progressionFlag = new Flags();
                    progressionFlag.name = playOnlyOnceFlag;
                    MMSaveLoadTester.Instance.SaveObject.GetCurrentLevel.progressionFlags.Add(progressionFlag);
                }

                MMSaveLoadTester.Instance.SaveObject.GetCurrentLevel.progressionFlags.Find(x => x.name == playOnlyOnceFlag).done = true;
                MMSaveLoadTester.Instance.Save();
            }

            // load if path has been played
            public bool LoadProgression() {
                if (String.IsNullOrEmpty(playOnlyOnceFlag)) {
                    return false;
                }

                Flags progressionFlag = MMSaveLoadTester.Instance.SaveObject.GetCurrentLevel.progressionFlags.Find(x => x.name == playOnlyOnceFlag);
                if (progressionFlag == null) {
                    return false;
                }

                return progressionFlag.done;
            }

            // check if conditions are met
            public bool CheckConditions() {
                foreach (CutscenePathFlag condition in conditions) {
                    switch (condition.flagType) {
                        case CutscenePathFlag.CutscenePathFlagType.Progression:
                            if (!CheckProgressionFlag(condition.flagName)) {
                                return false;
                            }
                            break;
                        case CutscenePathFlag.CutscenePathFlagType.Item:
                            if (!CheckItemInLevelFlag(condition.flagName)) {
                                return false;
                            }
                            break;
                    }
                }

                return true;
            }

            // check conditions
            private bool CheckProgressionFlag(string flagName) {
                Flags progressionFlag = MMSaveLoadTester.Instance.SaveObject.GetCurrentLevel.progressionFlags.Find(x => x.name == flagName);
                if (progressionFlag == null) {
                    return false;
                }

                return progressionFlag.done;
            }

            private bool CheckItemInLevelFlag(string flagName) {
                ItemsInLevel itemInLevel = MMSaveLoadTester.Instance.SaveObject.GetCurrentLevel.itemsInLevel.Find(x => x.name == flagName);
                if (itemInLevel == null) {
                    return false;
                }

                return itemInLevel.acquired;
            }
        }

        [Serializable]
        public struct CutscenePathFlag {
            public enum CutscenePathFlagType { Progression, Item }

            public CutscenePathFlagType flagType;
            public string flagName;
        }
    }
}