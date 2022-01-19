using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f1d2a5_ChoquePlayer : MonoBehaviour
{

    public bool perdio;
    private GameObject Score;
    // Start is called before the first frame update
    private void Start()
    {
       
        perdio = false;
        Score = GameObject.Find("Text (TMP)");
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Fruta")
        {
            Score.GetComponent<global_sc_Contador>().resta();
            perdio = true;
        }

    }
}
