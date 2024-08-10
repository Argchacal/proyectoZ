using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirPlayer : MonoBehaviour
{
    public float radioBusqueda;
    public LayerMask capaJugador;
    public Transform transformJugador;
    
    public float velocidadMovimiento;
    //variables para el estado de seguimiento
    public float distanciaMaxima;
    public Vector3 estadoInicialEnemigo;

    public estadoMovimiento estadoActual;
    public enum estadoMovimiento
    {
        esperando,
        siguiendo,
        volviendo,
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //estado inicial del enemigo
        estadoInicialEnemigo = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (estadoActual)
        {
            case estadoMovimiento.esperando:
                estadoEsperando();
                break;
            case estadoMovimiento.siguiendo:
                estadoSiguiendo();
                break;
            case estadoMovimiento.volviendo:
                estadiVolviendo();
                break;
        }
       
    }
    public void estadiVolviendo()
    {
        transform.position = Vector2.MoveTowards(transform.position,estadoInicialEnemigo, velocidadMovimiento * Time.deltaTime);
        //
        if (Vector2.Distance(transform.position, estadoInicialEnemigo) < 0.1f)
            {
                estadoActual = estadoMovimiento.esperando;
            }
    }
    public void estadoSiguiendo()
    {
        //esto es en caso de que nuestro personaje salga de la escena
        if (transformJugador == null)
        {
            estadoActual = estadoMovimiento.esperando;
            return;
        }  

        transform.position = Vector2.MoveTowards(transform.position,transformJugador.position, velocidadMovimiento * Time.deltaTime);
        if ((Vector2.Distance(transform.position, estadoInicialEnemigo) > distanciaMaxima)||
        Vector2.Distance(transform.position, transformJugador.position) > distanciaMaxima)
        {
            estadoActual = estadoMovimiento.volviendo;
            transformJugador = null;    
        }
    }
    private void estadoEsperando()   
    {
        Collider2D jugadorCollider = Physics2D.OverlapCircle(transform.position, radioBusqueda,capaJugador);
        if (jugadorCollider)        
        {
            transformJugador = jugadorCollider.transform;
            estadoActual = estadoMovimiento.siguiendo;
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(transform.position, radioBusqueda); 
        Gizmos.color = Color.green;  
        Gizmos.DrawWireSphere(estadoInicialEnemigo, distanciaMaxima);  
    }
}
