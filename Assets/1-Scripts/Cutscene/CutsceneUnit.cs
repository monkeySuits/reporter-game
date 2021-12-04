using UnityEngine;

/*
 * the smallest building block of a cutscene
 * abstract class which every action must derive from
 */

namespace MSuits.Cutscene {
    public abstract class CutsceneUnit : MonoBehaviour {
        [Header("Cutscene Flow")]
        [SerializeField] private bool waitToFinish; // if cutscene must wait this unit to go to another sequence
        protected bool isFinished; // if action ended

        public bool WaitToFinish { get => waitToFinish; }
        public bool IsFinished { get => isFinished; }

        // for now, it will have the same options as a default enemy attack class
        public abstract void ExecuteStart();
        public abstract void ExecuteUpdate();
        public abstract void ExecuteEnd();

        // reset unit
        public virtual void ExecuteReset() {
            isFinished = false;
        }
    }
}