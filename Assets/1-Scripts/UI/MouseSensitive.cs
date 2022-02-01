using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace devlog98.Backdoor {
    public class MouseSensitive : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private ItemReference reference;
        private Color color;
        void Start()
        {
            reference = GetComponent<ItemReference>();
            ChangeColor(Color.gray);
        }

        public void OnPointerClick(PointerEventData eventData)
        {

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            ChangeColor(Color.white);
            Debug.Log("olhaeu");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ChangeColor(Color.gray);
        }

        private void ChangeColor(Color color){
            reference.icon.color = color;
        }

    }
}
