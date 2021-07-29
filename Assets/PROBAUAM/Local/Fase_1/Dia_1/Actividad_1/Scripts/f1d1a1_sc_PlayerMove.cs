using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class f1d1a1_sc_PlayerMove : MonoBehaviour
{
    public GameObject player;
    private GameObject score;
    private GameObject piernaIzquierda;
    private GameObject piernaDerecha;
    Vector3 posicionPlayer,posPiernaIz,posPiernaDer;
    double rangoD, rangoI;
    private bool Simulador = false;
    public SteamVR_Action_Pose pose;

    // Start is called before the first frame update
    void Start()
    {
        piernaIzquierda = GameObject.Find("LeftHand");
        piernaDerecha = GameObject.Find("RightHand");
        score = GameObject.Find("Canvas");
        posicionPlayer = player.transform.position;
        if (piernaIzquierda.GetComponent<Hand>().noSteamVRFallbackCamera != null ||
            piernaDerecha.GetComponent<Hand>().noSteamVRFallbackCamera != null)
        {
            Simulador = true;
            posPiernaIz = piernaIzquierda.transform.position;
            posPiernaDer = piernaDerecha.transform.position;
            rangoD = posPiernaDer.y + 0.3;
            rangoI = posPiernaIz.y + 0.3;
        }
        else
        {
            posPiernaIz = pose.GetLocalPosition(SteamVR_Input_Sources.LeftHand);
            posPiernaDer = pose.GetLocalPosition(SteamVR_Input_Sources.RightHand);
            rangoD = posPiernaDer.y + 0.3;
            rangoI = posPiernaIz.y + 0.3;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!Simulador)
        {
            //Modo HMD
            //if (Input.GetKey("b"))
            if (posPiernaDer.y > rangoD && posPiernaIz.y < rangoI)
            {
                posicionPlayer.x = 1f;
                player.transform.position = posicionPlayer;
                score.GetComponent<f1d1a1_sc_Puntaje>().suma();
            }
            //else if (Input.GetKey("v"))
            else if (posPiernaDer.y < rangoD && posPiernaIz.y > rangoI)
            {
                posicionPlayer.x = -1f;
                player.transform.position = posicionPlayer;
                score.GetComponent<f1d1a1_sc_Puntaje>().suma();
            }
            else if (posPiernaDer.y < rangoD && posPiernaIz.y < rangoI)
            {
                posicionPlayer.x = 0f;
                player.transform.position = posicionPlayer;
            }
        }

        else
        {
            //Modo Simulador
            //if (Input.GetKey("b"))
            if (posPiernaDer.y > rangoD && posPiernaIz.y < rangoI)
            {
                posicionPlayer.x = 1f;
                player.transform.position = posicionPlayer;
                score.GetComponent<f1d1a1_sc_Puntaje>().suma();
            }
            //else if (Input.GetKey("c"))
            else if (posPiernaDer.y < rangoD && posPiernaIz.y > rangoI)
            {
                posicionPlayer.x = 1f;
                player.transform.position = posicionPlayer;
                score.GetComponent<f1d1a1_sc_Puntaje>().suma();
            }
            //else if (Input.GetKey("v"))
            else if (posPiernaDer.y < rangoD && posPiernaIz.y < rangoI)
            {
                posicionPlayer.x = 0f;
                player.transform.position = posicionPlayer;
            }
        }
    }
}
