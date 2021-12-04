using MSuits.Dialogue;
using UnityEngine;

/*
 * activates dialogue in the middle of cutscene
 */

namespace MSuits.Cutscene.Unit {
    public class CutsceneDialogue : CutsceneUnit {
        [Header("Dialogue")]
        [SerializeField] private Dialogue.Dialogue dialogue;

        // start dialogue
        public override void ExecuteStart() {
            DialogueManager.instance.StartDialogue(dialogue);
        }

        // check if dialogue is over
        public override void ExecuteUpdate() {
            if (dialogue.IsOver) {
                isFinished = true;
            }
        }

        // end dialogue
        public override void ExecuteEnd() {
            DialogueManager.instance.EndDialogue();
        }

        // reset dialogue
        public override void ExecuteReset() {
            dialogue.IsOver = false;
            base.ExecuteReset();            
        }
    }
}