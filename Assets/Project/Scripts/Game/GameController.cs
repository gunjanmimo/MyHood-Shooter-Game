using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Game")]
    public Player player;
    public GameObject enemyContainer;
    [Header("User Interface")]
    public Text ammoText;
    public Text healthText;
    public Text enemyText;
    public Text infoText;
    private bool gameOver = false;
    private float resetTimer = 3f;
    // Update is called once per frame
    void Start()
    {
        infoText.gameObject.SetActive(false);
    }
    void Update()
    {
        healthText.text = "Health: " + player.Health;
        ammoText.text = "Ammo: " + player.Ammo;
        int aliveEnemies = 0;
        foreach (Enemy enemy in enemyContainer.GetComponentsInChildren<Enemy>())
        {
            if (!enemy.kill)
            {
                aliveEnemies++;
            }
        }
        enemyText.text = "Enemies: " + aliveEnemies;
        if (aliveEnemies == 0)
        {
            gameOver = true;
            infoText.gameObject.SetActive(true);
            infoText.text = "You won \n Good job";
        }
        if (player.kill == true)
        {
            gameOver = true;
            infoText.gameObject.SetActive(true);
            infoText.text = "You lose :( \nTry Again!";
        }
        if (gameOver == true)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
