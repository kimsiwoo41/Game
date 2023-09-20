using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public GameObject prefabBullet; // Bullet 프리팹

    public int gold = 0;

    public int ammo = 10; // 현재 탄약
    public int maxAmmo = 10; // 최대 탄약

    public float reloadTime = 3f; // 재장전 시간

    public bool isReload = false; // 현재 재장전 중인가?

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            ammo--;
            GameObject bullet = Instantiate(prefabBullet);
            //bullet.transform.position = new Vector2(1, 0);
        }

        if (ammo == 0 && isReload == false)
        {
            StartCoroutine(ReloadAmmo());
        }
    }
    

    IEnumerator ReloadAmmo()
    {
        isReload = true;
        yield return new WaitForSeconds(reloadTime); // 딜레이
        ammo = maxAmmo;
        isReload = false;
    }
}
