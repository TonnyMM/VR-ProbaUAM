using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class F1D6A2JuntarObjetos : MonoBehaviour
{
    // Start is called before the first frame update
    public int total;

    global_sc_Contador a;
    global_sc_Temporizador Temporizador;
    GameObject[] Objetos;
    GameObject ctrlIzq, ctrlDer;
      public Interactable interactable;
    public SteamVR_Action_Vibration vibracion;


    public void Start()
    {
        ctrlIzq = GameObject.Find("LeftHand");
        ctrlDer = GameObject.Find("RightHand");
        total = 4;
      //  Temporizador = GameObject.Find("Temp").GetComponent<global_sc_Temporizador>();
     //   a = GameObject.FindGameObjectWithTag("Contador").GetComponent<global_sc_Contador>();
      
    }

    void OnTriggerEnter(Collider other)
    {


        


        if (other.tag == "Objetos")
        {

            a.suma();

           // Temporizador.reiniciarContador();
            Destroy(other.gameObject);

        }
    }
    private void Update()
    {

        //Conexion de vibrar controles
        if (interactable.attachedToHand)
        {
            if (interactable.attachedToHand.handType.ToString() == ctrlIzq.name)
            {
              
                vibracion = Player.instance.leftHand.GetComponent<Hand>().hapticAction;
                vibracion.Execute(0, 2.5f,50, 50, SteamVR_Input_Sources.LeftHand);
            }
            else {
              
                vibracion = Player.instance.rightHand.GetComponent<Hand>().hapticAction;
                vibracion.Execute(0, 2.5f, 50, 50, SteamVR_Input_Sources.RightHand);
            }
        }
        //Fin de conexion
        Objetos = GameObject.FindGameObjectsWithTag("Carrito");
        Debug.Log(Objetos.Length);
        if (Objetos.Length == 0)
        {
         //   a.enabled = false;
        //    Temporizador.TextScore.text = "le sabe";
          //  Temporizador.enabled = false;
        }

       // if (Temporizador.returnTiempo() <= 0)
        //{
            //a.resta();
          //  Temporizador.reiniciarContador();

        //}
    }




}


