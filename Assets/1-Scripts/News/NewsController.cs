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

    public void Publish(){
        fixedObjectives = objectivesControl.checkFixedObjectives();
        optionalObjectives = objectivesControl.checkOptionalObjectives();
        Closed();
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

    public void Closed(){
        stateNews.SetActive(false);
        anonymousNews.SetActive(false);
        DefaultNews.SetActive(false);
        textDefault.SetActive(false);
        action = false;
    }

    public bool Active(){
        return action;
    }
}
