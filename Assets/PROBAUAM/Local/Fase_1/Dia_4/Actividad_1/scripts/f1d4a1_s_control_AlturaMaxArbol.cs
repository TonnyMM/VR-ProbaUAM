using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class f1d4a1_s_control_AlturaMaxArbol : MonoBehaviour
{
    public SteamVR_Action_Boolean acciongatillo_bool;//aqui llamamos a las acciones del Bindindig
	//public SteamVR_Action_Pose posicion_control;
    public GameObject prefab_arbol;
    public GameObject posicion_inicial;//es la posicion donde debe de iniciar a jugar

    private GameObject mano_derecha;
    private GameObject mano_izquierda;
    private bool configurado_L;
    private bool configurado_R;
    private Vector3 posicion_max_L;
    private Vector3 posicion_max_R;
    private bool instancio_arbol_L;
    private bool instancio_arbol_R;

    private bool valorgatillo_L;
    private bool valorgatillo_R;
    
    private void Start() {
        mano_derecha = GameObject.Find("RightHand");
        mano_izquierda = GameObject.Find("LeftHand");
    }
    
   void Update()
   {
        if(Vector3.Distance(Player.instance.hmdTransform.position.normalized,posicion_inicial.transform.position.normalized) < .4f)
        {
            if(mano_izquierda.GetComponent<Hand>().noSteamVRFallbackCamera == null){
                //HMD
                valorgatillo_L = acciongatillo_bool.GetStateDown(SteamVR_Input_Sources.LeftHand);
                valorgatillo_R = acciongatillo_bool.GetStateDown(SteamVR_Input_Sources.RightHand);
            }
            else{
                //Simulador
                //Resviso en las manos del simulador si la mano que esta activa es la izquierda o la derecha 
                //y luego escucho si se genera el evento del mouse que indica el clic con el gatillo
                if(mano_izquierda.GetComponent<Hand>().activeHand == SteamVR_Input_Sources.LeftHand){
                    valorgatillo_L = Input.GetMouseButtonDown(0);
                }
                else if(mano_izquierda.GetComponent<Hand>().activeHand == SteamVR_Input_Sources.RightHand){
                    valorgatillo_R = Input.GetMouseButtonDown(0);
                }
            }

            Debug.Log("gsatillo L: " + valorgatillo_L);
            Debug.Log("gsatillo R: " + valorgatillo_R);
        }

        //** */Esta parte revisamos cuando el jugador presiona el gatiillo a la altura deseada/
        if(valorgatillo_L && configurado_L==false)
        {
            //presiono el gatillo y guardamos la posicion del control
            ////posicion_max_L = posicion_control.GetLocalPosition(SteamVR_Input_Sources.LeftHand);
            posicion_max_L = mano_izquierda.transform.position;
            configurado_L=true;
        }

        if(valorgatillo_R && configurado_R==false)
        {
            //presiono el gatillo y guardamos la posicion del control
            ////posicion_max_R = posicion_control.GetLocalPosition(SteamVR_Input_Sources.RightHand);
            posicion_max_R = mano_derecha.transform.position;
            configurado_R = true;
        }

        //** */Esta parte es para cuando ya tenemos las alturas e instanciamos los arboles/
        if(posicion_max_L != Vector3.zero && instancio_arbol_L == false)
        {
            GameObject arbol_L = Instantiate(prefab_arbol,posicion_max_L,Quaternion.identity) as GameObject;
            arbol_L.name = "Arbol_Izquierda";
            instancio_arbol_L = true;
            arbol_L.GetComponent<f1d4a1_s_Dispensador>().origino = "Izquierda";
            GetComponent<f1d4a1_s_control_alternaciones>().set_arbol_L(arbol_L);
            GetComponent<f1d4a1_s_control_alternaciones>().existe_arbol_L = true;
        }

        if(posicion_max_R != Vector3.zero && instancio_arbol_R == false)
        {
            GameObject arbol_R = Instantiate(prefab_arbol,posicion_max_R,prefab_arbol.transform.rotation) as GameObject;
            arbol_R.name = "Arbol_Derecha";
            instancio_arbol_R = true;
            arbol_R.GetComponent<f1d4a1_s_Dispensador>().origino = "Derecha";
            GetComponent<f1d4a1_s_control_alternaciones>().set_arbol_R(arbol_R);
            GetComponent<f1d4a1_s_control_alternaciones>().existe_arbol_R = true;
        }

   }
}
