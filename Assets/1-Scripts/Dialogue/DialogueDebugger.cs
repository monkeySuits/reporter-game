using UnityEngine;

/*
 * basic script just for dialogue testing
 */

namespace MSuits.Dialogue {
    public class DialogueDebugger : MonoBehaviour {
        // go to next sentence when button is pressed
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale > 0) {
                DialogueManager.instance.NextSentence();
            }
        }
    }
}