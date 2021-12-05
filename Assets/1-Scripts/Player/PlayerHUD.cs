using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

/*
 * Controls elements of the Player HUD
 */

namespace devlog98.Backdoor {

#pragma warning disable 649

    public class PlayerHUD : MonoBehaviour {
        public static PlayerHUD instance; // singleton reference

        [SerializeField] private TextMeshProUGUI hintText; // text element for hints
        //[SerializeField] private TextMeshProUGUI messageText; // text element for messages (story beats)

        [Header("Feedbacks")]
        [SerializeField] private MMFeedbacks hintTextFeedback; // feedbacks
        //[SerializeField] private MMFeedbacks showMessageFeedback;
        //[SerializeField] private MMFeedbacks hideMessageFeedback;

        // singleton setup
        private void Awake() {
            if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
            }
        }

        // show hint on screen
        public void ShowHint(string hint) {
            hintTextFeedback.StopFeedbacks();
            hintText.text = hint;
            hintTextFeedback.PlayFeedbacks();
        }

        //// show message on screen
        //public void ShowMessage(string message) {
        //    showMessageFeedback.PlayFeedbacks();
        //    messageText.text = message;
        //}

        //// hide message on screen
        //public void HideMessage() {
        //    hideMessageFeedback.PlayFeedbacks();
        //}
    }
}