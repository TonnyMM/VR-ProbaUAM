using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class f1d1a1_sc_Obstaculo : MonoBehaviour
{
    private GameObject obstaculo1, obstaculo2, obstaculo3, obstaculo4, obstaculo5, obstaculo6, obstaculo7, obstaculo8, obstaculo9, obstaculo10;
    GameObject[] obstaculos = new GameObject[10];
    public GameObject plano, mesa, obst, final,personaje;
    public Animator animacion;
    Vector3 Rango;
    public f1d1a1_sc_Timer timer;


    void Start()
    {
        obstaculo1 = GameObject.Find("Obstaculo1");
        obstaculo2 = GameObject.Find("Obstaculo2");
        obstaculo3 = GameObject.Find("Obstaculo3");
        obstaculo4 = GameObject.Find("Obstaculo4");
        obstaculo5 = GameObject.Find("Obstaculo5");
        obstaculo6 = GameObject.Find("Obstaculo6");
        obstaculo7 = GameObject.Find("Obstaculo7");
        obstaculo8 = GameObject.Find("Obstaculo8");
        obstaculo9 = GameObject.Find("Obstaculo9");
        obstaculo10 = GameObject.Find("Obstaculo10");

        obstaculos[0] = obstaculo1;
        obstaculos[1] = obstaculo2;
        obstaculos[2] = obstaculo3;
        obstaculos[3] = obstaculo4;
        obstaculos[4] = obstaculo5;
        obstaculos[5] = obstaculo6;
        obstaculos[6] = obstaculo7;
        obstaculos[7] = obstaculo8;
        obstaculos[8] = obstaculo9;
        obstaculos[9] = obstaculo10;

        for (int i = 0; i < obstaculos.Length; i++)
        {
            if (Random.Range(-1.8f, 1.8f) < 0)
            {
                Rango = new Vector3(-1.8f, obstaculos[i].transform.position.y, obstaculos[i].transform.position.z);
            }
            else
            {
                Rango = new Vector3(1.8f, obstaculos[i].transform.position.y, obstaculos[i].transform.position.z);
            }
            obstaculos[i].transform.position = Rango;
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            plano.GetComponent<Rigidbody>().isKinematic = true;
            mesa.GetComponent<Rigidbody>().isKinematic = true;
            obst.GetComponent<Rigidbody>().isKinematic = true;
            final.GetComponent<Rigidbody>().isKinematic = true;
            personaje.GetComponent<Rigidbody>().isKinematic = true;
            timer.enabled = true;
            animacion.SetBool("Parar", true);
        }
    }
}
