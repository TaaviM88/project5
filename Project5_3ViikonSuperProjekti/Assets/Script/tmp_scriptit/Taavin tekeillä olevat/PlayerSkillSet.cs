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
          public HashSet<Skills.Skill> skills;
          public PlayerStats()
          {
              skills = new HashSet<Skills.Skill>();
          }

          //public List<Skills.Skill> skills;
      }
    }
  namespace Skills
  {
      public enum Skill
      {
          Fireball,
          IceStorm,
          Shield,
          Meteor
      }
      
  public static class Strings
  {
    
      public static Dictionary<Skill, string> SkillNames = new Dictionary<Skill, string>()
      {
          {Skill.Fireball, "Fireball"},
          {Skill.IceStorm, "Ice Storm"},
          {Skill.Shield,  "Shield"},
          {Skill.Meteor, "Meteor"}
      };
  }
    public static class Actions
      {
      public static Dictionary<Skill, Action<Stats.
          PlayerStats>> SkillActions = new Dictionary<Skill,Action<Stats.PlayerStats>>()
      {
          {Skill.Fireball, (PlayerSkillSet) => {PlayerSkillSet.health -=1; Debug.Log("whoosh"); /* FireBall-prefabin luonti */}},
          {Skill.IceStorm, (PlayerSkillSet) => { PlayerSkillSet.health -= 1; } },
          {Skill.Shield,   (PlayerSkillSet) => {PlayerSkillSet.armor = 1;}},
          {Skill.Meteor,   (PlayerSkillSet) => {PlayerSkillSet.health -= 1;}}
      };
    }
  }

public class PlayerSkillSet : MonoBehaviour {
  public bool debugMessages = true;
  private Stats.PlayerStats _playerStats;

    public void Awake()
    {
      _playerStats = new Stats.PlayerStats();
    }

    public void AddSkillToPlayer(Skills.Skill skill)
    {
      _playerStats.skills.Add(skill);
    }

    public void RemoveSkillToPlayer(Skills.Skill skill)
    {
        //poistaa yhden skillin
        if(_playerStats.skills != null)
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
        if(Skills.Actions.SkillActions.ContainsKey(skill))
        {
            Skills.Actions.SkillActions[skill](_playerStats);
            if(debugMessages)
            {
                Debug.Log("Used" + Skills.Strings.SkillNames[skill]);
            }
        }
    }
	
}
