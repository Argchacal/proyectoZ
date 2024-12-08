using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMov : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float distancia;
    [SerializeField] private LayerMask queEsSuelo;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()   
    {
        rigidbody2D.velocity = new Vector2(velocidadMovimiento*transform.right.x,rigidbody2D.velocity.y );
        RaycastHit2D informacionSuelo = Physics2D.Raycast(transform.position, transform.right,distancia,queEsSuelo);
        if (informacionSuelo)
        {
            Girar();
        }
    }
    private void Girar()
    {
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y+180,0);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawLine(transform.position,transform.position+transform.right*distancia);
    }
}
