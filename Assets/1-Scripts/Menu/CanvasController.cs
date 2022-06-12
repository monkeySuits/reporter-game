using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using devlog98.Backdoor;

public class CanvasController : MonoBehaviour
{
    private Transform news;
    private Transform background;
    private Transform goals;
    public static CanvasController instance;
    private bool status;
    void Start()
    {
        if (instance != null && instance != this) {
                Destroy(this.gameObject);
        }else {
                instance = this;
        }
        //Obter os transforms child do Canvas
        news = transform.Find("News/Center/Center");
        goals = transform.Find("Goals");
        background = transform.Find("Background");
    }

    //Controlador da HUD News
    public void News(){
        if(news.GetComponent<NewsController>().Active()){
            status = false;
            news.GetComponent<NewsController>().Closed();
            Mouse(status);
            BackgroundController(status);
        }else{       
            CheckStatusTrue();
            news.GetComponent<NewsController>().Publish();
            Mouse(status);
            BackgroundController(status);
        }
    }

    //Controlador do HUD de objetivos
    public void Goals(){
        if(goals.gameObject.activeSelf){
            status = false;
            goals.gameObject.SetActive(status);
            Mouse(status);
            BackgroundController(status);
        }else{
            CheckStatusTrue();
            goals.gameObject.SetActive(status);
            Mouse(status);
            BackgroundController(status);
        }
    }

    //Controlador do Mouse e PlayerLock
    private void Mouse(bool enable){
        Cursor.visible = enable;
        PlayerLock.instance.LockPlayer(enable);
        if(enable){
            Cursor.lockState = CursorLockMode.None;
        }else{
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    //Controlador do Background
    private void BackgroundController(bool enable){
        background.gameObject.SetActive(enable);
    }

    private void CheckStatusTrue(){
        if(status){
            news.GetComponent<NewsController>().Closed();
            goals.gameObject.SetActive(false);
        }else{
            status = true;
        }
    }
}
