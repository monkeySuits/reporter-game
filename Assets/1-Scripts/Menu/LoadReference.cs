using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadReference : MonoBehaviour
{
    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI descriptionDisplay;
    public TextMeshProUGUI dateDisplay;
    public int idFase;
    public int idSave;

    public void SetValues(Database.Saves item){
            Debug.Log("Entrou no set");
            idFase = item.IdFase;
            idSave = item.IdSave;
            nameDisplay.text = item.NomeFase;
            descriptionDisplay.text = item.DescriptionFase;
            dateDisplay.text = item.DateSave;
    }

    public void DeleteGame(){
        Destroy(gameObject);
    }

    public void LoadGame(){
        SceneManager.LoadScene(idFase);
    }
}
