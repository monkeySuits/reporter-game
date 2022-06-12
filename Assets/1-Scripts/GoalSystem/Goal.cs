using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoalSystem{
    public enum GoalType{
        OPCIONAL,
        REQUIRED
    }

    public enum GoalStatus{
        WAIT,
        COMPLETD,
        RUNNING

    }
    public abstract class Goal : MonoBehaviour
    {
        //Type Default
        public GoalType type = GoalType.REQUIRED;
        //Status
        public GoalStatus status = GoalStatus.RUNNING;
        public int sequenceID;
        public string title;
        [TextArea]
        public string description;
        private bool activedGoal = false;

        public bool ActivedGoal { get => activedGoal; set => activedGoal = value;}

        //Events
        public static event Action<Goal> Started;
        public static event Action<Goal> Running;
        public static event Action<Goal> Achieved;
        public static event Action<Goal> Activated;
        public static event Action<Goal> Deactivated;
        void Start()
        {
            Started?.Invoke(this);
            Debug.Log("Started Goal ID: "+sequenceID);
        }

        // Update is called once per frame
        void Update()
        {   
            //Caso o objetivo esteja ativo ele verifica o status e realiza ações por status
            if(activedGoal && status != GoalStatus.COMPLETD){
                status = IsRunning();

                switch(status){
                    case GoalStatus.COMPLETD:
                        Achieved?.Invoke(this);
                        gameObject.SetActive(false);
                        break;
                    case GoalStatus.RUNNING:
                        break;
                    case GoalStatus.WAIT:
                        break;
                    default:
                        break;
                }
            }
        }

        protected abstract GoalStatus IsRunning();

        public void Activate(){
            activedGoal = true;
            Activated?.Invoke(this);
        }
        public void Disable(){
            activedGoal = false;
            Deactivated?.Invoke(this);
        }
        public void Trigger(){
            Running?.Invoke(this);
        }
    }
}
