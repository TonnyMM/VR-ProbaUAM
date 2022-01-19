using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;



public class F1D6A1JuntarCarritos : MonoBehaviour
{
   
 
   // public Rigidbody rb;
    public int total;

    global_sc_Contador a;
    global_sc_Temporizador Temporizador;
    GameObject[] Carros;


    public void Start()
    {
        
        total = 4;
        Temporizador = GameObject.Find("Temp").GetComponent<global_sc_Temporizador>() ;
        a = GameObject.FindGameObjectWithTag("Contador").GetComponent<global_sc_Contador>();
    }

    void OnTriggerEnter(Collider other) {
    
     
        if (other.tag == "Carrito")
        {
           
           a.suma();

            Temporizador.reiniciarContador();
            Destroy(other.gameObject);
            
        }
    }
    private void Update()
    {
        Carros = GameObject.FindGameObjectsWithTag("Carrito");
        Debug.Log(Carros.Length);
       if (Carros.Length==0) {
            a.enabled = false;
            Temporizador.TextScore.text = "le sabe";
            Temporizador.enabled = false;
        }
       
        if (Temporizador.returnTiempo()<=0) {
            a.resta();
            Temporizador.reiniciarContador();
            
        }
    }




}
