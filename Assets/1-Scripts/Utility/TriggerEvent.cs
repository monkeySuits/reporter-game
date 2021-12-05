using UnityEngine;
using UnityEngine.Events;

/*
 * Invokes events based on trigger collision
 * Useful to create dynamic interactions on levels
 */

namespace MSuits.Utility.Event {
    public class TriggerEvent : MonoBehaviour {
        [SerializeField] private UnityEvent events;
        [SerializeField] private bool triggerOnce;

        // trigger event
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag("Player")) {
                events.Invoke();

                if (triggerOnce) {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}