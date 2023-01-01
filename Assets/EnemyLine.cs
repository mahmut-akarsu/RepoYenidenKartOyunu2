using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyLine : MonoBehaviour, IDropHandler
{
    [SerializeField]
    //TextMeshProUGUI text;
    public void OnDrop(PointerEventData eventData)
    {
        //text.text = "Here is enemy line";
        if (eventData.pointerDrag.tag != "Enemy") { return; }
        Interactive inter = eventData.pointerDrag.GetComponent<Interactive>();
        inter.isPlayed = true;
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        d.original_parent = this.transform;
        inter.CardLine = -1;
        
    }

}
