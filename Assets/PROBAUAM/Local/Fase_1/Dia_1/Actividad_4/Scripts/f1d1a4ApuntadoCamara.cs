
using UnityEngine;
using UnityEngine.AI;


public class f1d1a4ApuntadoCamara : MonoBehaviour
{
    public Transform cabeza;
    public Transform posicionInicial;
    public float rayDistance;
    private GameObject gato, iniciador;
    //global_sc_Contador s;
    private Animator animacion;
    private AudioSource audios;
    private f1d1a4SeguimientoPelota Movimiento;
    //public Transform teleport;
    public int total;
    public GameObject Puntero;
    private GameObject limite, Reloj;//revisar si se necesita el limite
    public GameObject[] catToCopy;

    void Start()
    {   
        gato = GameObject.Find("cat");
        iniciador = GameObject.Find("Iniciador");
        limite = GameObject.Find("Limite");
        //posicionInicial = GameObject.Find("PosicionInicial");

        //s = ;
        // cabeza = transform.Find("VRCamera");
        Reloj = GameObject.Find("Canvas");
        Movimiento = gato.GetComponent<f1d1a4SeguimientoPelota>();
        Movimiento.enabled = false;

        animacion = gato.GetComponent<Animator>();
        
        gato.GetComponent<NavMeshAgent>().enabled = false;
        
        audios = gato.GetComponent<AudioSource>();
        audios.enabled = false;
        animacion.SetBool("Sentar", true);
        animacion.SetBool("Entrecaminando", false);
        animacion.SetBool("Caminar", false);
        gato.GetComponent<f1d1a4SeguimientoPlayer>().enabled = false;
        //contador.SetActive(false);
    }

    void Update()
    { 
        RaycastHit hit;
        if (limite.GetComponent<f1d1a4_s_Contador>().getContador() != total)
        {
            Debug.DrawRay(cabeza.position, cabeza.forward * rayDistance, Color.red);
            //Lerp
            if (Physics.Raycast(cabeza.position, cabeza.forward, out hit, rayDistance))
            {
                Puntero.SetActive(true);

                Debug.Log(hit.transform.name);

                Puntero.transform.position = hit.point;
                if (hit.transform.name == iniciador.name)
                {

                    //si apunta al   gato
                    iniciador.SetActive(false);
                    gato.GetComponent<BoxCollider>().enabled = true;
 
                    Debug.Log("Gato listo para caminar");

                    if (Movimiento.enabled == false)
                    {
                        gato.GetComponent<Rigidbody>().transform.Rotate(new Vector3(90, 0, 0));
                        Movimiento.enabled = true;
                        limite.SetActive(true);
                        Reloj.GetComponent<global_sc_Temporizador>();
                        ////que hace con el reloj aquí?
                    }

                }
                if (hit.transform.name == "Tree_03")
                {
                    if (iniciador.activeInHierarchy == true)
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
                        Movimiento.caminar = true;
                    }
                }
                else
                {
                    Movimiento.enabled = false;
                    Movimiento.caminar = false;
                }



                if (hit.transform.name == limite.name)
                {//toco al contador
                    Movimiento.enabled = false;

                    //contador.SetActive(false);
                    iniciador.SetActive(true);

                    //Vector3 newpos = new Vector3(0.335f, 10.196f, 21.813f);
                    //newpos.x = 0.335f; newpos.y = 10.33f; newpos.z = 21.813f;
                    

                    //int rand = Random.Range(0,2);
                    //Debug.Log("gato " + rand);

                    //Rigidbody clon = (Rigidbody)Instantiate(catToCopy[rand].GetComponent<Rigidbody>(), posicionInicial.position, gato.transform.rotation); 
                    
                    //clon.GetComponent<Animator>().SetBool("Sentar", false);
                    //clon.GetComponent<Animator>().SetBool("Caminar", false);
                    //clon.GetComponent<Animator>().SetBool("Entrecaminando", false);


                    //gato.GetComponent<BoxCollider>().isTrigger = false;

                    //gato.GetComponent<f1d1a4SeguimientoPlayer>().enabled = false;
                    //gato.GetComponent<NavMeshAgent>().enabled = false;
                    /*gato.transform.position = posicionInicial.position;
                    
                    gato.GetComponent<Animator>().SetBool("Entrecaminando", true);
                    gato.GetComponent<Animator>().SetBool("Sentar", false); ;
                    gato.GetComponent<Animator>().SetBool("Caminar", true);
                    limite.GetComponent<global_sc_Contador>().suma();*/
                }

                if (hit.transform.name != "Tree_03")
                {
                    if (iniciador.activeInHierarchy==false) { 
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
                    //   Vector3 posicion = cabeza.transform.position;
                    //posicion.z = posicion.z + 5;
                    //Puntero.transform.position = posicion;
                }
                //seguir al laser aunque no apuntes un objeto
             }
        }
        else {
            animacion.enabled = false;
            gato.SetActive(false);
            Reloj.GetComponent<global_sc_Temporizador>().enabled = false;
        }
    }
}
   
   
    

