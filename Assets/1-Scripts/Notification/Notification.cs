using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Notification : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI notificationText;
    [SerializeField] private GameObject notificationPainel;
    [SerializeField] private Animator anim;
    private string customText;
    private bool active = false;
    [Header("Texts")]
    [SerializeField] private string newItemText;
    [SerializeField] private string newTaskText;
    public static Notification instance; // reference to singleton
    private bool newNotify;
    private string dataText;
    void Start()
    {
        if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
        }
    }
//Method to notify about a new item
    public void newItem(string itemText){
        customText = newItemText + itemText;
        Show(customText);
    }
//Method to notify about a new objective
    public void newTask(string taskText){
        customText = newTaskText + taskText;
        Debug.Log("newTask: " +customText);
        Show(customText);
    }
//Method to hide the notification
    private void Hide(){
        anim.SetTrigger("Hide");
        active = false;
        if(newNotify){
            newNotify = false;
            Invoke("Fila", 0.11f);
        }
    }
//Method to show the notification
    private void Show(string notify){
        if(active){
            newNotify = true;
            dataText = notify;
        }else{
            active = true;
            notificationText.text = notify;
            anim.SetTrigger("Show");
            Invoke("Hide", 3.0f);
        }
    }

    private void Fila(){
        Show(customText);
    }
}
