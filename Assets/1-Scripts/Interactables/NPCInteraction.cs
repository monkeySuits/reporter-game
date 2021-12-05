using devlog98.Backdoor;
using MSuits.Cutscene;
using MSuits.Dialogue;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteraction : MonoBehaviour, IMouse {
    [Header("Cutscene")]
    [SerializeField] private Cutscene cutscene;

    public void OnMouseDown(InputAction.CallbackContext context) {
        if (cutscene != null && !cutscene.HasStarted) {
            cutscene?.StartCutscene();
        }
        else {
            DialogueManager.instance.NextSentence();
        }
    }

    // unused methods
    public void OnMouseDrag(InputAction.CallbackContext context) { }
    public void OnMouseUp(InputAction.CallbackContext context) { }
}