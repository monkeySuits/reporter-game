using System.Collections.Generic;
using UnityEngine;

/*
 * specific series of events (units) that can happen in a cutscene
 */ 

namespace MSuits.Cutscene {
    public class CutsceneSequence : MonoBehaviour {
        private List<CutsceneUnit> units = new List<CutsceneUnit>();
        private List<CutsceneUnit> activeUnits;
        private bool isFinished; // if sequence ended

        public bool IsFinished { get => isFinished; }

        // get all child units
        public void ExecuteStart() {
            // get units lazily
            if (units.Count == 0) {
                units.AddRange(GetComponentsInChildren<CutsceneUnit>());
            }

            activeUnits = units.FindAll(x => x.WaitToFinish);

            // start units
            foreach (CutsceneUnit unit in units) {
                unit.ExecuteStart();
            }
        }

        // check units state
        public void ExecuteUpdate() {
            List<CutsceneUnit> currentUnits = activeUnits.FindAll(x => !x.IsFinished);

            if (currentUnits.Count == 0) {
                isFinished = true;
            }
            else {
                currentUnits = units.FindAll(x => !x.IsFinished);
                foreach (CutsceneUnit unit in currentUnits) {
                    unit.ExecuteUpdate();
                }
            }
        }

        // finish units behaviours
        public void ExecuteEnd() {
            foreach(CutsceneUnit unit in units) {
                unit.ExecuteEnd();
            }
        }

        // reset cutscene sequence and its units
        public void ExecuteReset() {
            isFinished = false;
            foreach (CutsceneUnit unit in units) {
                unit.ExecuteReset();
            }
        }
    }
}