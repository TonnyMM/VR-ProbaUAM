using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class f1d1a4SeguimientoPlayer : MonoBehaviour
{
    private Transform player;
    public Animator Animacion;
    public NavMeshAgent nav;
    private bool cont;
    public f1d1a4SeguimientoPelota movimiento;
    public AudioSource audios;
    
    void Start()
    {
        movimiento.caminar = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav.GetComponent<NavMeshAgent>();
        nav.enabled = true;
        Animacion.SetBool("Entrecaminando", false);
        Animacion.SetBool("Sentar", false);
        Animacion.SetBool("Caminar", true);
        audios.enabled = true;
    }
    
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
        if (other.name == "PosicionFinal") {
                audios.enabled = false;
            if (Animacion.enabled == true) { 
                Animacion.enabled = false;
                nav.enabled = false;
                audios.enabled = true;
            }
        }
    }
}
