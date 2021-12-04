using System;
using UnityEngine;
using UnityEngine.UI;

/*
 * Used to differentiate types of dialogue boxes
 */

namespace MSuits.Dialogue {
    public enum DialogueBoxType { Regular }

    [Serializable]
    public class DialogueBox {
        [SerializeField] private DialogueBoxType type;
        [SerializeField] private Image image;

        public DialogueBoxType Type { get => type; }
        public Image Image { get => image; }
    }
}