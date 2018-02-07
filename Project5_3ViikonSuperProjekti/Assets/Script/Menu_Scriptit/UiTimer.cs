using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiTimer : MonoBehaviour {
    public float timer = 30;
    private Text _text;
    bool startTimer = false;
	// Use this for initialization
    private void Awake()
    {
        _text = GetComponentInChildren<Text>(true);
        //gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (startTimer == true)
        {
            if (timer <= 0)
            {
                GameManager.gamemanager.Winner(null);
            }
            else { timer -= Time.deltaTime; }
            int minutes = (int)timer / 60;
            //jakojäännös
            int seconds = (int)timer % 60;
            _text.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");

            if (timer <= 10)
            {
                //_text.fontSize = 38;
                if (_text.fontSize < 58)
                {
                    _text.fontSize += 1;

                }
                //_text.color = Color.red;
                //_text.fontStyle = FontStyle.Bold;

            }
        }
	}

    public void StartTimer()
    {
        startTimer = true;
    }

    public void StopTimer()
    {
        startTimer = false;
    }
}
