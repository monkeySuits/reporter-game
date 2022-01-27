using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace devlog98.Backdoor {
    public class CreateInventory : MonoBehaviour
    {
        public ItemReference element;
        public List<CollectableItem> inventory;
        public static CreateInventory instance; // reference to inventory

        private void Awake() {
            if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
            }
        }
        //Ao iniciar o objeto, verifica a lista de itens do inventario e instancia os widgets
        void Start()
        {
            inventory = new List<CollectableItem>();
            inventory = FindObjectOfType<PlayerInventory>().Inventory();
            InstantiateElements();
        }
        //Função para instanciar o widgets
        public void InstantiateElements(){
            for(int i = 0; i < inventory.Count; i++){
                (Instantiate(element, transform) as ItemReference).SetValues(
                    inventory[i]);
            }
        }
        //Adicionar elemento unico
        public void AddElement(CollectableItem item){
            (Instantiate(element, transform) as ItemReference).SetValues(
                    item);
        }
    }
}
