
using UnityEngine;
using UnityEngine.AI;


public class f1d1a4ApuntadoCamara : MonoBehaviour
{
    public new Transform camera;
    public float rayDistance;
    private GameObject a, e;
    private GameObject Iniciador;
    global_sc_Contador s;
    private Animator animacion;
    private f1d1a4SeguimientoPlayer seguimiento;
    private NavMeshAgent nav;
    private AudioSource audios;
    private f1d1a4SeguimientoPelota Movimiento;
    public Transform teleport;
    public int total;
    public GameObject Puntero;
  
    private Rigidbody gato;
    private GameObject limite,Reloj;

    void Start()
    {  a = GameObject.Find("cat");
        Iniciador = GameObject.Find("Iniciador");
        s = GameObject.Find("Contador").GetComponent<global_sc_Contador>();
        // camera = transform.Find("VRCamera");
        gato = a.GetComponent<Rigidbody>();
        Reloj = GameObject.Find("Canvas");
        e = GameObject.Find("Contador");
        Movimiento = a.GetComponent<f1d1a4SeguimientoPelota>();
        animacion = a.GetComponent<Animator>();
        seguimiento = a.GetComponent<f1d1a4SeguimientoPlayer>();
        nav = a.GetComponent<NavMeshAgent>();
        nav.enabled = false;
        Movimiento.enabled = false;
        audios = a.GetComponent<AudioSource>();
        audios.enabled = false;
        animacion.SetBool("Sentar", true);
        animacion.SetBool("Entrecaminando", false);
        animacion.SetBool("Caminar", false);
        limite = GameObject.Find("Limite");
        seguimiento.enabled = false;
        e.SetActive(false);

     

    }


    void Update()
    { 
        RaycastHit hit;
        if (s.getContador() != total)
        {
           
           


            Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.red);
            //Lerp


            if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance))
            {
                Puntero.SetActive(true);

                Debug.Log(hit.transform.name);

                Puntero.transform.position = hit.point;



                if (hit.transform.name == Iniciador.name)
                {

                    //si apunta al   gato
                    Iniciador.SetActive(false);
                    a.GetComponent<BoxCollider>().enabled = true;

                    Debug.Log("Entro");

                    if (Movimiento.enabled == false)
                    {
                        gato.transform.Rotate(new Vector3(90, 0, 0));
                        Movimiento.enabled = true;
                        limite.SetActive(true);
                        Reloj.GetComponent<global_sc_Temporizador>();




                    }

                }
                if (hit.transform.name == "Tree_03")
                {
                    if (Iniciador.activeInHierarchy == true)
                    {
                        //no hace nada
                        Debug.Log("Desactiva el iniciador");
                    }
                    else
                    {
                        animacion.SetBool("Entrecaminando", false);
                        animacion.SetBool("Sentar", false);
                        animacion.SetBool("Caminar", true);
                        Movimiento.enabled = true;
                        Movimiento.condicion = true;




                    }

                }
                else
                {
                    Movimiento.enabled = false;
                    Movimiento.condicion = false;
                    // Iniciador.SetActive(true); 

                }
                







                if (hit.transform.name == e.name)
                {//toco al contador
                    Movimiento.enabled = false;

                    e.SetActive(false);
                    Iniciador.SetActive(true);

                    Vector3 newpos = new Vector3(0.335f, 10.196f, 21.813f);
                    //newpos.x = 0.335f; newpos.y = 10.33f; newpos.z = 21.813f;

                    Rigidbody clon = (Rigidbody)Instantiate(a.GetComponent<Rigidbody>(), newpos, a.transform.rotation); 
                    clon.GetComponent<BoxCollider>().isTrigger = false;
                    seguimiento.enabled = false;
                  
                    nav.enabled = false;
                    a.transform.position = newpos;
                    clon.GetComponent<Animator>().SetBool("Sentar", false);
                    clon.GetComponent<Animator>().SetBool("Caminar", true);
                    clon.GetComponent<Animator>().SetBool("Entrecaminando", true);
                    a.GetComponent<Animator>().SetBool("Entrecaminando", false);
                    a.GetComponent<Animator>().SetBool("Sentar", false); ;
                    a.GetComponent<Animator>().SetBool("Caminar", false);
                    s.suma();
                    //  





                }
                


                    if (hit.transform.name != "Tree_03")
                {
                    if (Iniciador.activeInHierarchy==false) { 
                    animacion.enabled = true;
                    animacion.SetBool("Caminar", false);
                    animacion.SetBool("Entrecaminando", false);
                    animacion.SetBool("Sentar", true);
                    }
                }

                  


            }
            else{
             
             
                if (hit.collider==null) {
                    Puntero.SetActive(false);
                    //   Vector3 posicion = camera.transform.position;
                    //posicion.z = posicion.z + 5;
                    //Puntero.transform.position = posicion;
                   
                }
                //seguir al laser aunque no apuntes un objeto
                
             }
        }
        else {
            animacion.enabled = false;
            a.SetActive(false);
            Reloj.GetComponent<global_sc_Temporizador>().enabled = false;
        }

    }
    //_____---------------------
}
   
   
    

