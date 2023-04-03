/*
 * Gerard Lamoureux
 * GameController
 * Assignment9
 * Handles the overall game
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController playerController;

    public GameObject tutText;

    public TextMeshProUGUI healthText;

    public TextMeshProUGUI shieldText;

    private bool inIntro = true;

    private void Start()
    {
        Time.timeScale = 0;

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && inIntro)
        {
            inIntro = false;
            Time.timeScale = 1;
            Destroy(tutText);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            playerController.TakeDamage(10);
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
        healthText.text = "Health: " + playerController.health;
        shieldText.text = "Shield: " + playerController.shield;
    }
}
