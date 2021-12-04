using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * Used to differentiate in which side the text must be written on the screen
 * It also will automatically change the portrait side
 */

namespace MSuits.Dialogue {
    public enum DialogueTextSide { Regular }

    [Serializable]
    public class DialogueText {
        [SerializeField] private DialogueTextSide side;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image portrait;

        public DialogueTextSide Side { get => side; }
        public TextMeshProUGUI Text { get => text; }
        public Image Portrait { get => portrait; }
    }
}