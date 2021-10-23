using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class f1d5a8_sc_Idicaciones : MonoBehaviour
{
    public Text indicador;
    private GameObject raqueta1, raqueta2, raqueta3, guante1, guante2, teni1, teni2, pantunfla, calcetin1, calcetin2;

    // Start is called before the first frame update
    void Start()
    {
        raqueta1 = GameObject.Find("Raqueta (1)");
        raqueta2 = GameObject.Find("Raqueta (2)");
        raqueta3 = GameObject.Find("Raqueta (3)");
        guante1 = GameObject.Find("Guante (1)");
        guante2 = GameObject.Find("Guante (2)");
        teni1 = GameObject.Find("teni (1)");
        teni2 = GameObject.Find("ten");
        pantunfla = GameObject.Find("Pantufla (1)");
        calcetin1 = GameObject.Find("Calcetin (1)");
        calcetin2 = GameObject.Find("Calcetin (2)");

    }

    // Update is called once per frame
    void Update()
    {
        if (raqueta1.GetComponent<Interactable>().attachedToHand || raqueta2.GetComponent<Interactable>().attachedToHand ||
            raqueta3.GetComponent<Interactable>().attachedToHand || guante1.GetComponent<Interactable>().attachedToHand ||
            guante2.GetComponent<Interactable>().attachedToHand || teni1.GetComponent<Interactable>().attachedToHand ||
            teni2.GetComponent<Interactable>().attachedToHand || pantunfla.GetComponent<Interactable>().attachedToHand ||
            calcetin1.GetComponent<Interactable>().attachedToHand || calcetin2.GetComponent<Interactable>().attachedToHand)
        {
            indicador.text = "¡ Camina hacia atras !";
        }
        else
        {
            indicador.text = "";
        }

    }

}
