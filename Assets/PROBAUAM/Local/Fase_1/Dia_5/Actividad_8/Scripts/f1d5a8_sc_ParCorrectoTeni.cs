using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class f1d5a8_sc_ParCorrectoTeni : MonoBehaviour
{
    public Text parIconrrecto;
    private f1d5a8_sc_Puntos puntos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Par1"))
        {
            puntos.sumarPuntos();
        }
        else if (collision.gameObject.CompareTag("Par2") ||
            collision.gameObject.CompareTag("Par3") || collision.gameObject.CompareTag("Par4") ||
            collision.gameObject.CompareTag("Par5"))
        {
            parIconrrecto.text = "No es su par";
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Otro"))
        {
            parIconrrecto.text = "Incorrecto";
        }
        else
        {
            parIconrrecto.text = "";
        }
    }
}
