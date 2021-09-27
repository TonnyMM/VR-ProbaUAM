using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f1d1a4_s_Puntero : MonoBehaviour
{
    public GameObject puntero;
    public GameObject gato; //se auto asigna cuando se crea
    public Transform cabeza;

    public GameObject iniciador;
    public Animator animacion;

    public float rayDistance;

    // Start is called before the first frame update
    void Start()
    {
        puntero = GameObject.Find("Puntero");
        cabeza = GameObject.Find("FollowHead").transform;
        iniciador = GameObject.Find("Iniciador");
        animacion = gato.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(cabeza.position, cabeza.forward * rayDistance, Color.red);
        if (Physics.Raycast(cabeza.position, cabeza.forward, out hit, rayDistance))
        {
            puntero.transform.position = hit.point;


            if(hit.transform.name == iniciador.name)
            {
                iniciador.SetActive(false);
                gato.GetComponent<BoxCollider>().enabled = true;
                gato.GetComponent<Rigidbody>().transform.Rotate(new Vector3(90, 0, 0));
                GameObject.Find("Limite").SetActive(true);
                Debug.Log("Gato listo para caminar");
            }
            if(hit.transform.name == "Tree_03")
            {
                if(!iniciador.activeInHierarchy)
                {
                    animacion.SetBool("Entrecaminando", false);
                    animacion.SetBool("Sentar", false);
                    animacion.SetBool("Caminar", true);
                    gato.GetComponent<f1d1a4_s_ControlGato>().caminar = true;
                }
            }
            else
            {
                animacion.SetBool("Entrecaminando", false);
                animacion.SetBool("Sentar", false);
                animacion.SetBool("Caminar", false);
                gato.GetComponent<f1d1a4_s_ControlGato>().caminar = false;
            }
        }
        else
        {
            animacion.SetBool("Entrecaminando", false);
            animacion.SetBool("Sentar", false);
            animacion.SetBool("Caminar", false);
            gato.GetComponent<f1d1a4_s_ControlGato>().caminar = false;
        }
    }
}
