using UnityEngine;

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

