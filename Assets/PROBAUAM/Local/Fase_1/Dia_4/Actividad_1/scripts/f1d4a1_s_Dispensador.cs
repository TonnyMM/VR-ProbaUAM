using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f1d4a1_s_Dispensador : MonoBehaviour
{
    public GameObject[] frutas;
    public GameObject punto_instancia;
    public bool puede_generar=false;//este boleano servira para decirle al dispensador CUANDO puede generar objetos
    public string origino;//izquierda o derecha segun la posicion del dispensador

    private GameObject Genera_fruta;

    void Update() 
    {
        if(puede_generar)
        {
            GenerarFruta();
        }
        
    }

    void GenerarFruta()
    {
        //generar frutas al azar
        if (Genera_fruta == null && puede_generar == true)
        {
            Genera_fruta = Instantiate(frutas[Random.Range(0,frutas.Length)].gameObject,punto_instancia.transform.position, punto_instancia.transform.rotation) as GameObject;
            Genera_fruta.GetComponent<f1d4a1_s_Fruta>().origino = this.origino;
        }

        if (Genera_fruta.GetComponent<f1d4a1_s_Fruta>().bowl_correcto == true)
        {
            Genera_fruta = null;
        }
    }
}
