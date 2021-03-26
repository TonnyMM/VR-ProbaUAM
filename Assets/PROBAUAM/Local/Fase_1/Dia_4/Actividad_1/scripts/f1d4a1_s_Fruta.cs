using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class f1d4a1_s_Fruta : MonoBehaviour
{
    //sistema para puntuacion
    public int puntos;

    public string color_fruta;
    public Material mat_color_acerto;

    [HideInInspector]
    public bool bowl_correcto;
    public float tiempo;
    [HideInInspector]
    public string origino;

    public GameObject particulas_izq;
    public GameObject particulas_der;
    public float duracion_particulas;
    [HideInInspector]
    public bool activo_particulas;

    private Vector3 ultima_posicion;
    private Rigidbody rb;
    private Vector3 velocidad;
    private bool cayo = false;
    private control_puntuacion control_puntos;
    private f1d4a1_s_control_alternaciones control_alternaciones;

    [Header("La fruta que tipo de collider tiene")]
    public bool collMesh;
    public bool collSphere;
    public bool collCapsule;
    private int tipoColl;

    
    

    void Start() {

        ultima_posicion = transform.position;
        rb = GetComponent<Rigidbody>();
        //control_puntos = GameObject.Find("Controlador").GetComponent<control_puntuacion>();
        control_alternaciones = GameObject.Find("Controlador").GetComponent<f1d4a1_s_control_alternaciones>();

        if(collMesh)
        {
            //tiene un MeshCollider
            collCapsule=false;
            collSphere=false;
            tipoColl = 0;
        }else if(collCapsule)
        {
            //tiene un CapsuleCollider
            collMesh = false;
            collSphere = false;
            tipoColl = 1;
        }else if(collSphere)
        {
            //tiene un SphereCollider
            collCapsule = false;
            collMesh = false;
            tipoColl = 2;
        }

    }

    private void Update() {
        //revisamos si ya entro al bowl correcto y apagamos algunos de los codigos de la fruta
        if(bowl_correcto)
        {
            gameObject.AddComponent(typeof(IgnoreHovering));
            GetComponent<f1d4a1_s_Fruta>().enabled = false;
            //si es el bowl correcto
            //Sistema_UIPuntos.GenerarUI(transform.position, "+"+puntos);
        }
        
        //si tiene en la mano un objeto apagamos el collider del objeto que tiene en la mano
        if(Player.instance.hands[0].ObjectIsAttached(this.gameObject) || Player.instance.hands[1].ObjectIsAttached(this.gameObject))
        {
            tipoCollider(false);
        }else
        {
            tipoCollider(true);
        }

        //aqui revisaremos quien origino a esta fruta y respecto de este valor le activamos un sistema de particulas
        if(origino != null && activo_particulas==false)
        {
            switch (origino)
            {
                case "Derecha":
                particulas_der.SetActive(true);
                particulas_izq.SetActive(false);
                //Destroy(particulas_der,duracion_particulas);
                activo_particulas=true;
                break;

                case "Izquierda":
                particulas_der.SetActive(false);
                particulas_izq.SetActive(true);
                //Destroy(particulas_izq,duracion_particulas);
                activo_particulas=true;
                break;
                
            }
        }
        
    }

    void FixedUpdate() {

        if (cayo)
        {
            if(rb.useGravity)
            {
                 gameObject.AddComponent(typeof(IgnoreHovering));
            }
            rb.useGravity = false;
            rb.isKinematic = true;
            transform.position = Vector3.SmoothDamp(transform.position, ultima_posicion, ref velocidad, tiempo);
            tipoCollider(false);
            if (Vector3.Distance(transform.position, ultima_posicion) < 0.2f)
            {
                if(cayo)
                {
                    cayo = false;
                    Destroy(GetComponent<IgnoreHovering>());
                    rb.useGravity = true;
                    rb.isKinematic = false;
                    tipoCollider(true);
                }
                
            }
        }
    }

    void tipoCollider(bool valor)
    {
        if(tipoColl == 0)
            {
                GetComponent<MeshCollider>().enabled = valor;
            } else if (tipoColl == 1)
            {
                GetComponent<CapsuleCollider>().enabled = valor;
            } else if (tipoColl == 2)
            {
                GetComponent<SphereCollider>().enabled = valor;
            }
    }


    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "bowl")
        {
            //revisamos si el bowl en el que cayo la fruta tiene el mismo color que la fruta 
            if (other.GetComponentInParent<f1d4a1_s_Bowl>().color_bowl == color_fruta)
            {
                GetComponentInChildren<MeshRenderer>().material = mat_color_acerto;
                //control_puntos.Puntuar(puntos);
                if (origino == "Derecha")
                {
                    Sistema_Vibraciones.pulso(origino, 1, 30, 30, SteamVR_Input_Sources.RightHand);
                }
                else if (origino == "Izquierda")
                {
                    Sistema_Vibraciones.pulso(origino, 1, 30, 30, SteamVR_Input_Sources.LeftHand);
                }

                control_alternaciones.origino(this.origino);
                bowl_correcto = true;
            }
            else
            {
                //es el bowl incorrecto
                //Sistema_UIPuntos.GenerarUI(other.transform.position, "-"+puntos);
                //control_puntos.Puntuar(-puntos);
            }
        }

        if (other.tag == "Suelo")
        {
            cayo = true;
        }


    }
}
