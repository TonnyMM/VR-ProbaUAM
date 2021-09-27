using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class f1d1a4SeguimientoPelota : MonoBehaviour
{
    private GameObject gato,limite,Reloj;
    //public GameObject contador;
    public float speed = 10;
    public float up = 12;
    public bool caminar=false;
    public Transform posicionInicial;
    public GameObject puntero, iniciador;

    public GameObject[] catToCopy;

    void Start()
    {
        Reloj = GameObject.Find("Canvas");
        gato = GameObject.Find("cat");
        limite = GameObject.Find("Limite");
        //contador = GameObject.Find("Contador");
        //puntero = GameObject.Find("Puntero");
        //iniciador = GameObject.Find("Iniciador");
        posicionInicial = GameObject.Find("PosicionInicial").transform;
    }

    void Awake(){
        
        puntero = GameObject.Find("Puntero");
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (caminar==true)
        {
            transform.position = Vector3.Lerp(transform.position,puntero.transform.position,Time.deltaTime*speed);
        }

        float tiempo = Reloj.GetComponent<global_sc_Temporizador>().returnTiempo();
        if (tiempo == 0)
        {
            //Que pasa cuando se termina el tiempo????
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.name=="Limite") {
            gato.transform.Rotate(new Vector3(-90, 0, 0));
            gameObject.GetComponent<f1d1a4SeguimientoPlayer>().enabled = true;
            limite.SetActive(false);
            Reloj.GetComponent<global_sc_Temporizador>().reiniciarContador();

            //contador.SetActive(true);

            //caminar = false;
            //iniciador = GameObject.Find("Iniciador");
            //iniciador.SetActive(true);

            int rand = Random.Range(0,2);
            Debug.Log("gato " + rand);

            Rigidbody clon = (Rigidbody)Instantiate(catToCopy[rand].GetComponent<Rigidbody>(), posicionInicial.position, gato.transform.rotation); 
                    
            //clon.GetComponent<Animator>().SetBool("Sentar", false);
            //clon.GetComponent<Animator>().SetBool("Caminar", false);
            //clon.GetComponent<Animator>().SetBool("Entrecaminando", false);

            gato.GetComponent<BoxCollider>().isTrigger = false;

            //gato.GetComponent<f1d1a4SeguimientoPlayer>().enabled = false;
            //gato.GetComponent<NavMeshAgent>().enabled = false;
            //gato.transform.position = posicionInicial.position;
            gato.GetComponent<NavMeshAgent>().enabled = true;
            gato.GetComponent<Animator>().SetBool("Entrecaminando", true);
            gato.GetComponent<Animator>().SetBool("Sentar", false); ;
            gato.GetComponent<Animator>().SetBool("Caminar", true);
            limite.GetComponent<f1d1a4_s_Contador>().suma();
        }
    }
}
