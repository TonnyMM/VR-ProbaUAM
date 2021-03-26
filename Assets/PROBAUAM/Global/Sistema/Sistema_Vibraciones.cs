using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public  class Sistema_Vibraciones : MonoBehaviour
{
    
    public static SteamVR_Action_Vibration hapticaction_L;
    public static SteamVR_Action_Vibration hapticaction_R;

    
    ///<summary> Este metodo genera un pulso de vibracion en un mando
    ///<param name = "mano"> Es la mano que tendra la vibracion </param>
    ///<param name = "duracion"> Es la duracion de la vibracion </param>
    ///<param name = "frecuencia"> Es la cantidad de veces que se repite en la duracion </param>
    ///<param name = "amplitud"> Es la fuerza que tendra la vibracion </param>
    ///<param name = "manita"> Es el input sources referencia del mando </param>
    ///<example> Sistema_Vibraciones.pulso ("Derecha",1,50,50,SteamVR_Input_Sources.LeftHand);
    /// Sistema_Vibraciones.pulso ("Izquierda",1,50,50,SteamVR_Input_Sources.RightHand); </example>
    ///</summary>
    public static void pulso(string mano,float duracion, float frecuencia, float amplitud,SteamVR_Input_Sources manita)
    {
        /*
            hapticaction_L = Player.instance.leftHand.GetComponent<Hand>().hapticAction;
            hapticaction_R = Player.instance.rightHand.GetComponent<Hand>().hapticAction;
            if(mano == "Derecha")
            {
                hapticaction_R.Execute(0,duracion,frecuencia,amplitud,manita);
            }else if(mano == "Izquierda")
            {
                hapticaction_L.Execute(0,duracion,frecuencia,amplitud,manita);
            }
         */
        
        
    }
}

