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
            Debug.Log("Usando camera");
            ScreenshotEvent();
        }

        public void DeactivateCamera() {
            Debug.Log("Parando de usar camera");
        }
    }
}