using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSound : MonoBehaviour
{
    public GameObject menu;
    public GameObject sound;

    public void Save()
    {
        menu.SetActive(true);
        sound.SetActive(false);
    }

    
  
}
