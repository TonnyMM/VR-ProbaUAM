using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistema_UIPuntos : MonoBehaviour
{

    private static GameObject UI_Puntos;

    ///<summary>
    ////Este metodo se encarga de generar un indicador visual para mostrar el puntaje obtenido al realizar una accion en una posicion indicada
    ///</summary>
    public static void GenerarUI(Vector3 posicion,string ValorMostrar)
    {
        UI_Puntos = Instantiate(Resources.Load("UI_Puntos", typeof(GameObject)),posicion,Quaternion.identity) as GameObject;
        UI_Puntos.GetComponent<UIPuntos_control>().mensaje = ValorMostrar;
        Destroy(UI_Puntos, 2);
    }
}
