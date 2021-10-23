using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class f1d5a8_sc_Puntos : MonoBehaviour
{
    private int contadorParesCorrectos = 0;
    public Text pares,ganaste;

    // Start is called before the first frame update
    void Start()
    {
        ganaste.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sumarPuntos()
    {
        contadorParesCorrectos += 1;
        pares.text = "Pares Encontrados: " + contadorParesCorrectos + " / 5";
        if (contadorParesCorrectos == 5)
        {
            ganaste.gameObject.SetActive(true);
        }
    }
}
