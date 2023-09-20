using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public GameObject prefabBullet; // Bullet ������

    public int gold = 0;

    public int ammo = 10; // ���� ź��
    public int maxAmmo = 10; // �ִ� ź��

    public float reloadTime = 3f; // ������ �ð�

    public bool isReload = false; // ���� ������ ���ΰ�?

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
        yield return new WaitForSeconds(reloadTime); // ������
        ammo = maxAmmo;
        isReload = false;
    }
}
