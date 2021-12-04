using UnityEngine;
using UnityEngine.Events;

/*
 * useful to perform multiple disparate actions at once (activating/deactivating game objects, calling specific methods, etc)
 */

namespace MSuits.Cutscene.Unit {
    public class CutsceneTriggerEvent : CutsceneUnit {
        [SerializeField] private UnityEvent events;

        // invoke events
        public override void ExecuteStart() {
            events.Invoke();
            isFinished = true;
        }

        // unused methods
        public override void ExecuteUpdate() { }
        public override void ExecuteEnd() { }
    }
}