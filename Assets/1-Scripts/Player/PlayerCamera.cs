using MoreMountains.Feedbacks;
using System;
using UnityEngine;

/*
 * Responsible for screenshoting elements on screen
 */

namespace Reporter {

#pragma warning disable 649

    public class PlayerCamera : MonoBehaviour {
        public static PlayerCamera instance; // reference to singleton

        //event permits observational pattern
        public static event Action ScreenshotEvent = delegate { };

        [Header("Feedbacks")]
        [SerializeField] private MMFeedbacks screenshotFeedback; // feedbacks

        // singleton setup
        private void Awake() {
            if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
            }
        }

        public void ActivateCamera() {
            screenshotFeedback.StopFeedbacks();
            screenshotFeedback.PlayFeedbacks();
            ScreenshotEvent();
        }

        // unused methods
        public void DeactivateCamera() { }
    }
}