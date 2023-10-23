using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GunController : MonoBehaviour
{
    [SerializeField] MeshRenderer gunTypeIndicator;
    [SerializeField] WeaponReadyIndicator weaponIndicator;
    [SerializeField] Transform shootPos;
    [SerializeField] Transform gun;
    [SerializeField] Bullet bullet;
    [SerializeField] Material[] gunTypeMaterials;
    [SerializeField] float bullSpeed;
    [SerializeField] float[] shootDelays;
    int currGunInd;
    bool canShoot;
    float shootTimer = 0;

    private void Start() {
        canShoot = true;
        currGunInd = 0;
        gunTypeIndicator.material = gunTypeMaterials[currGunInd];
    }

    void Update()
    {
        if (currGunInd == 1) {
            if (Input.GetMouseButton(0) && canShoot) {
                Shoot();
            }
        } else {
            if (Input.GetMouseButtonDown(0) && canShoot) {
                Shoot();
            }
        }
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootDelays[currGunInd]) canShoot = true;

        if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeGunType(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeGunType(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeGunType(2);
    }
    void Shoot() {
        canShoot = false;
        shootTimer = 0;
        weaponIndicator.Setup(shootDelays[currGunInd]);
        Bullet bull = Instantiate(bullet, shootPos.position, Quaternion.identity);
        bull.Setup(bullSpeed, shootPos.forward, currGunInd, gunTypeMaterials[currGunInd]);
    }

    void ChangeGunType(int type) {
        canShoot = false;
        if (type != currGunInd) {
            currGunInd = type;
            gun.DOLocalRotate(new Vector3(45, 0, 0), .3f).OnComplete(() => {
                gunTypeIndicator.material = gunTypeMaterials[currGunInd];
                gun.DOLocalRotate(new Vector3(-2.5f,-2f,0), .1f).OnComplete(() => {
                    canShoot = true;
                });
            });
        }
    }
}
