using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Skill", menuName = "Skills/Projectiles")]
public class ProjectileSkill : Skill 
{
    public int _numberOfProjectiles;
    public GameObject _projectile;

    public override (int, GameObject) GetProjectile()
    {
        return (_numberOfProjectiles, _projectile);
    }
}
