using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;
using Febucci.UI;

/*
 * Used to differentiate in which side the text must be written on the screen
 * It also will automatically change the portrait side
 */

namespace MSuits.Dialogue {
    public enum DialogueTextType { Regular }

    [Serializable]
    public class DialogueText {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private DialogueTextType type;
        [SerializeField] private MMFeedbacks talkFeed;
        [SerializeField] private TextAnimatorPlayer tAnimPlayer;

        public DialogueTextType Type { get => type; }
        public TextMeshProUGUI Text { get => text; }
        public MMFeedbacks TalkFeed { get => talkFeed; }
        public TextAnimatorPlayer TAnimPlayer { get => tAnimPlayer; }
    }
}