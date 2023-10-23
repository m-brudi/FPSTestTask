using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] MeshRenderer mr;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject impact;
    int myType;
    Material mat;
    public void Setup(float speed, Vector3 dir, int type, Material mat) {

        if (type == 2) {
            rb.mass = 50;
            rb.drag = 1;
            speed = 15;
        }
        myType = type;
        StartCoroutine(DestroyAfterSomeTime(3));
        //transform.DOScale(.3f, 0.1f);
        rb.AddForce(dir * speed, ForceMode.VelocityChange);
        this.mat = mat;
        mr.material = mat;
    }

    IEnumerator DestroyAfterSomeTime(float time) {
        yield return new WaitForSeconds(time);
        if(myType == 2)Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        if (myType == 2) {
            Instantiate(explosion, transform.position, Quaternion.identity);
        } else {
            ParticleSystemRenderer imp = Instantiate(impact, transform.position, Quaternion.identity).GetComponent<ParticleSystemRenderer>();
            imp.material = mat;
            if (collision.gameObject.TryGetComponent(out DamagableObject obj)) {
                if (obj.MyType == myType) {
                    obj.Hit();
                }
            }
        }
        Destroy(gameObject);
    }
}
