using System;
using System.Collections.Generic;
using UnityEngine;

/*
 * conversation with sentences being spoken by actors
 * it must be passed to Dialogue Manager in order to work
 */

namespace MSuits.Dialogue {
    [Serializable]
    public class Dialogue {
        [Header("Script")]
        [SerializeField] private List<Sentence> sentences; // all sentences to be spoken
        private bool isOver; // if dialogue has ended

        public List<Sentence> Sentences { get => sentences; }
        public bool IsOver { get => isOver; set => isOver = value; }
    }
}