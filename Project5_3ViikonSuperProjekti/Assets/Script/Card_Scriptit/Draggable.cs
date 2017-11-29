using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    //Laita tämä niihin asioita mitä voi raahata hiirellä.
   public Transform parentToReturnTo = null;
   public Transform placeholderParent = null;
   GameObject placeholder = null;
   private Player _player;
  /* public enum Slot { WEAPON, HEAD, CHEST, LEGS, FEET, INVENTORY };
   public Slot typeOfItem = Slot.WEAPON;*/
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;
        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        

        //Voi tehdä esim hohto efektin dropzone:lle
        //DropZone[] zones =  GameObject.FindObjectsOfType<DropZone>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        this.transform.position = eventData.position;
        if (placeholder.transform.parent != placeholderParent)
            placeholderParent.transform.SetParent(placeholderParent);
        int newSiblingindex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {
                //placeholder.transform.SetSiblingIndex(i);
                newSiblingindex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingindex)
                {
                    newSiblingindex--;
                }
                break;
            }
        }
        placeholder.transform.SetSiblingIndex(newSiblingindex);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent.name == "Player1_tab")
        {
           
           _player = GameManager.gamemanager.GetPlayer(GameTypes.PlayerType.player1);
           Debug.Log(_player);
            Card _card = GetComponent<Card>();
           
			_player.AddCardToPlayer(_card);
			Debug.Log(_card+"Vittu");
            //kortilla saadaan skillin tiedot, pelaajalla pitää olla playerskillset. Player1 on skillsetti addtoplayer metodilla 
        }
        if (transform.parent.name == "Player2_tab")
        {
          _player =  GameManager.gamemanager.GetPlayer(GameTypes.PlayerType.player2);
            
        }
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        Destroy(placeholder);
        //Ota hohto efekti pois päältä jos tehty
        //Tsekkailee mitä on kortin alla.
        //EventSystem.current.RaycastAll(eventData)

    }
}
