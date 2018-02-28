using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*public enum PlayerType
{
    player1, player2
}*/

public class GameManager : MonoBehaviour {
   public static GameManager gamemanager;
   List<Player> listPlayers;
   public GameTypes.PlayerType _player;
   bool TimeGoingDown = false, playerisdead = false;
   public bool TimeScaleOff = true;
   ///UIRoundOver _uiRoundOver;
   public GameObject RoundOverCanvas;
   private bool _isRunning = false;
   private Effect_Container _effectContainer;
   PlayerMovement playerMovement1;
   //PlayerUseSkill _playerUseSkill;
   Player2Movement playerMovement2;
    UiTimer uiTimer;
   public bool _player1PickedCard = false;
    StandaloneInputModule _sIM;

    public Effect_Container Effectlist { get 
   {
       if (_effectContainer == null)
       {
           _effectContainer = Resources.Load<Effect_Container>("SpellEffectList");
       }
       return _effectContainer;
   } }
	// Use this for initialization
	void Awake () {
        gamemanager = this;
        listPlayers = new List<Player>();
        _sIM = FindObjectOfType<StandaloneInputModule>();
        if(_sIM == null)
        {
            Debug.Log("VOi vittu saatana perkele");
        }
        if (RoundOverCanvas == null)
        {
            Debug.Log("RounoverCanvas on NULL");
        }

        RoundOverCanvas.SetActive(false);

        /*if (TimeScaleOff)
        {
            StopTimeScale();
        }*/
	}
	
	// Update is called once per frame
	void Update () {

        /*if (Time.timeScale > 0 && TimeGoingDown == false && playerisdead == true)
        {
            StartCoroutine(SlowTimeScale());
        }*/
	}
    public void AddPlayer(Player player)
    {
        listPlayers.Add(player);
    }
   
    public Player GetPlayer(GameTypes.PlayerType player)
    {
        foreach (var p in listPlayers)
        {
            if (p.playerType == player)
                return p;
        }
        return null;
    }
   /* public void StopTimeScale()
    {
      Time.timeScale = 0;
    }

   IEnumerator SlowTimeScale()
    {
        TimeGoingDown = true;
        float slowtimer = 0.1f;
        yield return new  WaitForSeconds(0.2f);
        if (Time.timeScale < 0.1f)
        {
            StopTimeScale();
        }
        else
        {
            Time.timeScale -= slowtimer;
        }
        TimeGoingDown = false;
    }*/

    public void StartTimeScale()
    {
        //UiTimer.uiTimer.StartTimer();
        uiTimer = FindObjectOfType<UiTimer>();
        uiTimer.StartTimer();
        Time.timeScale = 1;
        //Debug.Log("Aika käynnistetty" + Time.timeScale);
    }

    public void EnablePlayerMovements()
    {
        playerMovement1 = FindObjectOfType<PlayerMovement>();
        playerMovement1.EnablePlayerMovement();
        playerMovement2 = FindObjectOfType<Player2Movement>();
        playerMovement2.EnablePlayerMovement2();
        //Etsii objekteista kaikki joissa on PlayerUseSKill ja sitten kutsuu niissä metodia joka mahdollistaa pelaajia käyttämään skillejä
        PlayerUseSkill[] _playerUseSkill = FindObjectsOfType(typeof(PlayerUseSkill)) as PlayerUseSkill[];
        foreach (PlayerUseSkill _playerSkill in _playerUseSkill)
        {
            _playerSkill.PlayerCanMove();
        }
        //_playerUseSkill = FindObjectOfType<PlayerUseSkill>();
        //_playerUseSkill.PlayerCanMove();
    }

    public void DisablePlayerMovements()
    {
        playerMovement1 = FindObjectOfType<PlayerMovement>();
        playerMovement1.DisablePlayerMovement();
        playerMovement2 = FindObjectOfType<Player2Movement>();
        playerMovement2.DisablePlayerMovement2();
        //Etsii objekteista kaikki joissa on PlayerUseSKill ja sitten kutsuu niissä metodia joka estää pelaajia käyttämästä skilliä
        PlayerUseSkill[] _playerUseSkill = FindObjectsOfType(typeof(PlayerUseSkill)) as PlayerUseSkill[];
        foreach (PlayerUseSkill _playerSkill in _playerUseSkill)
        {
            _playerSkill.PlayerCantMove();
        }
        /* _playerUseSkill = FindObjectOfType<PlayerUseSkill>();
         _playerUseSkill.PlayerCantMove();*/
    }

    public void Winner(Player _player)
    {
        DisablePlayerMovements();
        uiTimer = FindObjectOfType<UiTimer>();
        uiTimer.StopTimer();
        if (_player != null)
        {
            Player winner = null;
            foreach (var p in listPlayers)
            {
                if (p != _player)
                {
                    winner = p;
                }

            }
            playerisdead = true;
            RoundOverCanvas.SetActive(true);
            UIRoundOver _uiroundover = RoundOverCanvas.GetComponentInChildren<UIRoundOver>();
            _uiroundover.Show(winner);
            EndingCanvasButton _endingbutton = FindObjectOfType<EndingCanvasButton>();
            _endingbutton.SetEndingCanvasButton();
        }
        else
        {
            RoundOverCanvas.SetActive(true);
            UIRoundOver _uiroundover = RoundOverCanvas.GetComponentInChildren<UIRoundOver>();
            _uiroundover.ShowNoOneWins();
            EndingCanvasButton _endingbutton = FindObjectOfType<EndingCanvasButton>();
            _endingbutton.SetEndingCanvasButton();
        }
    }

    public void Player1PickedACard()
    {
        // Draggable-scripti sidonnainen. tsekkailee kumman vuoro on ottaa kortti. Pelaaja 1 valitsee kun _player1PickedCard = false
        _sIM.horizontalAxis = "P2XAxis";
        _sIM.verticalAxis = "P2Vertical";
        _player1PickedCard = true;

        

    }
    public void Player2PickedACard()
    {
        // Draggable-scripti sidonnainen. tsekkailee kumman vuoro on ottaa kortti. Pelaaja 2 valitsee kun _player1PickedCard = ´true
        _sIM.horizontalAxis = "Horizontal";
        _sIM.verticalAxis = "Vertical";
        _player1PickedCard = false;
        
    }
}
