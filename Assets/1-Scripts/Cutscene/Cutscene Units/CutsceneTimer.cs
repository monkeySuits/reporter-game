using UnityEngine;

/*
 * Basic timer
 */

namespace MSuits.Cutscene.Unit {
    public class CutsceneTimer : CutsceneUnit {
        [Header("Timer Settings")]
        [SerializeField] private float waitTime; // amount of time to be waited (in seconds)
        private float timer; // internal timer

        // set timer
        public override void ExecuteStart() {
            timer = Time.time + waitTime;
        }

        // check timer
        public override void ExecuteUpdate() {
            if (Time.time >= timer) {
                isFinished = true;
            }
        }

        // unused methods
        public override void ExecuteEnd() { }
    }
}