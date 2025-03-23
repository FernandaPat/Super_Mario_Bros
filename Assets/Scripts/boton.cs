using UnityEngine;
using UnityEngine.UIElements;

public class boton : MonoBehaviour
{
    UIDocument botonr;
    Button botonSalir;

    void OnEnable()
    {
        botonr= GetComponent<UIDocument>();
        var root= botonr.rootVisualElement;
        botonSalir= root.Q<Button>("botonSalir");

        //Declarar callbacks
        botonSalir.RegisterCallback<ClickEvent>(IniciarSalir);
    }
    void IniciarSalir(ClickEvent evt){
        UnityEngine.SceneManagement.SceneManager.LoadScene("PaginaPrincipal");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
