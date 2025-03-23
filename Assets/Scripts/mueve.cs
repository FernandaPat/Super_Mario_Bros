using UnityEngine;
/*
Autor: María Fernanda Pineda Pat 
Matrícula: A01752828
Este código controla el movimiento del personaje; para que se mueva hosrizontalmente y hacia arriba.
Tambien acualiza las animaciones dependiendo de la velocidad y si esta en el aire o no, gira el sprite 
dependiendo de la direccion del personaje
Fecha: 21 de marzo de 2025*/

public class MuevePersonaje : MonoBehaviour
{
    public float velocidadX;
    [SerializeField]
    private float fuerzaSalto = 300f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private float movHorizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Captura del input (solo aquí)
        movHorizontal = Input.GetAxis("Horizontal");

        // Animaciones
        animator.SetFloat("velocidad", Mathf.Abs(movHorizontal));
        animator.SetBool("EnElAire", rb.linearVelocity.y > 0.1f || rb.linearVelocity.y < -0.1f);

        // Voltear sprite
        if (movHorizontal < 0)
            spriteRenderer.flipX = true;
        else if (movHorizontal > 0)
            spriteRenderer.flipX = false;

        // Salto libre
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * fuerzaSalto);
        }
    }

    void FixedUpdate()
    {
        // Movimiento físico
        rb.linearVelocity = new Vector2(movHorizontal * velocidadX, rb.linearVelocity.y);
    }
}

