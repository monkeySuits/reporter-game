using UnityEngine;
using UnityEngine.SceneManagement;

namespace Reporter {
    public class PlayerReport : MonoBehaviour {
        [SerializeField] private ObjectivesControl objectivesControl;

        public void Report() {
            if (objectivesControl.checkFixedObjectives()) {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                if (objectivesControl.checkOptionalObjectives()) {
                    SceneManager.LoadScene("EP 1 - Ending Complete");
                    return;
                }

                SceneManager.LoadScene("EP 1 - Ending Incomplete");
            }
        }
    }
}