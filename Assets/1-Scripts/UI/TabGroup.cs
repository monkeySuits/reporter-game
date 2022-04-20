using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    private TabButton selectedTab;
    [Header("Button colors")]
    [SerializeField]private Color hover;
    [SerializeField]private Color click;
    [SerializeField]private Color defaut;
    [SerializeField]private List<GameObject> objectsToSwap;
    [SerializeField]private string firstButton;
    private bool exit;

    public void Subscribe(TabButton button){
        if(tabButtons == null){
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button){
        ResetTabs();
        if(selectedTab == null || button != selectedTab){
            button.background.color = hover;
        }
        // Debug.Log("Entrou");
    }

    public void OnTabExit(TabButton button){
        ResetTabs();
        // Debug.Log("Saiu");
    }

    public void OnTabSelected(TabButton button){

        if(selectedTab != null){
            selectedTab.Deselect();
        }

        selectedTab = button;
        selectedTab.Select();
        ResetTabs();
        button.background.color = click;
        Debug.Log("Clicou");
        int index = button.transform.GetSiblingIndex();
        for(int i=0; i < objectsToSwap.Count; i++){
            if(i == index){
                objectsToSwap[i].SetActive(true);
            }else{
                objectsToSwap[i].SetActive(false);
            }
        }
        if(exit){
            selectedTab = null;
            ViewPause();
            exit = false;
        }
    }

    public void ResetTabs(){
        foreach(TabButton button in tabButtons){
            if(selectedTab != null && button == selectedTab){continue;}
            button.background.color = defaut;
        } 
    }

    public void Exit(){
        exit = true;
    }

    public void ViewPause(){
        ResetTabs();
        foreach(TabButton button in tabButtons){
            if(button.name == firstButton){
                selectedTab = button;
                selectedTab.background.color = click;
            }
        } 
        objectsToSwap[0].SetActive(true);
    }

    private void Start() {
        Invoke("ViewPause", 0.05f);
    }
}
