using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class f1d1a1_sc_Timer : MonoBehaviour
{
    private float time = 6f;
    public GameObject contador;
    private int tiempoToText;

    private void Start()
    {
        
    }

    private void Update()
    {
        time -= Time.deltaTime;
        tiempoToText = (int)time;
        contador.GetComponent<Text>().text= "Comenzar en "+tiempoToText.ToString();
        if (time <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
