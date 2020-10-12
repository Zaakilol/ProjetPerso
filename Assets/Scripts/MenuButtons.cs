using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject tutoScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void closeScreen()
    {
        tutoScreen.SetActive(false);
        PlayerPrefs.SetInt("hasPlayedTuto", 1);
    }
}
