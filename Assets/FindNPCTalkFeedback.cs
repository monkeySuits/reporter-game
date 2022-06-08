using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using MSuits.Dialogue;

public class FindNPCTalkFeedback : MonoBehaviour
{

    public void PlayCurrentNPCTalkingFeedback(){
        DialogueManager.instance.sentence.TalkFeed.PlayFeedbacks();
        Debug.Log("Find Stuff");
    }
}
