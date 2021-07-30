using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class global_sc_Temporizador : MonoBehaviour
{
    public TextMeshProUGUI TextScore;
    private float Tiempo ;
    void Start()
    {
        Tiempo = 10;
        TextScore.text = "Tiempo: " + Tiempo;
    }

    // Update is called once per frame
    void Update()
    {
        Tiempo -= Time.deltaTime;
         TextScore.text = "Tiempo: "+Tiempo.ToString("f0");
    }

    public void reiniciarContador() {
        Tiempo = 10;
    }
    public float returnTiempo() {
        return Tiempo;
    }
}
