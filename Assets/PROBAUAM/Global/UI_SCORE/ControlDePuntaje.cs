using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDePuntaje : MonoBehaviour {

    public Text puntuacionText;
    public Transform barraCarga;
    public GameObject estrellaOro;
    public GameObject estrellaPlata;
    public GameObject estrellaBronce;

    bool ganasteBronce = false;
    bool ganastePlata = false;
    bool ganasteOro = false;


    public float puntajeOro;
    public float puntajePlata;
    public float puntajeBronce;
    /*DEBUGEO
    public float puntajeAumento;
    public float puntajeDeResta;
    */
    //esta puntuacion total se almacena para cada actividad
    float puntuacionTotal = 0;
    
	void Start () {
        puntuacionText.text = puntuacionTotal.ToString();
        barraCarga.GetComponent<Image>().fillAmount = puntuacionTotal / puntajeOro;
    }
	

	void Update () {
        /*PARA DEBUGEO MANUAL
        if (Input.GetKeyDown("up"))
        {
            aumentarPuntaje(puntajeAumento, puntajeOro);
        }

        if (Input.GetKeyDown("down"))
        {
            restarPuntaje(puntajeDeResta);
        }*/
        puntuacionText.text = puntuacionTotal.ToString();

        //Para efectos de demostracion, esta parte hara que cuando gane oro se vaya al lobby del eneit2019
        if (ganasteOro)
        {
            Sistema_CambioEscenas.CambioEscena("LobbyDEMO");
        }
    }

    public void Puntuar(float puntosDeAumento)
    {
        if (puntosDeAumento + puntuacionTotal > 0)
        {
            puntuacionTotal += puntosDeAumento;
            barraCarga.GetComponent<Image>().fillAmount = puntuacionTotal / puntajeOro;
            if (puntuacionTotal >= puntajeBronce && puntuacionTotal < puntajePlata && ganasteBronce == false)
            {
                estrellaBronce.GetComponent<Animation>().Play();
                ganasteBronce = true;
            }
            if (puntuacionTotal >= puntajePlata && puntuacionTotal < puntajeOro && ganastePlata == false)
            {
                estrellaPlata.GetComponent<Animation>().Play();
                ganastePlata = true;
            }
            if (puntuacionTotal >= puntajeOro && ganasteOro == false)
            {
                estrellaOro.GetComponent<Animation>().Play();
                ganasteOro = true;
            }
        }
        
    }

}
