using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Animator animator;
    public float speedMov;
    private Rigidbody2D rigidbody2D;
    private Vector3 velosity;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        if (hor != 0 || ver != 0)
        {
            //el "horizontal" es el nombre que le dimos en el animator muestra la direccion
            animator.SetFloat("horizontal", hor);
            animator.SetFloat("vertical", ver);
            animator.SetFloat("speed", 1);
            //obtenemos la direccion de movimiento
            Vector3 direction = (Vector3.up * ver + Vector3.right *hor).normalized;
            velosity = direction * speedMov;
            //realizamos el movimiento
            //transform.Translate(direction* speedMov * Time.deltaTime);

            

        }
        else
        {
            animator.SetFloat("speed", 0);
            velosity = Vector3.zero;
        }
    }
    void FixedUpdate()
    {
        rigidbody2D.MovePosition( transform.position + velosity * Time.fixedDeltaTime);

    }
}
