using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using MoreMountains.Tools;
/*
 * Collectables used to go through level exit
 */

namespace devlog98.Backdoor
{

#pragma warning disable 649

    public class CollectableItem : MonoBehaviour, IMouse
    {
        [Header("Feedbacks")]
        [SerializeField] private MMFeedbacks collectFeedback; // feedbacks
        [SerializeField] private Item item;
        public MMSaveLoadTester saveManager;

        private void Start()
        {
            saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<MMSaveLoadTester>();
            LoadItem();
        }

        // be collected by player
        public void OnMouseDown(InputAction.CallbackContext context)
        {
            Debug.Log("Pegou chave " + item.description);
            CollectItem();
        }

        // be given to player on event
        public void GivePlayer()
        {
            Debug.Log("Obteve " + item.description);
            CollectItem();
        }

        // put item on Player Inventory
        private void CollectItem()
        {
            collectFeedback.PlayFeedbacks();
            PlayerHUD.instance.ShowHint(item.collectHint);
            PlayerInventory.instance.CollectableFound(this);
            CreateInventory.instance.AddElement(this.GetComponent<CollectableItem>());

            // Find Acquired Item in List of Objects in level, then Save
            int length = saveManager.SaveObject.levels[saveManager.SaveObject.curLevel].itemsInLevel.Count;
            for (int i = 0; i < length; i++)
            {
                if (saveManager.SaveObject.levels[saveManager.SaveObject.curLevel].itemsInLevel[i].name == item.displayName)
                {
                    saveManager.SaveObject.levels[saveManager.SaveObject.curLevel].itemsInLevel[i].acquired = true;

                    saveManager.Save();
                    break;
                }
            }
        }

        public void LoadItem()
        {
            // Check if item has already been aquired when game Loads
            int length = saveManager.SaveObject.levels[saveManager.SaveObject.curLevel].itemsInLevel.Count;
            for (int i = 0; i < length; i++)
            {
                if (saveManager.SaveObject.levels[saveManager.SaveObject.curLevel].itemsInLevel[i].name == item.displayName)
                {
                    if (saveManager.SaveObject.levels[saveManager.SaveObject.curLevel].itemsInLevel[i].acquired == true)
                    {
                        PlayerInventory.instance.CollectableFound(this);
                        CreateInventory.instance.AddElement(this.GetComponent<CollectableItem>());
                        break;
                    }
                }
            }


        }

        public Item getItem()
        {
            return item;
        }

        public int getId()
        {
            return item.id;
        }

        public void Destruir()
        {
            Destroy(this.gameObject);
        }

        // unused methods
        public void OnMouseDrag(InputAction.CallbackContext context) { }
        public void OnMouseUp(InputAction.CallbackContext context) { }
    }
}