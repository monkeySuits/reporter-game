using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalsDisplay : MonoBehaviour
{
    [Header("Goal")]
    public string goalText;
    [Header("Gameobjects")]
    public Goals goals;
    public TextMeshProUGUI goal;
    public Image artworkImage;

    private bool check;

    void Start()
    {
        goal.text = goalText;
        artworkImage.sprite = goals.artworkImage;
    }

//Função responsavel for assinalar o checkbox ao completar o objetivo
    public void Checked(){
        artworkImage.sprite = goals.artworkImageChecked;
        check = true;
        CheckedEffect();
    }
//Efeitos
    private void CheckedEffect(){
        Color Image = artworkImage.color;
        Color text = goal.color;
        Image.a = 1f;
        text.a = 1f;
        artworkImage.color = Image;
        goal.color = text;
    }
//Retorna se o objetivo foi completo ou não
    public bool Made(){
        return check;
    }
}
