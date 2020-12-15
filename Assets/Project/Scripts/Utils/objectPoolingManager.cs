using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPoolingManager : MonoBehaviour
{
    private static objectPoolingManager instance;
    public static objectPoolingManager Instance { get { return instance; } }
    public GameObject bulletPrefab;
    public int bulletAmount = 20;
    private List<GameObject> bullets;
    // Start is called before the first frame update
    void Awake()
    {
        bullets = new List<GameObject>(bulletAmount);
        instance = this;
        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject prefabInstance = Instantiate(bulletPrefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);
            bullets.Add(prefabInstance);
        }

    }

    // Update is called once per frame
    public GameObject getBullet(bool shotByPlayer)
    {
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().ShotByPlayer = shotByPlayer;
                return bullet;
            }
        }
        GameObject prefabInstance = Instantiate(bulletPrefab);
        prefabInstance.transform.SetParent(transform);
        prefabInstance.GetComponent<Bullet>().ShotByPlayer = shotByPlayer;
        bullets.Add(prefabInstance);
        return prefabInstance;
    }
}
