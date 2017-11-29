using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseSkill : MonoBehaviour
{
public  GameObject playerGameObject;
public  GameObject cardGameObject;
Card _card;
PlayerSkillSet _playerSkillSet;
Player _playerscript;
void Awake()
{
    _playerSkillSet = playerGameObject.GetComponent<PlayerSkillSet>();
    _card = cardGameObject.GetComponent<Card>();
    _playerscript = GetComponentInParent<Player>().GetComponent<Player>();
}
void Start()
{
    //Debug.Log(_card.cardSkill);
    _playerSkillSet.AddSkillToPlayer(_card.cardSkill);
   
}
    void Update()
    {
        //Debug.Log(transform.localScale);
        //seurataan pelaajan kääntymistä scalella
       /*Vector3 _scale = transform.localScale;
       _scale.x = transform.parent.localScale.z;*/

        //P1FIRE
        if (_playerscript.playerType == GameTypes.PlayerType.player1)
        {
            if (Input.GetButtonDown("P1Fire"))
            {
                //Luo kortissa määritellyn prefabin(effektin)
                /* GameObject  clone = Instantiate(_card.effect, transform.position,transform.rotation);
                 clone.transform.localScale = _scale;*/
                // clone.transform.parent = transform.parent;
                _playerSkillSet.UseSkillOnPlayer(_card.cardSkill);
                _playerSkillSet.RemoveSkillToPlayer(_card.cardSkill);
            }
        }
        if (_playerscript.playerType == GameTypes.PlayerType.player2)
        {
            if (Input.GetButtonDown("P2Fire"))
            {
                //Luo kortissa määritellyn prefabin(effektin)
                /* GameObject  clone = Instantiate(_card.effect, transform.position,transform.rotation);
                 clone.transform.localScale = _scale;*/
                // clone.transform.parent = transform.parent;
                _playerSkillSet.UseSkillOnPlayer(_card.cardSkill);
                _playerSkillSet.RemoveSkillToPlayer(_card.cardSkill);
            }
        }
    }
}
