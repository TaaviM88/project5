using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseSkill : MonoBehaviour
{
public  GameObject playerGameObject;
public  GameObject cardGameObject;
Card _card;
PlayerSkillSet _player;
void Awake()
{
    _player = playerGameObject.GetComponent<PlayerSkillSet>();
    _card = cardGameObject.GetComponent<Card>();
}
void Start()
{
    //Debug.Log(_card.cardSkill);
    _player.AddSkillToPlayer(_card.cardSkill);
   
}
    void Update()
    {
        Debug.Log(transform.localScale);
        //seurataan pelaajan kääntymistä scalella
       Vector3 _scale = transform.localScale;
       _scale.x = transform.parent.localScale.z;

        //P1FIRE
        if (Input.GetButtonDown("P1Fire"))
        {   
         //Luo kortissa määritellyn prefabin(effektin)
         GameObject  clone = Instantiate(_card.effect, transform.position,transform.rotation);
         clone.transform.localScale = _scale;
        // clone.transform.parent = transform.parent;
            _player.UseSkillOnPlayer(_card.cardSkill);
            _player.RemoveSkillToPlayer(_card.cardSkill);
        }
    }
}
