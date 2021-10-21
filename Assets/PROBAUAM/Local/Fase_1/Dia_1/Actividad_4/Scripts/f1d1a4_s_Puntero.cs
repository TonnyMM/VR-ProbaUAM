using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f1d1a4_s_Puntero : MonoBehaviour
{
    public GameObject puntero;
    public GameObject gato; //se auto asigna cuando se crea
    public Transform cabeza;
    public int contadorGatos = 0;
    public GameObject iniciador;
    public GameObject[] metas;
    public GameObject spawn;
    public GameObject[] catToCopy;

    public float rayDistance;

    // Start is called before the first frame update
    void Start()
    {
        puntero = GameObject.Find("Puntero");
        cabeza = GameObject.Find("FollowHead").transform;
        iniciador = GameObject.Find("Iniciador");
        spawn = GameObject.Find("Spawn");
        nuevo_Gato();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //Debug.DrawRay(cabeza.position, cabeza.forward * rayDistance, Color.red);
        if (Physics.Raycast(cabeza.position, cabeza.forward, out hit, rayDistance))
        {
            puntero.transform.position = hit.point;
            //Debug.Log(hit.transform.name);

            if(hit.transform.name == iniciador.name)
            {
                iniciador.GetComponent<BoxCollider>().enabled = false;
                gato.GetComponent<BoxCollider>().enabled = true;
                gato.GetComponent<Rigidbody>().transform.Rotate(new Vector3(90, 0, 0));
                GameObject.Find("Limite").GetComponent<BoxCollider>().enabled = true;
            }
            if(hit.transform.name == "Tree_03")
            {
                if(!iniciador.GetComponent<BoxCollider>().enabled)
                {
                    gato.GetComponent<f1d1a4_s_ControlGato>().caminarArbol = true;
                }
            }
            else
            {
                gato.GetComponent<f1d1a4_s_ControlGato>().caminarArbol = false;
            }
        }
        else
        {
            gato.GetComponent<f1d1a4_s_ControlGato>().caminarArbol = false;
        }
    }

    public void nuevo_Gato(){
        
        int rand = Random.Range(0,3);
        Debug.Log("nuevo gato " + rand);
        gato = Instantiate(catToCopy[rand], spawn.transform.position, spawn.transform.rotation);
        f1d1a4_s_ControlGato control = gato.GetComponent<f1d1a4_s_ControlGato>();
        control.puntero = puntero;
        control.limite = GameObject.Find("Limite");
        control.player = GameObject.Find("Global_s_Player");
        control.animacion = gato.GetComponent<Animator>();
        control.controlEscena = GameObject.Find("ControlEscena");
        control.gatoID=contadorGatos;
        contadorGatos++;
    }
}
