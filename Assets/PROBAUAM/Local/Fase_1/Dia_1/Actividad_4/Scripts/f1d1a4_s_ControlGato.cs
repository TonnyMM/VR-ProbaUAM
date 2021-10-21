using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class f1d1a4_s_ControlGato : MonoBehaviour
{
    public bool caminarArbol = false;
    public bool caminarSuelo = false;
    public bool siguePuntero = true;
    public GameObject puntero;
    public float speed = 0.5f;
    public GameObject limite;
    public GameObject player;
    public Animator animacion;
    public Vector3 posicionMeta;
    public GameObject controlEscena;
    public int gatoID=0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        //puntero = GameObject.Find("Puntero");
        //controlEscena = GameObject.Find("controlEscena");
        //controlEscena.GetComponent<f1d1a4_s_Puntero>().gato = gameObject;/// quitar esta linea cuando ya se creen automáticamente
        //GameObject.Find("ControlEscena").GetComponent<f1d1a4_s_Puntero>().animacion = gameObject.GetComponent<Animator>();
        //limite = GameObject.Find("Limite");
        //player = GameObject.Find("Global_s_Player");
        //animacion = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(caminarArbol || caminarSuelo)
        {
            animacion.SetBool("Entrecaminando", false);
            animacion.SetBool("Sentar", false);
            animacion.SetBool("Caminar", true);
            if(siguePuntero)
            {
                transform.position = Vector3.Lerp(transform.position,puntero.transform.position,Time.deltaTime*speed);
            }
        }
        else{
                animacion.SetBool("Entrecaminando", false);
                animacion.SetBool("Sentar", false);
                animacion.SetBool("Caminar", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == limite.name)
        {
            posicionMeta = controlEscena.GetComponent<f1d1a4_s_Puntero>().metas[gatoID].transform.position;
            gameObject.GetComponent<NavMeshAgent>().enabled=true;
            gameObject.GetComponent<NavMeshAgent>().SetDestination(posicionMeta);
            
            siguePuntero = false;
            caminarArbol = false;
            caminarSuelo = true;
            controlEscena.GetComponent<f1d1a4_s_Puntero>().nuevo_Gato();
            limite.GetComponent<BoxCollider>().enabled = false;
            controlEscena.GetComponent<f1d1a4_s_Puntero>().iniciador.GetComponent<BoxCollider>().enabled = true;
            
            
        }
        //if(other.transform.name == GameObject.Find("Meta").name){
            //Debug.Log(gameObject.GetComponent<NavMeshAgent>().isStopped + " " + gameObject.GetComponent<NavMeshAgent>().remainingDistance + " " + gatoID);
        
    }

    private void OnTriggerStay(Collider other){
        //Debug.Log(gameObject.GetComponent<NavMeshAgent>().isStopped + " " + gameObject.GetComponent<NavMeshAgent>().remainingDistance + " " + gatoID);
        if(other.transform.name == GameObject.Find("Meta").name){
            if(gameObject.GetComponent<NavMeshAgent>().stoppingDistance > gameObject.GetComponent<NavMeshAgent>().remainingDistance){
                Debug.Log("stopped gato" + gatoID + " toco " + other.name);

                //int i = gameObject.GetComponent<NavMeshAgent>().remainingDistance;
                caminarSuelo = false;
            }
        }
    }
}
