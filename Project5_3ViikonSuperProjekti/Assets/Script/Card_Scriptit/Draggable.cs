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
    Button button;
    /* public enum Slot { WEAPON, HEAD, CHEST, LEGS, FEET, INVENTORY };
     public Slot typeOfItem = Slot.WEAPON;*/
   
    void Start()
    {
        UpdateButtonNavigation();
    }

    void Update()
    {
        //Kesken
        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);

        if (EventSystem.current.currentSelectedGameObject.name == this.gameObject.name)
        {
            if (Input.GetButtonDown("P1Jump"))
            {
                _player = GameManager.gamemanager.GetPlayer(GameTypes.PlayerType.player1);
                if(_player._cardList.Count <= 6)
                { //Debug.Log(_player);
                    Card _card = GetComponent<Card>();
                    Player1Tab_Script _player1tab = FindObjectOfType<Player1Tab_Script>();

                    if (this.transform.parent.name == "Hand")
                    {
                        this.transform.SetParent(_player1tab.transform);
                        _player.AddCardToPlayer(_card);
                    }
                    else
                    {
                        CardSpawner _cardSpawner = FindObjectOfType<CardSpawner>();
                        this.transform.SetParent(_cardSpawner.transform);         
                        _player.RemoveCardFromPlayer(_card);
                    }
                    //transform.localPosition = new Vector3(0, 0, 0);
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), Time.deltaTime/2);
                    UpdateButtonNavigation();
                    
                }
               
            }

            if (Input.GetButtonDown("P2Jump"))
            {
                _player = GameManager.gamemanager.GetPlayer(GameTypes.PlayerType.player2);
                if (_player._cardList.Count <= 6)
                {
                    Card _card = GetComponent<Card>();
                    
                    Player2Tab_Script _player2tab = FindObjectOfType<Player2Tab_Script>();
                    if (this.transform.parent.name == "Hand")
                    {
                        this.transform.SetParent(_player2tab.transform);
                        _player.AddCardToPlayer(_card);
                    }
                    else
                    {
                        CardSpawner _cardSpawner = FindObjectOfType<CardSpawner>();
                        this.transform.SetParent(_cardSpawner.transform);
                        _player.RemoveCardFromPlayer(_card);
                    }
                        
                    //transform.localPosition = new Vector3(0, 0, 0);
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), Time.deltaTime/2);
                    UpdateButtonNavigation();
                }
                    
            }
        }
    }

    //kortti otetaan hiireen
    public void OnBeginDrag(PointerEventData eventData)
    {
       // Debug.Log("OnBeginDrag");
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
        
        
        }
        //Voi tehdä esim hohto efektin dropzone:lle
        //DropZone[] zones =  GameObject.FindObjectsOfType<DropZone>();

   
    //Korttia raahataan
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
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
    //kortti laitettu pois
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");

        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent.name == "Player1_tab")
        {
           
           _player = GameManager.gamemanager.GetPlayer(GameTypes.PlayerType.player1);
           //Debug.Log(_player);
           Card _card = GetComponent<Card>();
           
			_player.AddCardToPlayer(_card);

            //kortilla saadaan skillin tiedot, pelaajalla pitää olla playerskillset. Player1 on skillsetti addtoplayer metodilla 
        }
        if (transform.parent.name == "Player2_tab")
        {
          _player =  GameManager.gamemanager.GetPlayer(GameTypes.PlayerType.player2);
          Card _card = GetComponent<Card>();
          _player.AddCardToPlayer(_card);
            
        }
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        Destroy(placeholder);
        //Ota hohto efekti pois päältä jos tehty
        //Tsekkailee mitä on kortin alla.
        //EventSystem.current.RaycastAll(eventData)
    }

    public void UpdateButtonNavigation()
    {
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.Log("Button puuttuu");
        }
        else
        {
            button.navigation = Navigation.defaultNavigation;
        }
    }
}
