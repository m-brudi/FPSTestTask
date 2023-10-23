using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableGreen : DamagableObject
{
    [SerializeField] int hp;
    [SerializeField] GameObject effects;

    private void Update() {
        transform.Rotate(Vector3.right * (20* Time.deltaTime));
    }
    public override void Hit() {
        hp--;
        if (hp == 0) {
            Instantiate(effects, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
