using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Spell/Create Effects")]
public class Effect_Container : ScriptableObject{
    [System.Serializable]
    public struct SpellEffect
    {
        public Skills.Skill skill;
        public GameObject effect;
    }
    public List<SpellEffect> EffectList = new List<SpellEffect>();

    public GameObject GetEffect(Skills.Skill skill)
    {
        for (int i = 0; i < EffectList.Count; i++)
        {
            if (EffectList[i].skill == skill)
            {
                return EffectList[i].effect;
            }
        }
        return null;
    }
}
