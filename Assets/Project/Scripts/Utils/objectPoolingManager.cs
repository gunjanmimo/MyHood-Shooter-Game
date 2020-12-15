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
    public GameObject getBullet()
    {
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        GameObject prefabInstance = Instantiate(bulletPrefab);
        prefabInstance.transform.SetParent(transform);
        bullets.Add(prefabInstance);
        return prefabInstance;
    }
}
