using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f1d4a1_s_control_alternaciones : MonoBehaviour
{
    /*Este script controla de que manera se instanciaran los objetos, es decir
    si es alternado
    si es solo el dispensador Derecho
    si es solo el dispensador Izquierdo */

    [HideInInspector]
    public GameObject dispensador_L;//quien es el arbol/dispensador izquierdo
    [HideInInspector]
    public GameObject dispensador_R;//quien es el arbol/dispensador derecho
    [HideInInspector]
    public bool existe_arbol_R;
    [HideInInspector]
    public bool existe_arbol_L;

    public bool entrenamiento_alternado = true;
    public bool entrenamiento_soloderecha;
    public bool entrenamiento_soloizquierda;

    private bool derecha=true;
    private bool izquierda=false;

    private void Update() {
        if(entrenamiento_alternado)
        {
            Alternado();
        }else if(entrenamiento_soloderecha)
        {
            izquierda = false;
            derecha = true;
            SoloDerecha();
        }else if(entrenamiento_soloizquierda)
        {
            izquierda = true;
            derecha = false;
            SoloIzquierda();
        }
    }

    public void Alternado()
    {
        if(existe_arbol_L==true && existe_arbol_R==true)
        {
            if(derecha)
            {
                //instanciamos en la parte derecha
                dispensador_R.GetComponent<f1d4a1_s_Dispensador>().puede_generar = true;
                dispensador_L.GetComponent<f1d4a1_s_Dispensador>().puede_generar = false;

            }else if(izquierda)
            {
                //instanciamos en la parte izquierda
                dispensador_L.GetComponent<f1d4a1_s_Dispensador>().puede_generar = true;
                dispensador_R.GetComponent<f1d4a1_s_Dispensador>().puede_generar = false;
            }  
        }
    }

    public void SoloIzquierda()
    {
        if(existe_arbol_L == true && existe_arbol_R == true)
        {
            if(izquierda)
            {
                //instanciamos en la parte izquierda
                dispensador_L.GetComponent<f1d4a1_s_Dispensador>().puede_generar = true;
                dispensador_R.GetComponent<f1d4a1_s_Dispensador>().puede_generar = false;

            } 
        }
    }

    public void SoloDerecha()
    {
        if(existe_arbol_R==true && existe_arbol_L==true)
        {
            if(derecha)
            {
                //instanciamos en la parte derecha
                dispensador_R.GetComponent<f1d4a1_s_Dispensador>().puede_generar = true;
                dispensador_L.GetComponent<f1d4a1_s_Dispensador>().puede_generar = false;

            } 
        }
    }

    public void origino(string quien)
    {
        switch(quien)
        {
            case "Derecha":
            derecha=false;
            izquierda=true;
            break;

            case "Izquierda":
            derecha=true;
            izquierda=false;
            break;
        }
    }

    public void set_arbol_L(GameObject arbol_l)
    {
        this.dispensador_L = arbol_l;
    }

    public void set_arbol_R(GameObject arbol_r)
    {
        this.dispensador_R = arbol_r;
    }
}