using MoreMountains.Feedbacks;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Responsible for screenshoting elements on screen
 */

namespace Reporter {

#pragma warning disable 649

    public class PlayerCamera : MonoBehaviour {
        public static PlayerCamera instance; // reference to singleton
        public MMFeedbacks aimingStartFeed;
        public MMFeedbacks aimingEndFeed;
        public bool aiming;

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
        public void AimCamera() {
            aimingStartFeed.PlayFeedbacks();
            aiming = true;
        }
        public void StopCamera() {
            aimingEndFeed.PlayFeedbacks();
            aiming = false;

        }

        public void ActivateCamera() {
            if(aiming){
                screenshotFeedback.StopFeedbacks();
                screenshotFeedback.PlayFeedbacks();
                ScreenshotEvent();
            }
        }

        // unused methods
        public void DeactivateCamera() { }
    }
}