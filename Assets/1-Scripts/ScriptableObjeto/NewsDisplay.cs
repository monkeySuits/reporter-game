using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewsDisplay : MonoBehaviour
{
    [Header("Scriptable")]
    [SerializeField] private News news;
    [Header("Header")]
    public Image headerColor;
    public Image newspaperLogo;
    public TextMeshProUGUI newspaperName;
    [Header("Body")]
    public Image bodyColor;
    public Image photograph;
    public TextMeshProUGUI title;
    public TextMeshProUGUI text;
    // Preencher a Hud com as informações do ScriptableObject
    void Start()
    {
        headerColor.color = news.headerColor;
        bodyColor.color = news.bodyColor;
        newspaperLogo.sprite = news.newspaperLogo;
        newspaperName.text = news.newspaperName;
        photograph.sprite = news.photograph;
        title.text = news.title;
        text.text = news.text;
    }

    //Receber o ScriptableObject ta noticia
    public void GetNews(News getNews){
        news = getNews;
    }

}
