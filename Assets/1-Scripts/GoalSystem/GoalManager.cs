using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GoalSystem{
    public class GoalManager : Singleton<GoalManager>
    {
        public List<Goal> goals = new List<Goal>();
        //Events
        public static event Action CompletedGoalsRequired;
        public static event Action CompletedGoalsOpcional;
        private bool isCompletedGoalsOpcional = false;
        private bool isCompletedGoalsRequired = false;
        public bool IsCompletedGoalsRequired{get => isCompletedGoalsRequired; set => isCompletedGoalsRequired = value;}
        public bool IsCompletedGoalsOpcional{get => isCompletedGoalsOpcional; set => isCompletedGoalsOpcional = value;}
        [Header("News")]
        [SerializeField] private News mandatoryNews;
        [SerializeField] private News optionalNews;
        public News GetMandatoryNews{get => mandatoryNews;}
        public News GetOptionalNews{get => optionalNews;}
        // Start is called before the first frame update
        void Start()
        {
            //Ouvir o evento Started
            Goal.Started += AddGoal;
        }

        private void Update()
        {
            //Checa se todas as noticias Obrigatórias foram feitas pelo jogador e retorna a resposta
            if(CompletedAllGoalsRequired())
            {
                CompletedGoalsRequired?.Invoke();
                isCompletedGoalsRequired = true;
            }
            //Checa se todas as noticias Opcionais foram feitas pelo jogador e retorna a resposta
            if(CompletedAllGoalsOpcional())
            {
                CompletedGoalsOpcional?.Invoke();
                isCompletedGoalsOpcional = true;
            }
        }
        //Adiciona o objetivo automaticamente ao gerenciador quando um objetivo é criado
        private void AddGoal(Goal goalObject)
        {
            //Debug.Log("Add Goal: " + goalObject.sequenceID);
            if(!goals.Exists(goal => goal.sequenceID == goalObject.sequenceID)){
                goals.Add(goalObject);
            }else{
                Debug.LogError("[GoalSystem] - Sequence " + goalObject.GetType() + " already exists. Seq:" + goalObject.sequenceID);
            }
            goals = goals.OrderBy(goal => goal.sequenceID).ToList();
        }
        //Verifica se todos os objetivos foram cumpridos
        private bool CompletedAllGoalsRequired()
        {
            bool value = true;

            foreach(var goal in goals){
                if(goal.type != GoalType.OPCIONAL){
                    if(goal.status != GoalStatus.COMPLETD){
                        value = false;
                    }
                }
            }
            return value;
        }

        private bool CompletedAllGoalsOpcional()
        {
            bool value = true;

            foreach(var goal in goals){     
                if(goal.type != GoalType.REQUIRED){
                    if(goal.status != GoalStatus.COMPLETD){
                        value = false;
                    }
                }
            }
            return value;
        }
        //Para de ouvir o evento ao ser destruido
        private void OnDestroy() 
        {
            Goal.Started -= AddGoal;
        }
    }
}