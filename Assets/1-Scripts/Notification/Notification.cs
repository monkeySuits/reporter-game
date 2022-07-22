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
    private bool active;
    [Header("Texts")]
    [SerializeField] private string newItemText;
    [SerializeField] private string newTaskText;
    public static Notification instance; // reference to singleton
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
        notificationPainel.SetActive(true);
        Show();
    }
//Method to notify about a new objective
    public void newTask(string taskText){
        customText = newTaskText + taskText;
        notificationPainel.SetActive(true);
        Show();
    }
//Method to hide the notification
    private void Hide(){
        anim.SetTrigger("Hide");
        active = false;
    }
//Method to show the notification
    private void Show(){
        if(active){
            CancelInvoke();
            Hide();
            Invoke("Show", 0.15f);
        }else{
            active = true;
            notificationText.text = customText;
            anim.SetTrigger("Show");
            Invoke("Hide", 3f);
        }
    }
}
