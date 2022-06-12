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
        [Header("PrefabGoal")]
        public GameObject prefabGoalText;
        public List<GoalHUD> goalsHUD = new List<GoalHUD>();
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
            var ui = Instantiate(prefabGoalText, transform.position, Quaternion.identity);
            ui.transform.SetParent(transform, false);
            GoalHUD hud = ui.GetComponent<GoalHUD>();
            ui.name = "GoalHUD (seq= " + goal.sequenceID + ")";
            hud.Inite(goal);
            if(goal.status == GoalStatus.WAIT){
                hud.gameObject.SetActive(false);
            }
            if(goalsHUD.Count > 0){
                goalsHUD.Add(hud);
                ReorderList();
            }else{
                goalsHUD.Add(hud);
                ReorderList();
                CheckNotepad();
            }
        }
        //Quando iniciar o evento Running é ativado o prefab que foi criado desativado
        private void ActivateHUD(Goal goal){
            Debug.Log("entrou");
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
                hud.GetComponent<RectTransform>().SetSiblingIndex(hud.sequence);
            }
        }

        public void CheckNotepad(){
            notepadHud.SetActive(false);
            notepadHead.SetActive(true);
            notepadBodyHead.SetActive(true);
            notepadBody.GetComponent<Image>().enabled = true;
        }

        //Parar de ouvir os eventos ao ser destruido
        private void OnDestroy() 
        {
            Goal.Started -= CreateUIGoal;
            Goal.Running -= ActivateHUD;
        }
    }
}
