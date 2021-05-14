using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Eventos : MonoBehaviour
{
    private Interactable interactable;
    private GameObject manoIzquierda;
    private GameObject manoDerecha; 
    public SteamVR_Action_Pose pose;
    public SteamVR_Action_Boolean gatillo;
    public SteamVR_Action_Boolean pinsa;
    public SteamVR_Action_Boolean teleport;
    public SteamVR_Action_Boolean headset;
    public SteamVR_Action_Single apretar;

    private bool Simulador = false;
    private float squeeze = 0;
    GameObject SimulatorHead;
    void Start()
    {
        interactable = GetComponent<Interactable>();
        manoIzquierda = GameObject.Find("LeftHand");
        manoDerecha = GameObject.Find("RightHand");
        if(manoIzquierda.GetComponent<Hand>().noSteamVRFallbackCamera != null || 
            manoDerecha.GetComponent<Hand>().noSteamVRFallbackCamera != null){
                Simulador = true;
                SimulatorHead = GameObject.Find("FollowHead");
            }
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable.attachedToHand){
            Debug.Log(interactable.attachedToHand.handType);
        }

        if(!Simulador){
                //Modo HMD
                Debug.Log("Head Pose " + pose.GetLocalPosition(SteamVR_Input_Sources.Head));
                Debug.Log("Se presiono el gatillo " + gatillo.GetLastStateDown(SteamVR_Input_Sources.RightHand));
                Debug.Log("Se solto el gatillo " + gatillo.GetLastStateUp(SteamVR_Input_Sources.RightHand));
                Debug.Log("Se mantiene el gatillo " + gatillo.GetLastState(SteamVR_Input_Sources.RightHand));

                Debug.Log("Se apretó " + apretar.GetAxis(SteamVR_Input_Sources.RightHand));
            }

            else{
                //Modo Simulador
                Debug.Log("Simulator Head " + SimulatorHead.transform.position);

                Debug.Log("Simulador: Se presiono el gatillo " + Input.GetMouseButtonDown(0));
                Debug.Log("Simulador: Se solto el gatillo " + Input.GetMouseButtonUp(0));
                Debug.Log("Simulador: Se mantiene el gatillo " + Input.GetMouseButton(0));

                squeeze += Input.GetAxis("Mouse ScrollWheel");
                squeeze = Mathf.Clamp(squeeze, 0, 1);
                Debug.Log("Simulador: Se apretó " + squeeze);
            }

    }
}
