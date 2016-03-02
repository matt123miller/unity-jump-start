using UnityEngine;
using System.Collections;

public class Projectile : GiveDamageToTarget {

    public override void GiveDamageBehaviour()
    {
        Destroy(gameObject);
    }
}
