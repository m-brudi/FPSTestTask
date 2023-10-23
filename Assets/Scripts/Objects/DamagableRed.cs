using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamagableRed : DamagableObject
{
    [SerializeField] Material red;
    BoxCollider coll;
    Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<BoxCollider>();
        rb.isKinematic = true;
    }

    public override void Hit(Vector3 pos) {
        rb.isKinematic = false;
        Vector3 dir = transform.position - pos;
        dir.Normalize();
        rb.AddForce(dir * dir.magnitude*30, ForceMode.Impulse);
    }

}
