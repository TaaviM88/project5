using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCountDowntimer : MonoBehaviour {

    public void StartGame()
    {
        GameManager.gamemanager.EnablePlayerMovements();
        GameManager.gamemanager.StartTimeScale();
        this.gameObject.SetActive(false);
    }
}
