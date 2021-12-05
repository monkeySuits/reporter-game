using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesControl : MonoBehaviour
{
    [Header("Goals")]
    [SerializeField] private GameObject[] fixedObjectives;
    [SerializeField] private GameObject[] optionalObjectives;
    // Start is called before the first frame update
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
}
