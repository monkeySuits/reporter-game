using System.Collections.Generic;
using UnityEngine;

/*
 * cutscene controller
 */

namespace MSuits.Cutscene {
    public class Cutscene : MonoBehaviour {
        private List<CutsceneSequence> sequences = new List<CutsceneSequence>();
        private CutsceneSequence currentSequence;
        [SerializeField] private bool activeOnStart; // if cutscene must start on object initialization
        [SerializeField] private bool destroyOnEnd; // if cutscene object must be destroyed after finished

        public bool hasStarted; // if cutscene passed through start method

        [Header("Debug")]
        [SerializeField] private bool isDebugging;

        public bool HasStarted { get => hasStarted; }

        private void Start() {
            if (activeOnStart) {
                StartCutscene();
            }
        }

        // start cutscene sequences
        public void StartCutscene() {            
            hasStarted = true;

            // get sequences lazily
            if (sequences.Count == 0) {
                sequences.AddRange(GetComponentsInChildren<CutsceneSequence>());
            }

            currentSequence = sequences[0];
            currentSequence.ExecuteStart();

            // debug
            if (isDebugging) {
                Debug.Log("[CUTSCENE] " + this.gameObject.name + " started!");
                Debug.Log("[CUTSCENE] " + this.gameObject.name + " on " + currentSequence.gameObject.name + "!");
            }
        }

        // reset all cutscene sequences
        public void ResetCutscene() {
            foreach (CutsceneSequence sequence in sequences) {
                sequence.ExecuteReset();
            }

            hasStarted = false;
        }

        // execute sequences
        private void Update() {
            if (currentSequence != null) {
                currentSequence.ExecuteUpdate();

                // change sequence if finished
                if (currentSequence.IsFinished) {
                    NextSequence();
                }
            }
        }

        // swap sequence
        private void NextSequence() {
            currentSequence.ExecuteEnd();

            currentSequence = sequences.Find(x => !x.IsFinished);            
            if (currentSequence != null) {
                currentSequence.ExecuteStart();

                // debug
                if (isDebugging) {
                    Debug.Log("[CUTSCENE] " + this.gameObject.name + " on " + currentSequence.gameObject.name + "!");
                }
            }
            else {
                // cutscene ended
                if (destroyOnEnd) {
                    Destroy(this.gameObject);

                    // debug
                    if (isDebugging) {
                        Debug.Log("[CUTSCENE] " + this.gameObject.name + " ended and was destroyed!");
                    }
                }
                else {
                    ResetCutscene();

                    // debug
                    if (isDebugging) {
                        Debug.Log("[CUTSCENE] " + this.gameObject.name + " ended and was reset!");
                    }
                }
            }
        }
    }
}