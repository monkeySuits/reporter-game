using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Locallies.Core;
using System;

namespace MSuits.Dialogue {
    public class DialogueManager : MonoBehaviour {
        public static DialogueManager instance; // singleton

        [Header("Properties")]
        [SerializeField] private float minimumSentenceDuration; // minimum amount of seconds to wait before next sentence
        private float currentSentenceDuration = -1;

        [Header("Canvas")]
        [SerializeField] private GameObject dialogueUI; // all elements that form dialogue canvas
        [Space]
        [SerializeField] private List<DialogueBox> dialogueBoxes; // boxes where text is shown
        [Space]
        [SerializeField] private List<DialogueText> dialogueTexts; // positioning of text fields and portraits
        private DialogueBox dialogueBox; // current dialogue box displayed on screen
        private DialogueText dialogueText; // current dialogue text displayed on screen

        private Dialogue dialogue; // current dialogue
        private Queue<Sentence> dialogueSentences = new Queue<Sentence>(); // current dialogue sentences
        private Sentence sentence; // sentence being shown on screen

        private bool writingSentence; // if sentence is being written on screen

        public bool IsDialoguing { get { return dialogue == null ? false : !dialogue.IsOver; } }

        // initialize singleton
        private void Awake() {
            if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
            }
        }

        // start dialogue
        public void StartDialogue(Dialogue newDialogue) {
            // activates dialogue UI
            dialogueUI.SetActive(true);

            // set current dialogue
            dialogue = newDialogue;

            // enqueue sentences
            dialogueSentences.Clear();
            foreach (Sentence dialogueSentence in dialogue.Sentences) {
                dialogueSentences.Enqueue(dialogueSentence);
            }

            // start dialogue
            NextSentence();
        }

        // continue dialogue
        public void NextSentence() {
            // if (Time.time > currentSentenceDuration) {

                // show whole sentence if a sentence is already being written
                if (writingSentence) {
                   StopCoroutine("SentenceCoroutine");
                   ShowSentence();
                   return;
                }

                // end dialogue if there are no more sentences left
                if (dialogueSentences.Count == 0) {
                    EndDialogue();
                    return;
                }

                // update sentence duration
                CalculateNewSentenceDuration();

                // get next sentence
                sentence = dialogueSentences.Dequeue();

                if(sentence.onPlayEvent != null)
                {
                    sentence.onPlayEvent.Invoke();
                }
                
                // show sentence on screen
                StopCoroutine("SentenceCoroutine");
                StartCoroutine("SentenceCoroutine");
            // }
        }        

        // show sentence one char at a time using its specific attributes
        private IEnumerator SentenceCoroutine() {
            writingSentence = true;

            // reset dialogue box, dialogue text, etc
            ResetDialogueElements();

            // show correct dialogue box
            dialogueBox = dialogueBoxes.Find(x => x.Type == sentence.DialogueBoxType);
            if (dialogueBox != null) {
                dialogueBox.Image.gameObject.SetActive(true);
            }

            // show correct dialogue text
            dialogueText = dialogueTexts.Find(x => x.Side == sentence.DialogueTextSide);
            if (dialogueText != null) {
                dialogueText.Text.gameObject.SetActive(true);
                dialogueText.Portrait.gameObject.SetActive(true);
            }

            // get sentence text
            // string sentenceText = LocalizationManager.LocalizeString(sentence.SentenceKey);

            // show sentence text one letter at a time

            // dialogueText.Text.text = "";
            // char[] sentenceChars = sentenceText.ToCharArray();
            // foreach(char sentenceChar in sentenceChars) {
            //     dialogueText.Text.text += sentenceChar;
            //     yield return new WaitForSeconds(sentence.CharWriteTime);
            // }

            // writingSentence = false;

            ShowSentence();
            yield return null;
        }

        // show whole sentence at once
        private void ShowSentence() {
            if (!String.IsNullOrEmpty(sentence.SentenceKey)) {
                dialogueText.Text.text = LocalizationManager.LocalizeString(sentence.SentenceKey);
            }

            if (sentence.SentencePortrait != null) {
                dialogueText.Portrait.sprite = sentence.SentencePortrait;
            }

            writingSentence = false;

            // if(sentence.onEndEvent != null)
            // {
            //     sentence.onEndEvent.Invoke();
            // }

        }

        // used to reset dialogue UI
        private void ResetDialogueElements() {
            if (dialogueBox != null) {
                dialogueBox.Image.gameObject.SetActive(false);
            }

            if (dialogueText != null) {
                dialogueText.Text.gameObject.SetActive(false);
                dialogueText.Portrait.gameObject.SetActive(false);
            }
        }

        // end dialogue
        public void EndDialogue() {
            dialogue.IsOver = true;
            dialogueUI.SetActive(false);
        }

        // add time to sentence duration
        public void CalculateNewSentenceDuration() {
            currentSentenceDuration = Time.time + minimumSentenceDuration;
        }
    }
}