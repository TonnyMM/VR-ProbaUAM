using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f1d1a4SeguimientoPelota : MonoBehaviour
{
    public new Rigidbody  rigidbody;
    private GameObject gato,limite,Reloj;
    public GameObject e ;
    public float speed = 10;
    public float up = 12;
    public bool condicion=false;
   //public Animator animacion;
    public f1d1a4SeguimientoPlayer seguimiento;
   
    public GameObject puntero;
    void Start()
    {

       
        rigidbody = GetComponent<Rigidbody>();
        Reloj = GameObject.Find("Canvas");
        gato = GameObject.Find("cat");
        limite = GameObject.Find("Limite");



    }

    // Update is called once per frame
    private void Update()
    {

        //rigidbody.transform.Translate(Vector3.forward*Time.deltaTime*speed);
        if (condicion==true)
        {
         transform.position = Vector3.Lerp(transform.position,puntero.transform.position,Time.deltaTime*speed);
        }


        float tiempo = Reloj.GetComponent<global_sc_Temporizador>().returnTiempo();
        if (tiempo == 0)
        {

        }




    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.name=="Limite") {
            gato.transform.Rotate(new Vector3(-90, 0, 0));
            seguimiento.enabled=true;
            limite.SetActive(false);
            Reloj.GetComponent<global_sc_Temporizador>().reiniciarContador();

            e.SetActive(true);



        }
      
      
        
        
        



    }
}
