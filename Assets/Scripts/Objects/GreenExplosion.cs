using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenExplosion : MonoBehaviour
{
    [SerializeField] Rigidbody[] parts;
    [SerializeField] float force;
    private void Start() {
        foreach (var item in parts) {
            Vector3 dir = item.transform.position - transform.position;
            dir.Normalize();
            item.AddForce(dir * force, ForceMode.Impulse);
        }
    }
}
