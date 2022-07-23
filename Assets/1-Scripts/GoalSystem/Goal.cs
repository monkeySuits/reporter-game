using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
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
        public Vector2 goalID; // Index do objetivo a ser salvo
        MMSaveLoadTester saveLoadScript;
        private bool check = false;
        public bool active;

        public bool ActivedGoal { get => activedGoal; set => activedGoal = value;}

        //Events
        public static event Action<Goal> Started;
        public static event Action<Goal> Running;
        public static event Action<Goal> Achieved;
        public static event Action<Goal> Activated;
        public static event Action<Goal> Deactivated;
        void Start()
        {
            //Debug.Log("Started Goal ID: "+sequenceID);
            saveLoadScript = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<MMSaveLoadTester>();
            Started?.Invoke(this);

            if(status != GoalStatus.WAIT){
                active = true;
            }
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
            ActiveGoal();
            Running?.Invoke(this);
        }

        public void saveObjective(){
            saveLoadScript.SaveObject.levels[(int)goalID.x].progressionFlags[(int)goalID.y].done = true;
            Debug.Log("Salvando objetivo: " + (int)goalID.x + " e " + (int)goalID.y);
            saveLoadScript.Save();
            check = true;
        }

        public bool LoadGoal() {
            bool load = saveLoadScript.SaveObject.levels[(int)goalID.x].progressionFlags[(int)goalID.y].done;
            //Debug.Log("saldado? " + saveLoadScript.SaveObject.levels[(int)goalID.x].progressionFlags[(int)goalID.y].done);
            
            if (load) {
                check = true;
                status = GoalStatus.COMPLETD;
                Achieved?.Invoke(this);
                gameObject.SetActive(false);
            }else{
                check = false;
            }
            return check;
        }

        public void ActiveGoal(){
            saveLoadScript.SaveObject.levels[(int)goalID.x].progressionFlags[(int)goalID.y].active = true;
            saveLoadScript.Save();
        }

        public bool loadActiveGoals(){
            bool load = saveLoadScript.SaveObject.levels[(int)goalID.x].progressionFlags[(int)goalID.y].active;
            return load;
        }
    }
}
