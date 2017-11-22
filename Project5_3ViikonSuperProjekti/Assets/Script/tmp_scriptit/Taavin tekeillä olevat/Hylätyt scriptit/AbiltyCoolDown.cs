using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbiltyCoolDown : MonoBehaviour {
    public string abiltyButtonAxisName = "Fire3";
    public Image darkMask;
    public Text coolDownTextDisplay;

    [SerializeField] private Ability ability;
    [SerializeField] private GameObject weaponHolder;
    private Image mybuttonImage;
    private AudioSource abiltySource;
    private float coolDownDuration;
    private float nextReadyTime;
    private float coolDownTimeLeft;
	// Use this for initialization
	void Start () 
    {
        Initialize(ability, weaponHolder);
	}

    public void Initialize(Ability selectedAbilty, GameObject weaponHolder)
    {
        ability = selectedAbilty;
        mybuttonImage = GetComponent<Image>();
        abiltySource = GetComponent<AudioSource>();
        mybuttonImage.sprite = ability.aSprite;
        darkMask.sprite = ability.aSprite;
        coolDownDuration = ability.aBaseCoolDown;
        ability.Initialize(weaponHolder);
        AbilityReady();
    }
	
	// Update is called once per frame
	void Update () {
		bool coolDownComplete = (Time.time > nextReadyTime);
        if(coolDownComplete)
        {
            AbilityReady();
            if (Input.GetButtonDown("Fire3"))
            { ButtonTriggered(); }
            
        }
        else { CoolDown(); }
	}

    private void AbilityReady()
    {
        coolDownTextDisplay.enabled = false;
        darkMask.enabled = false;
    }
    private void CoolDown()
    { 
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(coolDownTimeLeft);
        coolDownTextDisplay.text = roundedCd.ToString();
        darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
    }

    private void ButtonTriggered()
    {
        nextReadyTime = coolDownDuration + Time.time;
        coolDownTimeLeft = coolDownDuration;
        darkMask.enabled = true;
        coolDownTextDisplay.enabled = true;
        abiltySource.clip = ability.aSound;
        //abiltySource.play();
        ability.TriggerAbility();
    }
}
