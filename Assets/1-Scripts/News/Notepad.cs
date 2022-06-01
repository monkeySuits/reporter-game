using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Notepad : MonoBehaviour
{
    [Header("Scriptable")]
    [SerializeField] private News news;
    [Header("Note")]
    public TextMeshProUGUI note;
    [Header("News")]
    [SerializeField] private GameObject stateNews;
    [SerializeField] private GameObject anonymousNews;
    [Header("Scene")]
    [SerializeField] private int currentSceneIndex;
    [SerializeField] private int nextSceneIndex;
    //Ativar bloco de anotações
    public void ActivateNotepad(){
        DisableNews();
        gameObject.SetActive(true);
    }
    //Desativar Noticias
    public void DisableNews(){
        stateNews.SetActive(false);
        anonymousNews.SetActive(false);
    }
    //Receber Scriptable Object da noticia escolhida
    public void GetNews(News getNews){
        news = getNews;
        note.text = news.note;
        ActivateNotepad();
    }
    //Resetar fase, objetivos e intens
    public void Reset(){
        SceneManager.LoadScene(currentSceneIndex);
    }
    //Avançar para a proxima parte, salvar escolha
    public void CompleteMission(){
        SceneManager.LoadScene(nextSceneIndex);
    }
}
