using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class f1d5a1_SeguirManzanas : MonoBehaviour
{
    private Vector3 PosicionI;
    private GameObject Gato,Score;
    private GameObject[] Manzanas;
    public GameObject Clonandor;
    public float speed;
    bool Fruta;
    public bool Generar;
    private int contador;
    private Interactable interactable;
    private Animator Animacion;


    void Start()
    {
        Score = GameObject.Find("PuntoInicial");
        Gato = GameObject.Find("cat_Walk");
        PosicionI = Gato.transform.position;
        Animacion = Gato.GetComponent<Animator>();
        Fruta = false;
         contador = 0;
    }
    private void Update()
    {  
        Manzanas = GameObject.FindGameObjectsWithTag("Fruta");
      
        if (Fruta == false)
        { 
            if (Manzanas.Length != 1) // evita que el contador genero un error de tamaños
            {
                if (Manzanas[contador].name == "Apple")// salto a la manzana Original
                {
                    Debug.Log(Manzanas[contador].name);
                    if (Manzanas.Length >= 2)
                    {
                        contador++;
                        
                    }
                    
                }
                interactable = Manzanas[contador].GetComponent<Interactable>();
            } 
            else {
                contador = 0;
                Fruta = true;// hace devolver al gato a su posicion original
            }
           
            Debug.Log(Manzanas[contador].name);
            
            Gato.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (!interactable.attachedToHand)// evita que vaya por la manzana de su mano
            {
                Animacion.SetBool("Caminar", true);
         
            Animacion.SetBool("Pararse", false);
                Manzanas[contador].GetComponent<SphereCollider>().enabled = true;
                if (contador == 2)
                {
                    transform.position = Vector3.Lerp(transform.position, Manzanas[contador].transform.position, Time.deltaTime * speed);

                }
                else {
                    transform.position = Vector3.Lerp(transform.position, Manzanas[contador].transform.position, Time.deltaTime * (speed+.2f));
                }
                
            }
            else {
                Animacion.SetBool("Caminar", false);
                
                Animacion.SetBool("Pararse", true);
                Manzanas[contador].GetComponent<SphereCollider>().enabled = false;// desactivo su collider por un error de mano para evitar que le quite las manzanas de la mano

            }
        }
        else {
            //en todo el else es para reiniciar al gato en su posicion original y volver a generar frutas 
            transform.rotation =Quaternion.Euler(0,180,0);
            transform.position = Vector3.Lerp(transform.position, PosicionI, Time.deltaTime * 0.8f);
          
            if (Generar==true) {
               Clonandor.GetComponent<f1d5a1_Funciones>().generarFrutas();
                Generar = false;
                Fruta = false;;
            }
           
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.transform.tag == "Fruta") {
            Score.GetComponent<global_sc_Contador>().resta();
            Destroy(Manzanas[contador]);
            Debug.Log("Contador: " + contador + " Manzanas: " + Manzanas.Length);// segunda verficacion de que el contador no este por encima del valor maximo de manzanas clonadas
            if (Manzanas.Length == 2)
            { 
                contador = 0;
                Fruta = true;
               
            }
            else {
               
            }
        }
        if (other.name== "PuntoInicial") {// verifica que el gato este en el punto inicial para activar la funcion de generar
             
            if (Fruta==true) {
          
            Debug.Log("Entro");
            Generar = true;
           
            }
            
        }
    }



}
