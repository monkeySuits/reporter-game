using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Responsible for managing general game workflow
 */

namespace devlog98.Backdoor {

#pragma warning disable 649

    public class GeneralManager : MonoBehaviour {
        public static GeneralManager instance; // singleton reference

        private bool isLoading; // checks for loading in process

        // singleton setup
        private void Awake() {
            if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
            }
        }

        // load scene
        public void LoadScene(string sceneName) {
            if (!isLoading) {
                isLoading = true;
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}