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
    
    // Start is called before the first frame update
    void Start()
    {
        puntero = GameObject.Find("Puntero");
        GameObject.Find("ControlEscena").GetComponent<f1d1a4_s_Puntero>().gato = gameObject;
        //GameObject.Find("ControlEscena").GetComponent<f1d1a4_s_Puntero>().animacion = gameObject.GetComponent<Animator>();
        limite = GameObject.Find("Limite");
        player = GameObject.Find("Global_s_Player");
        animacion = gameObject.GetComponent<Animator>();
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
            else
            {
                gameObject.GetComponent<NavMeshAgent>().enabled=true;
                gameObject.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
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
            siguePuntero = false;
            caminarSuelo = true;
            limite.SetActive(false);
            GameObject.Find("Iniciador").SetActive(true);
        }
    }
}
