using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public GameObject prefabBullet; // Bullet 프리팹

    public int gold = 0;
    public int heart = 3;

    public int ammo = 10; // 현재 탄약
    public int maxAmmo = 10; // 최대 탄약

    public float reloadTime = 3f; // 재장전 시간

    public bool isReload = false; // 현재 재장전 중인가?

    public TMP_Text tmpAmmo;

    public GameObject objReload;

    public GameObject[] objHearts;

    public GameObject objResult;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        tmpAmmo.text = "Ammo: " + ammo;

        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            ammo--;
            GameObject bullet = Instantiate(prefabBullet);
            bullet.transform.position = new Vector2(transform.position.x + 0.4f, transform.position.y);
        }

        if (ammo == 0 && isReload == false)
        {
            StartCoroutine(ReloadAmmo());
        }

        objReload.SetActive(isReload);

        for (int i=0;i<3;i++)
        {
            objHearts[i].gameObject.SetActive(heart > i);
        }


        objResult.SetActive(heart <= 0);

        if (heart <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    

    IEnumerator ReloadAmmo()
    {
        isReload = true;
        yield return new WaitForSeconds(reloadTime); // 딜레이
        ammo = maxAmmo;
        isReload = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            heart--;
            Destroy(collision.gameObject);
        }
    }
}
