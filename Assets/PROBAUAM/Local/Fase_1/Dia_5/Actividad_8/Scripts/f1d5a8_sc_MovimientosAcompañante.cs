 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class f1d5a8_sc_MovimientosAcompañante : MonoBehaviour
{
    public GameObject player,acompañante;
    public Animator animacion;
    private NavMeshAgent nav;
    private float ultimaPosicion;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        animacion = GetComponent<Animator>();
        ultimaPosicion = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        var tmp = player.transform.position;
        tmp.x += 0.9f;
        acompañante.transform.position = tmp;

        if (nav.remainingDistance != 0)
        {
            animacion.SetBool("Caminar",true);
        }
        else
        {
            animacion.SetBool("Caminar",false);
        }
        nav.SetDestination(acompañante.transform.position);
        nav.angularSpeed = 0;
    }
}
