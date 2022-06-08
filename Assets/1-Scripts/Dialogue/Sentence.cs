using System;
using UnityEngine;
using UnityEngine.Events;

/*
 * data for every single written line delivered on cutscenes and their delivery
 */

namespace MSuits.Dialogue {
    [Serializable]
    public class Sentence {
        [Header("Text")]
        [SerializeField] private string sentenceKey; // what is being spoken

        [Header("Visual")]
        [SerializeField] private DialogueBoxType dialogueBoxType; // which dialogue box is going to appear on sentence
        [SerializeField] private DialogueTextType dialogueTextType; // from which side must the sentence appear
        [SerializeField] private float charWriteTime = 0.05f; // how many seconds for a single char to be written
        private const float defaultCharWriteTime = 0.05f;

        public string SentenceKey { get => sentenceKey; }
        public float CharWriteTime { get => charWriteTime == 0 ? defaultCharWriteTime : charWriteTime; }
        public DialogueBoxType DialogueBoxType { get => dialogueBoxType; }
        public DialogueTextType DialogueTextType { get => dialogueTextType; }

        [Header("Events")]
        public UnityEvent onPlayEvent;

    }
}