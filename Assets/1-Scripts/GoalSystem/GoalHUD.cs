using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GoalSystem{
    public class GoalHUD : MonoBehaviour
    {
        public int sequence;
        public TextMeshProUGUI title;
        public GameObject imgCompleted;
        public GameObject imgDefault;
        //Ao se criado preenche as informações e fica ouvindo o evento Achieved
        public void Inite(Goal goal){
            title.text = goal.title;
            sequence = goal.sequenceID;
            Goal.Achieved += OnCompleted;
        }
        //Quando acionado ele altera a imagem e fonte na HUD para informar que foi completo
        private void OnCompleted(Goal goal){
            if(this.sequence == goal.sequenceID)
            {
                imgDefault.SetActive(false);
                imgCompleted.SetActive(true);
                title.fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
            }
        }
        //Ao ser destruido para de ouvir o evento
        private void OnDestroy() 
        {
            Goal.Achieved -= OnCompleted;
        }
    }
}

