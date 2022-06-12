using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoalSystem;

public class TriggerGoal : Goal
{
    protected override GoalStatus IsRunning()
    {
        return GoalStatus.COMPLETD;
    }
    //Função para informar que o objetivo foi completo
    public void Completed(){
        if(!ActivedGoal){
            Activate();
        }
        Invoke("Finish", 1);
    }

    public void Finish(){
        Disable();
    }
    //Função para ativar a HUD do objetivo quando startado como WAIT
    public void ActivateObject(){
        Trigger();
    }
}
