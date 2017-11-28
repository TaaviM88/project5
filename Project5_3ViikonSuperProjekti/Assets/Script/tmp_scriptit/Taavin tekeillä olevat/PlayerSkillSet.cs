using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Stats
{
    public class PlayerStats
    {
        public float health = 1.0f;
        public int strength = 6;
        public int wisdom = 6;
        public int armor = 0;
        public List<Skills.Skill> skills;
        public PlayerStats()
        {
            skills = new List<Skills.Skill>();
        }

        //public List<Skills.Skill> skills;
    }
}
namespace Skills
{
    public enum Skill
    {
        None,
        Fireball,
        FireArrow,
        IceArrow,
        IceStorm,
        Shield,
        Meteor,
        Plasma
    }

    public static class Strings
    {

        public static Dictionary<Skill, string> SkillNames = new Dictionary<Skill, string>()
      {
          {Skill.Fireball, "Fireball"},
          {Skill.FireArrow, "Fire Arrow"},
          {Skill.IceArrow, "Ice Arrow"},
          {Skill.IceStorm, "Ice Storm"},
          {Skill.Shield,  "Shield"},
          {Skill.Meteor, "Meteor"},
          {Skill.Plasma, "Plasma"}
      };
    }
    public static class Actions
    {
        public static Dictionary<Skill, Action<Stats.
            PlayerStats, Player>> SkillActions = new Dictionary<Skill, Action<Stats.PlayerStats, Player>>()
      {
          {Skill.Fireball, (PlayerSkillSet, Player) => {
              PlayerSkillSet.health -=1; 
              Debug.Log("whoosh");
              /* FireBall-prefabin luonti */
              GameObject _prefab = GameManager.gamemanager.Effectlist.GetEffect(Skill.Fireball);
              GameObject clone = UnityEngine.Object.Instantiate(_prefab, Player.transform.position, Player.transform.rotation);
             /*Vector3 _scale = clone.transform.localScale;
             _scale.z = Player.transform.localScale.z;
             clone.transform.localScale = _scale;*/
              //clone.transform.localScale = Player.transform.localScale;
          }},
          {Skill.FireArrow, (PlayerSkillSet, Player) => {
              PlayerSkillSet.health -= 1;
              GameObject _prefab = GameManager.gamemanager.Effectlist.GetEffect(Skill.FireArrow);
              GameObject clone = UnityEngine.Object.Instantiate(_prefab, Player.GetComponentInChildren<PlayerUseSkill>().transform.position, Player.transform.rotation);
              //Debug.Log((Player.GetComponentInParent<Transform>().localScale.z));
              Debug.Log(Player.transform.localScale);
              if( Player.transform.localScale.z == -1)
              {
                  clone.GetComponent<Bullet>().ChangeDirection();
              }
             /* if(Player.GetComponentInParent<Transform>().localScale.z == -1)
              {
                  Debug.Log("pelaaja katsoo vasemmalle"+(Player.GetComponentInParent<Transform>().localScale.z));
                   clone.GetComponent<Bullet>().ChangeDirection();
              }*/
             
              
          }},
          {Skill.IceArrow, (PlayerSkillSet, Player) => {
              PlayerSkillSet.health -= 1;
              GameObject _prefab = GameManager.gamemanager.Effectlist.GetEffect(Skill.IceArrow);
              GameObject clone = UnityEngine.Object.Instantiate(_prefab, Player.GetComponentInChildren<PlayerUseSkill>().transform.position, Player.transform.rotation);
              if (Player.transform.localScale.z == -1)
              {

                  clone.GetComponent<Bullet>().ChangeDirection();
              }
          }},
          {Skill.IceStorm, (PlayerSkillSet, Player) => {PlayerSkillSet.health -= 1;
            GameObject _prefab = GameManager.gamemanager.Effectlist.GetEffect(Skill.IceStorm);
              if(Player.transform.localScale.z == 1)
              {
                  GameObject clone = UnityEngine.Object.Instantiate(_prefab, Player.GetComponentInChildren<PlayerUseSkill>().transform.position + new Vector3(5, -1, Player.transform.position.z), Player.transform.rotation);
              }
           
           if (Player.transform.localScale.z == -1)
            {
                GameObject clone = UnityEngine.Object.Instantiate(_prefab, Player.GetComponentInChildren<PlayerUseSkill>().transform.position + new Vector3(-5, -1, Player.transform.position.z), Player.transform.rotation);
                //clone.GetComponent<Bullet>().ChangeDirection();
            }
          }},
          {Skill.Shield,   (PlayerSkillSet, Player) => {
              PlayerSkillSet.armor = 1;
              GameObject _prefab = GameManager.gamemanager.Effectlist.GetEffect(Skill.Shield);
              GameObject clone = UnityEngine.Object.Instantiate(_prefab, Player.GetComponentInChildren<PlayerUseSkill>().transform.position, Player.transform.rotation);
              if (Player.transform.localScale.z == -1)
              {

                  clone.GetComponent<Bullet>().ChangeDirection();
              }
          }},
          {Skill.Meteor,   (PlayerSkillSet, Player) => {PlayerSkillSet.health -= 1;}},
      };
    }
}

public class PlayerSkillSet : MonoBehaviour
{
    public bool debugMessages = true;
    private Stats.PlayerStats _playerStats;
    Player _player;

    public void Awake()
    {
        _playerStats = new Stats.PlayerStats();
        _player = GetComponentInParent<Player>();
    }

    public void AddSkillToPlayer(Skills.Skill skill)
    {
        _playerStats.skills.Add(skill);
    }

    public void RemoveSkillToPlayer(Skills.Skill skill)
    {
        //poistaa yhden skillin
        if (_playerStats.skills != null)
        {
            _playerStats.skills.Remove(skill);
        }

    }
    public void clearSkillToPlayer(Skills.Skill skill)
    {
        //tyhjentää koko listan
        if (_playerStats.skills != null)
        {
            _playerStats.skills.Clear();
        }
    }


    public void UseSkillOnPlayer(Skills.Skill skill)
    {
        if (Skills.Actions.SkillActions.ContainsKey(skill))
        {
            Skills.Actions.SkillActions[skill](_playerStats,_player);
            if (debugMessages)
            {
                Debug.Log("Used" + Skills.Strings.SkillNames[skill]);
            }
        }
    }

}
