using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableBlue : DamagableObject
{
    [SerializeField] int hp;
    public override void Hit() {
        hp--;
        if(hp == 0) {
            Destroy(gameObject);
        }
    }
}
