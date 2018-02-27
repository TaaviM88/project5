using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Draggable : MonoBehaviour/*, IBeginDragHandler, IDragHandler, IEndDragHandler*/ {
    //Laita tämä niihin asioita mitä voi raahata hiirellä.
   public Transform parentToReturnTo = null;
   public Transform placeholderParent = null;
   GameObject placeholder = null;
   private Player _player;
    Button button; 
    ColorBlock cb;
    bool _isCardPicked = false;
    float CardSizeWidth = 130f;
    float CardSizeHeight = 170f;
    RectTransform rect;    
    /* public enum Slot { WEAPON, HEAD, CHEST, LEGS, FEET, INVENTORY };
     public Slot typeOfItem = Slot.WEAPON;*/

    void Start()
    {
        button = GetComponent<Button>();
        UpdateButtonNavigation();
        rect = GetComponent<RectTransform>();
        //tallennetaan korttien koot(Poista tämä kun nää luvut on annettu korteille width 200,23 & height 288,9)
        CardSizeWidth = rect.sizeDelta.x;
        CardSizeHeight = rect.sizeDelta.y;
    }

    void Update()
    {
        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        if (GameManager.gamemanager._player1PickedCard == false)
        {
            cb = button.colors;
            //cb.highlightedColor = Color.cyan;
            //Sininenväri
            cb.highlightedColor = new Color32(0,95,255,255);
            button.colors = cb;
        }
        else
        {
            cb = button.colors;
            //Punainenväri
            cb.highlightedColor = new Color32(255, 0, 30, 255);    
            button.colors = cb;
        }
        if(EventSystem.current.currentSelectedGameObject != null)
        {

        if (EventSystem.current.currentSelectedGameObject.name == this.gameObject.name)
        {
            //Kortin pieni heilunta animaatio
            float angle = Mathf.PingPong(Time.time * 10, 2) - 2;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
            if (Input.GetButtonDown("P1Jump") && GameManager.gamemanager._player1PickedCard == false && _isCardPicked == false)
            {
                MoveCardtoPlayer1();
            }

            if (Input.GetButtonDown("P2Jump") && GameManager.gamemanager._player1PickedCard == true && _isCardPicked == false)
            {
                MoveCardtoPlayer2();
            }
        }
        else
        {
            //Resetoidaan kortin rotaatio
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //Muutetaan kortin koko takaisin samanlaiseksi mitä oli aluksi
			rect.sizeDelta = new Vector2(CardSizeWidth,CardSizeHeight);
            return;
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, transform.position.z), 0.1f * Time.deltaTime);
        }
       
        //float angle = Mathf.Sin(Time.time) * 1; 
        /*if(_isCardPicked == true)
        {
            //Muutetaan korttien koko peinemmäksi, jotta mahtuvat paremmin canvaksessa oleviin paikkoihin
            rect.sizeDelta = new Vector2(130,170);
        }*/
        }
        else
        {
            return;
        }
            }

   public void MoveCardtoPlayer1()
    {
        _player = GameManager.gamemanager.GetPlayer(GameTypes.PlayerType.player1);
        if (_player._cardList.Count <= 5)
        { //Debug.Log(_player);
            Card _card = GetComponent<Card>();
            Player1Tab_Script _player1tab = FindObjectOfType<Player1Tab_Script>();

            if (this.transform.parent.name == "Hand")
            {
                //Vaihdetaan kortin parenttia jotta saadaan se siirtymään pois kädestä.
                this.transform.SetParent(_player1tab.transform);
                //Lisätään pelaajan korttilistaan kortti
                _player.AddCardToPlayer(_card);
                //Kerrotaan gamenagerille, että kumman vuoro on valita kortti
                GameManager.gamemanager.Player1PickedACard();
                //Merkataan, että kortti on valittu, jotta sitä ei voida valita uudestaan tai ottaa pois
                CardIsPicked();
                //Käsketään kortin kuvan childin muuttaa kokoansa myös
                ResizeChild();
            }
            else
            {
                //Sitä varten jos haluttaisiin, että pelaajat vois ottaa korttinsa myös pois
                //Aiheuttaa bugeja joten ei suositella.
                CardSpawner _cardSpawner = FindObjectOfType<CardSpawner>();
                this.transform.SetParent(_cardSpawner.transform);
                _player.RemoveCardFromPlayer(_card);
            }
            //Varmistetaan, että kortit pysyvät keskellä, eivätkä lähde vaeltamaan.
            transform.localPosition = new Vector3(0, 0, 0);
            //Päivitetään nappinavigointi
            UpdateButtonNavigation();
        }
    }

    public void MoveCardtoPlayer2()
    {
        _player = GameManager.gamemanager.GetPlayer(GameTypes.PlayerType.player2);
        if (_player._cardList.Count <= 5)
        {
            Card _card = GetComponent<Card>();

            Player2Tab_Script _player2tab = FindObjectOfType<Player2Tab_Script>();
            if (this.transform.parent.name == "Hand")
            {
                this.transform.SetParent(_player2tab.transform);
                _player.AddCardToPlayer(_card);
                GameManager.gamemanager.Player2PickedACard();
                CardIsPicked();
                ResizeChild();
            }
            else
            {
                CardSpawner _cardSpawner = FindObjectOfType<CardSpawner>();
                this.transform.SetParent(_cardSpawner.transform);
                _player.RemoveCardFromPlayer(_card);
            }

            transform.localPosition = new Vector3(0, 0, 0);
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), Time.deltaTime / 2);
            UpdateButtonNavigation();
        }

    }
    //kortti otetaan hiireen
    /* 
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
    }*/

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
    public void CardIsPicked()
    {
        MakeCardSmaller();
        _isCardPicked = true;
    }

    public void ResizeChild()
    {
        CardImage_controller _child = GetComponentInChildren<CardImage_controller>();
        _child.ResizeSize();
    }

    public void MakeCardSmaller()
    {
        //Muutetaan korttien koko peinemmäksi, jotta mahtuvat paremmin canvaksessa oleviin paikkoihin
        rect.sizeDelta = new Vector2(130,170);

    }
}
