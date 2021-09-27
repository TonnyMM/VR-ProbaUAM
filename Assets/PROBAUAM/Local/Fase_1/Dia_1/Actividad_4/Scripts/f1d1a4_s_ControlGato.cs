using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f1d1a4_s_ControlGato : MonoBehaviour
{
    public bool caminar;
    public bool siguePuntero = true;
    public GameObject puntero;
    public float speed = 0.5f;
    public GameObject limite;
    
    // Start is called before the first frame update
    void Start()
    {
        puntero = GameObject.Find("Puntero");
        GameObject.Find("ControlEscena").GetComponent<f1d1a4_s_Puntero>().gato = gameObject;
        GameObject.Find("ControlEscena").GetComponent<f1d1a4_s_Puntero>().animacion = gameObject.GetComponent<Animator>();
        GameObject.Find("Limite");
    }

    // Update is called once per frame
    void Update()
    {
        if(caminar)
        {
            if(siguePuntero)
            {
                transform.position = Vector3.Lerp(transform.position,puntero.transform.position,Time.deltaTime*speed);
            }
            else
            {
                
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name = limite.name)
        {
            siguePuntero = false;
        }
    }
}
