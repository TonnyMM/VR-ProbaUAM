using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class control_puntuacion : MonoBehaviour
{
    
    public Text txt_puntuacion;
    public ControlDePuntaje cp_scoreboard;

    private int puntos;

    public void Puntuar(int puntos_)
    {
        if (this.puntos+puntos_ > 0)
        {
            this.puntos += puntos_;
            cp_scoreboard.Puntuar((float)puntos_);
        }
        txt_puntuacion.text = this.puntos+"";
    }



}
