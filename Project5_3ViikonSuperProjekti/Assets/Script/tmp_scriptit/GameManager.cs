using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
   Player2Movement playerMovement2;
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
        if (RoundOverCanvas == null)
        {
            Debug.Log("RounoverCanvas on NULL");
        }

        RoundOverCanvas.SetActive(false);

        if (TimeScaleOff)
        {
            StopTimeScale();
        }
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Time.timeScale + "TimeScale");

        if (Time.timeScale > 0 && TimeGoingDown == false && playerisdead == true)
        {
            StartCoroutine(SlowTimeScale());
        }
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
    public void StopTimeScale()
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
    }
    public void StartTimeScale()
    {
        UiTimer.uiTimer.StartTimer();
        //Time.timeScale = 1;
        //Debug.Log("Aika käynnistetty" + Time.timeScale);
    }

    public void EnablePlayerMovements()
    {
        playerMovement1 = FindObjectOfType<PlayerMovement>();
        playerMovement1.EnableDisablePlayerMovement();
        playerMovement2 = FindObjectOfType<Player2Movement>();
        playerMovement2.EnableDisablePlayerMovement2();
    }

    public void Winner(Player _player)
    {
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
        }
        else
        {
            RoundOverCanvas.SetActive(true);
            UIRoundOver _uiroundover = RoundOverCanvas.GetComponentInChildren<UIRoundOver>();
            _uiroundover.ShowNoOneWins();
        }
    }
}
