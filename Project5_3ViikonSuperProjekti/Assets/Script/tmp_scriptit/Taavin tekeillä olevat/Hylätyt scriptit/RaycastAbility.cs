using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Abilities/Raycastability")]
public class RaycastAbility : Ability
{

    public int magicDamage = 1;
    public float magicRange = 50f;
    public float hitForce = 100f;
    public Color laserColor = Color.white;
    //https://unity3d.com/learn/tutorials/topics/scripting/ability-system-scriptable-objects
    //ampumis scripti?
    //private RaycastShootTriggerable rcShoot;

    public override void Initialize(GameObject obj)
    {
        /*    rcShoot = obj.GetComponent<RaycastShootTriggerable> ();
           rcShoot.Initialize ();

           rcShoot.gunDamage = gunDamage;
           rcShoot.weaponRange = weaponRange;
           rcShoot.hitForce = hitForce;
           rcShoot.laserLine.material = new Material (Shader.Find ("Unlit/Color"));
           rcShoot.laserLine.material.color = laserColor;*/
        throw new System.NotImplementedException();
    }
    public override void TriggerAbility()
    {
        throw new System.NotImplementedException();
        //rcShoot.Fire ();
    }
}
