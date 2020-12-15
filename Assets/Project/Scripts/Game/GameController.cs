﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [Header("Game")]
    public Player player;
    [Header("User Interface")]
    public Text ammoText;
    public Text healthText;


    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.Health;
        ammoText.text = "Ammo: " + player.Ammo;
    }
}
