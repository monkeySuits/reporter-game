using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool panel;
    public GameObject pausePanel;
    public static PauseController instance;
    // Start is called before the first frame update
    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }

    public void PanelController(){
        PanelSwitch();
        pausePanel.SetActive(panel);
    }

    public void PanelSwitch(){
        panel = !panel;
    }

    public bool Active(){
        return panel;
    }
}
