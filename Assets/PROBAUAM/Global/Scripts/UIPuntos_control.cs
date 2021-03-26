using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using TMPro;

public class UIPuntos_control : MonoBehaviour
{
    ///<summary>
    ///Esta clase se encarga de contener los datos necesarios para el puntaje
    ///</summary>
    ///
    public GameObject meshtext;
    public string mensaje;

    private void Start()
    {
        meshtext.GetComponent<TextMeshProUGUI>().text = mensaje;
    }

    private void Update()
    {
        transform.LookAt(Player.instance.hmdTransform);
    }
}
