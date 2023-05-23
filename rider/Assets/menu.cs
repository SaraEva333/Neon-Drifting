using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject sound;

    private void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        // Проверка, находится ли уже активная сцена в режиме меню
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            // Активировать канву меню
            menu.SetActive(true);
            sound.SetActive(false);
            gameManager.isSpawningEnabled=false;
        }
        else
        {
            // Скрыть канву меню
            menu.SetActive(false);
            sound.SetActive(false);
            gameManager.isSpawningEnabled = true;
        }
    }

    public void Play()
    {
        menu.SetActive(false);
        sound.SetActive(false);
        // Загрузить сцену игры
        SceneManager.LoadScene("SampleScene");
    }
    public void Sound()
    {
        menu.SetActive(false);
        sound.SetActive(true);

    }
    public void Exit()
    {
        Application.Quit();
    }
}
