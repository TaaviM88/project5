using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiTimer : MonoBehaviour {
    public float timer = 30;
    private Text _text;
	// Use this for initialization
    private void Awake()
    {
        _text = GetComponentInChildren<Text>(true);
        //gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (timer <= 0)
        {
            GameManager.gamemanager.Winner(null);
        }
        else { timer -= Time.deltaTime; }
        int minutes = (int)timer / 60;
        //jakojäännös
        int seconds = (int)timer % 60;
        _text.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
	}
}
