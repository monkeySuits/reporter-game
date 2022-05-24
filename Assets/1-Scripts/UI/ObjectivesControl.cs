using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesControl : MonoBehaviour
{
    [Header("Goals")]
    [SerializeField] private GameObject[] fixedObjectives;
    [SerializeField] private GameObject[] optionalObjectives;
    [Header("News")]
    [SerializeField] private News mandatoryNews;
    [SerializeField] private News optionalNews;


//Verifica se o player completou o objetivo obrigatório
    public bool checkFixedObjectives(){
        int qtd = fixedObjectives.Length;
        bool made;
        foreach (GameObject obj in fixedObjectives)
        {
            made = obj.GetComponent<GoalsDisplay>().Made();
            if(!made){
                return false;
            }
        }
        return true;
    }
//Verifica se o jogador completou o objetivo opcional
    public bool checkOptionalObjectives(){
        int qtd = optionalObjectives.Length;
        bool made;
        foreach (GameObject obj in optionalObjectives)
        {
            made = obj.GetComponent<GoalsDisplay>().Made();
            if(!made){
                return false;
            }
        }
        return true;
    }

//Retorna o ScriptableObject da noticia obrigatória
    public News MandatoryNews(){
        return mandatoryNews;
    }

//Retorna o ScriptableObject da noticia opcional
    public News OptionalNews(){
        return optionalNews;
    }
}
