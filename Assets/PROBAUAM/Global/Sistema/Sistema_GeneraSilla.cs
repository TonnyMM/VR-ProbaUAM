using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Sistema_GeneraSilla : MonoBehaviour
{
    ///<summary>
    ////Este metodo se encarga de generar una silla debajo del jugador y siempre esta en direccion frontal a la vista del jugador
    ///</summary>
    private static GameObject silla;

    public static void GeneraSilla()
    {
        var rotacion = Quaternion.Euler (0,Player.instance.hmdTransform.eulerAngles.y,0);
        if(silla==null)
        {
            Debug.Log("Genero Silla");
            silla = Instantiate (Resources.Load("SillaChida", typeof(GameObject) ),new Vector3(Player.instance.hmdTransform.position.x,0f,Player.instance.hmdTransform.position.z),rotacion) as GameObject;
        }
		
    }
}
