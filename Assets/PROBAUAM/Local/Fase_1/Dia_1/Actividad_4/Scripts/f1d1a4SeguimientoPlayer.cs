using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class f1d1a4SeguimientoPlayer : MonoBehaviour
{
    public Transform player;
    public Animator Animacion;
    public NavMeshAgent nav;
    private GameObject seguimiento;
    private GameObject desaparecer;
    private BoxCollider des;
    private bool cont;
    //ScriptVRCamera c;
   public f1d1a4SeguimientoPelota movimiento;
    public AudioSource audios;
    void Start()
    {
        movimiento.condicion = false;
        seguimiento =GameObject.Find("Iniciar");
        //   player = GameObject.Find("Player");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav.GetComponent<NavMeshAgent>();
        desaparecer = GameObject.Find("Bench");
        nav.enabled = true;
        des = desaparecer.GetComponent<BoxCollider>();
        Animacion.SetBool("Entrecaminando", false);
        Animacion.SetBool("Sentar", false);
        Animacion.SetBool("Caminar", true);
        // Animacion.SetBool("Caminar",true);
        audios.enabled = true;
        cont=true;
       // audios.enabled = false;
    }
    

    // Update is called once per frame
    void Update()
    {

        if (nav.enabled == true)
        {

            nav.SetDestination(player.position);
        }

        else if (nav.enabled == false) { 
              Animacion.SetBool("Sentar", true);
            Animacion.SetBool("Caminar", false);
            Animacion.SetBool("Entrecaminando", false);
            Animacion.enabled = true;
           
        }
        
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.name== "Bench") {
            audios.enabled = false;
            if (Animacion.enabled == true) { 
            Animacion.enabled = false;
                nav.enabled = false;
                audios.enabled = true;
            }




        }
        
        
    }

}
