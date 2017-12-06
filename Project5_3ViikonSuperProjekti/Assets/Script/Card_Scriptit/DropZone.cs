using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {    //Laita tämä siihen paneliin mihin haluat kortien menevän.
    //ENABLE MYÖHEMMIN
    //public Draggable.Slot typeOfItem = Draggable.Slot.INVENTORY;
    //linkki tutoriaalin kolmanteen osaan https://youtu.be/AM7wBz9azyU

    //Hiiri on kortin yllä
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }
          Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
          if (d != null)
          {
              d.placeholderParent = this.transform;
          }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }
    }
    //Pudotetaan kortti pudotus alueelle
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + "was dropped on"+ gameObject.name);
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;

            //Tutustu tähän myöhemmin
            /*if (typeOfItem == d.typeOfItem || typeOfItem == Draggable.Slot.INVENTORY)
            {
                // d.parentToReturnTo = this.transform;
            }*/
        }
    }
}
