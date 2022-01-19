using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f1d5a1_Funciones : MonoBehaviour
{
    private GameObject clon,Mesa,gato, Score;
      private GameObject Manzana;
    private bool inicio;
 


    int Manzanas;

    // este script va en la canasta o mesa donde se dejaran los objetos
    void Start()
    {
        gato = GameObject.Find("cat_Walk");
         Manzana = GameObject.Find("Apple");
        Score = GameObject.Find("PuntoInicial");
        inicio = true;
        Mesa = GameObject.Find("Mesa");
        
       
        
    }


    void Update()
    {

        if (inicio == true) {
            generarFrutas();
            inicio = false;
        }
    }

    public void generarFrutas() { //metodo generador de frutas random de entre 1 y 3 manzanas
        Manzana.SetActive(true);
        
            
             int cantidad= Random.Range(1, 4);
       
        for (int i = 0; i < cantidad; i++) {// funcion para moverlas a una pocicion aleatoria de x de entre un rango de -0.9 y 0.2
               
            
        float distancia = Random.Range(-0.9f,0.3f);
        Vector3 Rango = new Vector3(Manzana.transform.position.x+distancia, Manzana.transform.position.y, Manzana.transform.position.z);
            clon=  Instantiate(Manzana);
               
                clon.transform.position =Rango;
                clon.GetComponent<SphereCollider>().isTrigger = false;
                clon.SetActive(true);
          
                
                clon.GetComponent<Rigidbody>().useGravity = true;
             
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.transform.tag == "Fruta") {
            Score.GetComponent<global_sc_Contador>().suma();
            //   Mesa.GetComponent<BoxCollider>().isTrigger = false;
            Destroy(other.transform.gameObject);
            Debug.Log("Objeto destruido: "+other.tag);
            Manzanas--;
            //  clon.GetComponent<Rigidbody>().useGravity = false ;
            if (gato.GetComponent<f1d5a1_SeguirManzanas>().Generar) { 
            generarFrutas();
            }
            
            
        }
       
    }
}
