using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MidLine : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public Transform playerLine1;
    public Transform playerLine2;
    [SerializeField] TextMeshProUGUI ammunation;
    int maxCard = 5;
    StateManager stateManager;
    string Ownerside;
    public void OnDrop(PointerEventData eventData)
    {
        if (this.gameObject.transform.childCount == 0) { Ownerside = "None"; }
        else
        {
            Ownerside = gameObject.transform.GetChild(0).tag;
        }
        
        // Eğer tur senin değilse sonlandır
        if (!stateManager.isPlayerTurn) { return; }

        
        if (this.gameObject.transform.childCount >= maxCard) { print("maxium card"); return; }

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if (d.gameObject.tag != Ownerside && Ownerside != "None")
        {
            //TODO : Bu saf düşman tarafından kontrol ediliyor duyurusu     
            return;
        }
        if (d.lastParent == transform)
        {
            d.original_parent = this.transform;
            return;
        }

        if  (d.gameObject.CompareTag("Player") && (d.original_parent.transform  != playerLine1.transform && d.original_parent.transform != playerLine2.transform))
        {
          return; 
        }

        Interactive inter = eventData.pointerDrag.gameObject.GetComponent<Interactive>();
        if (!stateManager.MoveCard(inter)) { return; }
        inter.CardLine = 0;
        d.original_parent = this.transform;



    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //print("OnPointerEnter");

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //print(" OnPointerExit");
    }
    private void Start()
    {
        stateManager = FindObjectOfType<StateManager>();
    }
}
