using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class f1d1a1_sc_Victoria : MonoBehaviour
{
    public GameObject plano,mesa,obstaculos,final,personaje,victoria;
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            plano.GetComponent<Rigidbody>().isKinematic = true;
            mesa.GetComponent<Rigidbody>().isKinematic = true;
            obstaculos.GetComponent<Rigidbody>().isKinematic = true;
            final.GetComponent<Rigidbody>().isKinematic = true;
            victoria.SetActive(true);
            personaje.SetActive(false);
            //personaje.GetComponent<Animator>().SetBool("Ganar",true);
        }
    }
}
