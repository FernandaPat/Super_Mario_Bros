using UnityEngine;

/*Autor: María Fernanda Pineda Pat 
Matricula: A01752828
Fecha: 21 de marzo de 2025
El codigo fue creado para mover al personaje horizontal y verticalmente, asignando velocidades independientes en los ejes X y Y */
public class MuevePersonaje : MonoBehaviour
{
    // Velocidades
    public float velocidadX;

    [SerializeField] // Permite al editor de Unity acceder a la variable
    private float velocidadY;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Inicializar rb
        rb = GetComponent<Rigidbody2D>();  
    }
    // FixedUpdate is called 60 fps
    void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        if (movVertical >0)
        {
            rb.linearVelocity =  new Vector2(rb.linearVelocityX, movVertical * velocidadY);
        } else{
            rb.linearVelocity =  new Vector2(movHorizontal * velocidadX, rb.linearVelocityY);
        }    

    }

}
