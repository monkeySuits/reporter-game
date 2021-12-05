using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Reporter {

#pragma warning disable 649

    public class ScreenshotMe : MonoBehaviour {
        [Header("Collisions")]
        [SerializeField] private List<Renderer> renderers; // reference to enemy model
        [SerializeField] private List<Transform> raycastPoints; // list of points to check player visibility
        [SerializeField] private LayerMask raycastMask; // layers that can block player visibility

        [Header("Screenshot Results")]
        [SerializeField] private UnityEvent screenshotEvents; // events to happen when object is screenshot

        private bool isVisible;
        private bool isScreenshot;

        private void OnEnable() {
            PlayerCamera.ScreenshotEvent += CheckScreenshot;
        }

        private void OnDisable() {
            PlayerCamera.ScreenshotEvent -= CheckScreenshot;
        }

        public void CheckScreenshot() {
            if (!isScreenshot) {
                // check if enemy model is on camera view
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
                foreach (Renderer renderer in renderers) {
                    isVisible = GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
                    if (isVisible) {
                        break;
                    }
                }

                if (isVisible) {
                    // check if any object is obstructing player
                    foreach (Transform raycastPoint in raycastPoints) {
                        isVisible = !Physics.Linecast(raycastPoint.position, Camera.main.transform.position, raycastMask);
                        if (isVisible) {
                            break;
                        }
                    }
                }

                if (isVisible) {
                    isScreenshot = true;
                    screenshotEvents.Invoke();
                }
            }
        }
    }
}