using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public List<Saves> saves = new List<Saves>();
    public static Database instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
        }
        Persistence();
    }

    public void Persistence(){
        for(int i = 0; i < 10; i++){
            Saves save = new Saves();
            save.NomeFase = "Fase " + i;
            save.DescriptionFase = " "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" "+i+" ";
            save.DateSave = "03/15/2022";
            save.IdSave = i;
            save.IdFase = i;
            saves.Add(save);
        }

        Debug.Log("tamanho do array: " + saves.Count);

        for(int i = 0; i < saves.Count; i++){
            Debug.Log("--------------------------------------------------------------");
            Debug.Log("objeto: " + i);
            Debug.Log("NomeFase: " + saves[i].NomeFase);
            Debug.Log("DescriptionFase: " + saves[i].DescriptionFase);
            Debug.Log("DateSave: " + saves[i].DateSave);
            Debug.Log("IdFase: " + saves[i].IdFase);
            Debug.Log("IdSave: " + saves[i].IdSave);
            Debug.Log("--------------------------------------------------------------");
        }
    }

    public class Saves
    {
        public string NomeFase { get; set; }
        public string DescriptionFase { get; set; }
        public string DateSave { get; set; }
        public int IdSave { get; set; }
        public int IdFase { get; set; }
    }
}
