using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GoalSystem;

public class NewsController : MonoBehaviour
{
    [Header("Widgets")]
    [SerializeField] private GameObject stateNews;
    [SerializeField] private GameObject anonymousNews;
    [SerializeField] private GameObject DefaultNews;
    [SerializeField] private GameObject textDefault;
    [SerializeField] private GameObject Notepad;

    private bool fixedObjectives;
    private bool optionalObjectives;
    private News mandatoryNews;
    private News optionalNews;

    private bool action;

    private void Start() {
        //Enviar Scriptableobjects nas noticias
        mandatoryNews = GoalManager.Instance.GetMandatoryNews;
        optionalNews = GoalManager.Instance.GetOptionalNews;
        stateNews.GetComponent<NewsDisplay>().GetNews(mandatoryNews);
        anonymousNews.GetComponent<NewsDisplay>().GetNews(optionalNews);
    }

    public void Publish(){
        //Consultar se os objetivos foram cumpridos
        fixedObjectives = GoalManager.Instance.IsCompletedGoalsRequired;
        optionalObjectives = GoalManager.Instance.IsCompletedGoalsOpcional;
        Debug.Log("fixedObjectives: " + fixedObjectives);
        Debug.Log("optionalObjectives: " + optionalObjectives);
        Closed();
        //Ativar a hud com base nos objetivos
        if(fixedObjectives || optionalObjectives){
            if(fixedObjectives && optionalObjectives){
                stateNews.SetActive(true);
                anonymousNews.SetActive(true);
            }else if(fixedObjectives){
                stateNews.SetActive(true);
            }else if(optionalObjectives){
                anonymousNews.SetActive(true);
            }else{
                DefaultNews.SetActive(true);
                textDefault.SetActive(true);
            }
        }else{
            DefaultNews.SetActive(true);
            textDefault.SetActive(true);
        }
        action = true;
    }

    //Desativar doas as noticias
    public void Closed(){
        stateNews.SetActive(false);
        anonymousNews.SetActive(false);
        DefaultNews.SetActive(false);
        textDefault.SetActive(false);
        action = false;
    }

    //Retonar o status atual das Noticias
    public bool Active(){
        return action;
    }
    //Retonar a noticia escolhida
    public void MandatoryNews(){
        Notepad.GetComponent<Notepad>().GetNews(mandatoryNews);
    }

    public void OptionalNews(){
        Notepad.GetComponent<Notepad>().GetNews(optionalNews);
    }
}
