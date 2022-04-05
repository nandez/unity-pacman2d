using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.3f;

    private Animator animatorComponent;
    private Rigidbody2D rbComponent;


    private Vector2 nextPosition = Vector2.zero;
    private Vector2 currentDirection = Vector2.zero;

    void Start()
    {
        animatorComponent = GetComponent<Animator>();
        rbComponent = GetComponent<Rigidbody2D>();

        // Iniciamos con la posici�n actual.
        nextPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Utilizamos FixedUpdate para realizar los movimientos con f�sicas.
        rbComponent.MovePosition(Vector2.MoveTowards(transform.position, nextPosition, speed));

        // Verificamos el input del jugador para cambiar la direcci�n de movimiento.
        if(Input.GetKey(KeyCode.UpArrow) && CanMove(Vector2.up))
            currentDirection = Vector2.up;
        else if(Input.GetKey(KeyCode.DownArrow) && CanMove(-Vector2.up))
            currentDirection = -Vector2.up;
        else if(Input.GetKey(KeyCode.LeftArrow) && CanMove(-Vector2.right))
            currentDirection = -Vector2.right;
        else if( Input.GetKey(KeyCode.RightArrow) && CanMove(Vector2.right))
            currentDirection = Vector2.right;

        // Verificamos si es posible moverse en dicha direcci�n y calculamos
        // la siguiente posici�n.
        if(CanMove(currentDirection))
            nextPosition = (Vector2)transform.position + currentDirection;

        // Actualizamos las variables del animator para mostrar la animaci�n correcta
        // segun la direcci�n de movimiento.
        animatorComponent.SetFloat("Horizontal", currentDirection.x);
        animatorComponent.SetFloat("Vertical", currentDirection.y);
    }

    private bool CanMove(Vector2 dir)
    {
        // Proyecta un linecast entre el jugador y la posici�n siguiente al jugador para
        // detectar si existe colisi�n con el jugador.
        var ray = Physics2D.Linecast((Vector2)transform.position + dir, transform.position);
        return ray.collider == GetComponent<Collider2D>();
    }
}
