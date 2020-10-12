using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsStockage : MonoBehaviour
{
    public GameObject tutoScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("hasPlayedTuto", 0) == 0)
        {
            tutoScreen.SetActive(true);
        }
    }
}
