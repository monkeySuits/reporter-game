using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewsController : MonoBehaviour
{
    [Header("Widgets")]
    [SerializeField] private GameObject stateNews;
    [SerializeField] private GameObject anonymousNews;
    [SerializeField] private GameObject DefaultNews;
    [SerializeField] private GameObject textDefault;
    [Header("Data")]
    [SerializeField] private ObjectivesControl objectivesControl;

    private bool fixedObjectives;
    private bool optionalObjectives;

    private bool action;

    private void Start() {
        //Enviar Scriptableobjects nas noticias
        stateNews.GetComponent<NewsDisplay>().GetNews(objectivesControl.MandatoryNews());
        anonymousNews.GetComponent<NewsDisplay>().GetNews(objectivesControl.OptionalNews());
    }

    public void Publish(){
        //Consultar se os objetivos foram cumpridos
        fixedObjectives = objectivesControl.checkFixedObjectives();
        optionalObjectives = objectivesControl.checkOptionalObjectives();
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
}
