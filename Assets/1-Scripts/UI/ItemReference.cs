using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace devlog98.Backdoor {
    public class ItemReference : MonoBehaviour
    {
        public Image icon;
        public TextMeshProUGUI nameDisplay;
        public Item _item {get; private set;}

        public void SetValues(CollectableItem item){
            _item = item.GetComponent<CollectableItem>().getItem();
            icon.sprite = _item.icon;
            nameDisplay.text = _item.displayName;
        }

    }
}
