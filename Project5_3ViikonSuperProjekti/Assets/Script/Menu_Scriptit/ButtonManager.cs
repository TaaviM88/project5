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
        _canvas.SetActive(false);
    }

    public void CanvasEnable()
    {
        _canvas.SetActive(true);
    }
}
