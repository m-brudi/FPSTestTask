using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start() {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy() {
        DoDamage();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    void DoDamage() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 7);
        foreach (var hitCollider in hitColliders) {
            if(hitCollider.TryGetComponent(out DamagableObject obj)){
                if (obj.MyType == 2) {
                    obj.Hit(transform.position);
                }
            }
        }
    }
}
