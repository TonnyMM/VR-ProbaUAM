using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class global_s_Events_example : MonoBehaviour
{
    private GameObject mano_derecha;
    private GameObject mano_izquierda;
    public SteamVR_Action_Pose headPose;
    public SteamVR_Action_Boolean gatillo;
    public SteamVR_Action_Boolean pinsa;
    public SteamVR_Action_Boolean teleport;
    //public SteamVR_Action_Boolean  
    public SteamVR_Action_Boolean headset;
    public SteamVR_Action_Boolean snapTL;
    public SteamVR_Action_Boolean snapTR;
    public SteamVR_Action_Single apretar;

    private float squeeze = 0;

    void Start()
    {
        mano_derecha = GameObject.Find("RightHand");
        mano_izquierda = GameObject.Find("LeftHand");
    }

    // Update is called once per frame
    void Update()
    {
        if(mano_izquierda.GetComponent<Hand>().noSteamVRFallbackCamera == null){
                //HMD
            Debug.Log("Head Pose" + headPose.GetLocalPosition(SteamVR_Input_Sources.Head));

            
            Debug.Log("Se presionó"+ gatillo.GetStateDown(SteamVR_Input_Sources.RightHand));
            Debug.Log("Se soltó" + gatillo.GetStateUp(SteamVR_Input_Sources.RightHand));
            Debug.Log("Se mantiene presionado" + gatillo.GetState(SteamVR_Input_Sources.RightHand));
            
            Debug.Log("Apretando " + apretar.GetAxis(SteamVR_Input_Sources.RightHand));
              
        }
        else {
                //Fallback Camera
                //Simulator

            Debug.Log("Se presionó"+ Input.GetMouseButtonDown(0));
            Debug.Log("Se soltó" + Input.GetMouseButtonUp(0));
            Debug.Log("Se mantiene presionado" + Input.GetMouseButton(0));

            squeeze += Input.GetAxis("Mouse ScrollWheel");
            squeeze = Mathf.Clamp(squeeze,0,1);
            Debug.Log("Apretando " + squeeze);
        }
    }
}
