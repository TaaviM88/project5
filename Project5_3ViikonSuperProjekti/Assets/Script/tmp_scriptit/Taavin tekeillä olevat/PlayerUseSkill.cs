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
        //P1FIRE
        if (Input.GetButtonDown("P1Fire"))
        {   
            Instantiate(_card.effect, transform.position,transform.rotation);
            _player.UseSkillOnPlayer(_card.cardSkill);
            _player.RemoveSkillToPlayer(_card.cardSkill);
        }
    }
}
