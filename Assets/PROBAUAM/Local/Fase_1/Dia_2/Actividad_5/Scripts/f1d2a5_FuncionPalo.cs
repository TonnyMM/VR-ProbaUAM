using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class f1d2a5_FuncionPalo : MonoBehaviour
{
    public bool Seleccion;
    public GameObject Izquierdo, derecho, palo, frutas, mesa;
    public GameObject detector;
    private Interactable interactable;
    private GameObject Score;
   
   
    void Start()
    {
        interactable = GetComponent<Interactable>();
        Seleccion = false;
        frutas = GameObject.Find("fruta");
        Score = GameObject.Find("Text (TMP)");
        detector.SetActive(false);


    }

   
    void Update()
    {
      
       
        if (interactable.attachedToHand)
        {
            if (interactable.attachedToHand.handType == SteamVR_Input_Sources.RightHand)
            {
                // if (interactable.attachedToHand.handType == SteamVR_Input_Sources.LeftHand)
                //{
                if (detector.activeInHierarchy == false)
                {
                    GetComponent<CapsuleCollider>().isTrigger = true;
                   
                    frutas.GetComponent<f1d2a5_GeneradorFrutas>().enabled = true;
                    if (Seleccion == true)
                    {
                        //incremento
                        Seleccion = false;
                        frutas.GetComponent<f1d2a5_GeneradorFrutas>().validador = true;

                    }
                }
                else {
                 

                }
                //}
                //else { Debug.Log("Te falta la mano izquierda"); 
                  //   }
            }
            else { Debug.Log("Inicia con la derecha");
                GetComponent<CapsuleCollider>().isTrigger = false;
            }

            Debug.Log(interactable.attachedToHand.handType);
        }
        else { GetComponent<CapsuleCollider>().isTrigger = false;
            frutas.GetComponent<f1d2a5_GeneradorFrutas>().enabled = false;
             }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Fruta")
        {
            Score.GetComponent<global_sc_Contador> ().suma();
           Destroy( other.transform.gameObject);
            frutas.GetComponent<f1d2a5_GeneradorFrutas>().enabled = false;
            Seleccion = true;
            detector.SetActive(true);
            //palo.GetComponent<Throwable>().enabled = false;
            //palo.GetComponent<Throwable>().enabled = true;
        }
        if (other.name=="detector") {
            detector.SetActive( false);
        }

        if (other.name == "Plane")
        {
            
            palo.transform.position = new Vector3(-7.075f, 0.700f, 15.505f);
        }
        
       
    }
}
