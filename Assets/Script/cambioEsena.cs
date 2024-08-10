using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cambioEsena : MonoBehaviour
{
    //OnTriggerEnter2D para que si toca un trigger ejecute esta funcion
    private int randomNumber;
    private void OnTriggerEnter2D(Collider2D collision)
    
    {
        if (collision.gameObject.tag == "Player")
        {
            int randomNumber = Random.Range(0, 4);
            SceneManager.LoadScene(randomNumber);
            Debug.Log("Número aleatorio: " + randomNumber);
            
        }
    }
}
