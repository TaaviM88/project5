using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour {

    public AudioClip ButtonSoundEffect;
    private AudioSource source;
    public GameObject _canvas;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void NewGameBtn(string newGameLevel)
    {
        source.PlayOneShot(ButtonSoundEffect);
        SceneManager.LoadScene(newGameLevel);
        Time.timeScale = 1;
    }
    public void ExitGameBtn()
    {
        source.PlayOneShot(ButtonSoundEffect);
        Application.Quit();
    }
    public void CanvasDisable()
    {
        GameManager.gamemanager.EnablePlayerMovements();
        GameManager.gamemanager.StartTimeScale();
        _canvas.SetActive(false);
        
        
    }

    public void CanvasEnable()
    {
        _canvas.SetActive(true);
    }
    public void MoveCanvas()
    {
        transform.position += new Vector3(1000, 0, 0);
        RectTransform  canvasRect = gameObject.GetComponent<RectTransform>();
        canvasRect.position = new Vector3(1000, 0, 0);
        GameManager.gamemanager.StartTimeScale();       
    }
}
