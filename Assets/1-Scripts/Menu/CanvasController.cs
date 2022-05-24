using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using devlog98.Backdoor;

public class CanvasController : MonoBehaviour
{
    private Transform news;
    private Transform background;
    public static CanvasController instance;
    void Start()
    {
        if (instance != null && instance != this) {
                Destroy(this.gameObject);
        }else {
                instance = this;
        }
        //Obter os transforms child do Canvas
        news = transform.Find("News/Center/Center");
        background = transform.Find("Background");
    }

    //Controlador da HUD News
    public void News(){
        if(news.GetComponent<NewsController>().Active()){
            news.GetComponent<NewsController>().Closed();
            Mouse(false);
            BackgroundController(false);
        }else{       
            news.GetComponent<NewsController>().Publish();
            Mouse(true);
            BackgroundController(true);
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
}
