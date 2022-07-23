using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace GoalSystem{
    public class PainelContainerGoal : MonoBehaviour
    {
        [Header("Notepad")]
        public GameObject notepadHud;
        public GameObject notepadHead;
        public GameObject notepadBodyHead;
        public GameObject notepadBody;
        public GameObject goalsText;
        public GameObject optionalText;
        [Header("PrefabGoal")]
        public GameObject prefabGoalText;
        public List<GoalHUD> goalsHUD = new List<GoalHUD>();
        private int numberMandatoryGoals = 0;
        private int currentOptionalGoals = 0;
        // Start is called before the first frame update
        void Start()
        {
            //Ouvir os eventos Started e Running
            Goal.Started += CreateUIGoal;
            Goal.Running += ActivateHUD;
        }
        //Quando iniciar o evento Started é criado um prefab na HUD com o objeto que disparou o evento
        //Caso o objeto esteja com o status Wait, ele é criado desativado
        private void CreateUIGoal(Goal goal){
            NumberMandatoryGoals(goal);
            var ui = Instantiate(prefabGoalText, transform.position, Quaternion.identity);
            ui.transform.SetParent(transform, false);
            GoalHUD hud = ui.GetComponent<GoalHUD>();
            ui.name = "GoalHUD (seq= " + goal.sequenceID + ")";
            hud.Inite(goal);
            if(goal.status == GoalStatus.WAIT){
                hud.gameObject.SetActive(false);
            }
            if(goal.status != GoalStatus.WAIT && goal.type == GoalType.OPCIONAL){
                optionalText.SetActive(true);
            }
            if(goalsHUD.Count > 0){
                goalsHUD.Add(hud);
                ReorderList();
            }else{
                goalsHUD.Add(hud);
                ReorderList();
                CheckNotepad();
            }
            ReloadData(goal);
        }
        //Quando iniciar o evento Running é ativado o prefab que foi criado desativado
        private void ActivateHUD(Goal goal){
            if(!optionalText.activeSelf){
                optionalText.SetActive(true);
            }
            foreach(var hud in goalsHUD){
                if(hud.sequence == goal.sequenceID){
                    hud.gameObject.SetActive(true);
                    Notification.instance.newTask(goal.title);
                }
            }
        }

        private void ReloadObjectives(Goal goal){
            if(!optionalText.activeSelf){
                optionalText.SetActive(true);
            }
            foreach(var hud in goalsHUD){
                if(hud.sequence == goal.sequenceID){
                    hud.gameObject.SetActive(true);
                }
            }
        }

        //Reodernar a lista com base no numero da sequencia dos prefabs
        public void ReorderList()
        {
            goalsHUD = goalsHUD.OrderBy(goal => goal.sequence).ToList();
            foreach(var hud in goalsHUD)
            {  
                if(hud.type == GoalType.REQUIRED){//Caso seja obrigatório, adiciona apos o texto de objetivos
                    hud.GetComponent<RectTransform>().SetSiblingIndex(hud.sequence + 1);
                }else{//Caso seja opcional, reorganiza o texto opcional e adiciona os objetivos opcionais após ele
                    currentOptionalGoals = numberMandatoryGoals + 1;
                    optionalText.GetComponent<RectTransform>().SetSiblingIndex(currentOptionalGoals);
                    hud.GetComponent<RectTransform>().SetSiblingIndex(currentOptionalGoals + hud.sequence + 1);
                }
            }
        }

        public void CheckNotepad(){
            notepadHud.SetActive(false);
            notepadHead.SetActive(true);
            notepadBodyHead.SetActive(true);
            goalsText.SetActive(true);
            notepadBody.GetComponent<Image>().enabled = true;
        }
        //Guarda a quantidade de objetivos para organização do layout
        private void NumberMandatoryGoals(Goal goal){
            if(goal.type == GoalType.REQUIRED){
                numberMandatoryGoals = numberMandatoryGoals + 1;
            }
        }

        //Parar de ouvir os eventos ao ser destruido
        private void OnDestroy() 
        {
            Goal.Started -= CreateUIGoal;
            Goal.Running -= ActivateHUD;
        }
        //Consulta o databasse para veririfcar se tem objetivos ativos ou completos
        private void ReloadData(Goal goal){
            if(goal.LoadGoal()){
                if(goal.type == GoalType.OPCIONAL){
                     ReloadObjectives(goal);
                }
            }
            if(goal.loadActiveGoals()){
                ReloadObjectives(goal);
            }
        }
    }
}
