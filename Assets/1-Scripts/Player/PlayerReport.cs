using UnityEngine;
using UnityEngine.SceneManagement;

namespace Reporter {
    public class PlayerReport : MonoBehaviour {
        [SerializeField] private ObjectivesControl objectivesControl;
        public void Report() {
            CanvasController.instance.News();
        }
    }
}