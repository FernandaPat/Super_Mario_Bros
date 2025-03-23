using UnityEngine;
using UnityEngine.UIElements;

/*
Autor: María Fernanda Pineda Pat 
Matrícula: A01752828
Este codigo hace que el texto de los créditos se desplace automaticamente de
abajo hacia arriba dentro de un contenedor fijo.Cuando el texto llega al final 
vuelven a empezar 
Fecha: 22 de marzo de 2025
    */
    public class CreditosScroller : MonoBehaviour
    {
        public float velocidadScroll = 50f;

        private VisualElement creditos;
        private Label texto;
        private float startY;
        private float endY;
        private bool animacionIniciada = false;

        void OnEnable()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            creditos = root.Q<VisualElement>("ContenedorCreditos");
            texto = root.Q<Label>("TextoCreditos");

            // Esperar a que se carguen los estilos y tamaños
            Invoke(nameof(InicializarAnimacion), 0.1f);
        }

        void InicializarAnimacion()
        {
            startY = creditos.resolvedStyle.height;
            texto.style.top = startY;

            endY = -texto.resolvedStyle.height;

            animacionIniciada = true;
        }

        void Update()
        {
            if (!animacionIniciada) return;

            float currentTop = texto.style.top.value.value;

            // Mover hacia arriba
            currentTop -= velocidadScroll * Time.deltaTime;
            texto.style.top = currentTop;

            // Reiniciar cuando llegue al final
            if (currentTop <= endY)
            {
                texto.style.top = startY;
            }
        }
    }