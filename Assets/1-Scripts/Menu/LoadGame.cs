
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public LoadReference element;
    private Database database;
    // Start is called before the first frame update
    async void Start()
    {
        database = Database.instance;
        InstantiateElements();
    }

    public void InstantiateElements(){
        if(!database){
            return;
        }
        if(transform.childCount <= 0){
                for(int i = 0; i < database.saves.Count; i++){
                (Instantiate(element, transform) as LoadReference).SetValues(
                    database.saves[i]);
                }
        }
    }

}
