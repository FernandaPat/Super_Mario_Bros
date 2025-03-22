using UnityEngine;
using UnityEngine.UIElements;

public class TextoDeslizante : MonoBehaviour
{
    public float velocidad = 50f;

    private VisualElement texto;
    private float anchoTexto;
    private float anchoContenedor;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var contenedor = root.Q<VisualElement>("contenedorTexto");
        texto = root.Q<Label>("textoDeslizable");

        anchoTexto = texto.resolvedStyle.width;
        anchoContenedor = contenedor.resolvedStyle.width;

        texto.style.position = Position.Absolute;
        texto.style.left = anchoContenedor;
    }

    private void Update()
    {
        if (texto == null) return;

        float nuevaX = texto.style.left.value.value - velocidad * Time.deltaTime;

        if (nuevaX < -anchoTexto)
        {
            // Reinicia a la derecha
            nuevaX = anchoContenedor;
        }

        texto.style.left = nuevaX;
    }
}
