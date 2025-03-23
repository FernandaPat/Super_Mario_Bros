using UnityEngine;
using UnityEngine.UIElements;

/*
Autor: María Fernanda Pineda Pat 
Matrícula: A01752828
Este codigo hace que al presionar el boton de la equis o el de regresar en la interfaz hecha con UI Toolkit,
se vaya al menun principal
Fecha: 22 de marzo de 2025
*/
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
}
