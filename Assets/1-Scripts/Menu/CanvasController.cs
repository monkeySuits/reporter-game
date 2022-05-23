using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using devlog98.Backdoor;

public class CanvasController : MonoBehaviour
{
    private Transform news;
    public static CanvasController instance;
    void Start()
    {
        if (instance != null && instance != this) {
                Destroy(this.gameObject);
        }else {
                instance = this;
        }

        news = transform.Find("News/Center/Center");
    }

    public void News(){
        if(news.GetComponent<NewsController>().Active()){
            news.GetComponent<NewsController>().Closed();
            Mouse(false);
        }else{       
            news.GetComponent<NewsController>().Publish();
            Mouse(true);
        }
    }

    private void Mouse(bool enable){
        Cursor.visible = enable;
        PlayerLock.instance.LockPlayer(enable);
        if(enable){
            Cursor.lockState = CursorLockMode.None;
        }else{
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
