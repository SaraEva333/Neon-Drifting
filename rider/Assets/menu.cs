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
        // ��������, ��������� �� ��� �������� ����� � ������ ����
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            // ������������ ����� ����
            menu.SetActive(true);
            sound.SetActive(false);
            gameManager.isSpawningEnabled=false;
        }
        else
        {
            // ������ ����� ����
            menu.SetActive(false);
            sound.SetActive(false);
            gameManager.isSpawningEnabled = true;
        }
    }

    public void Play()
    {
        menu.SetActive(false);
        sound.SetActive(false);
        // ��������� ����� ����
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
