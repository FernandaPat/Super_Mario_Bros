using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

/*
Autor: María Fernanda Pineda Pat 
Matrícula: A01752828
Este codigo conecta los 4 botones de la interfaz para que cuando haga click en el boton cargue 
a las escenas correspondientes; de igual manera se cierra el juego con la funcion Application.Quit() 
cuando se presiona el boton de salir
Fecha: 22 de marzo de 2025
*/
public class MenuController : MonoBehaviour
{
    UIDocument menu;
    Button botonJugar;
    Button botonAyuda;
    Button botonCreditos;
    Button botonAbandonar;
    void OnEnable()
    {
        menu= GetComponent<UIDocument>();
        var root= menu.rootVisualElement;
        botonJugar= root.Q<Button>("botonJugar");
        botonAyuda= root.Q<Button>("botonAyuda");
        botonCreditos= root.Q<Button>("botonCreditos");
        botonAbandonar= root.Q<Button>("botonAbandonar");

        //Declarar callbacks
        botonJugar.RegisterCallback<ClickEvent>(IniciarJugar);
        botonAyuda.RegisterCallback<ClickEvent>(IniciarAyuda);
        botonCreditos.RegisterCallback<ClickEvent>(IniciarCreditos);
        botonAbandonar.RegisterCallback<ClickEvent>(SalirDelJuego);
    }
    private void IniciarJugar(ClickEvent evt){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Jugar");
    }
    private void IniciarAyuda(ClickEvent evt){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Ayuda");
    }
    private void IniciarCreditos(ClickEvent evt){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Creditos");
    }   
    private void SalirDelJuego(ClickEvent evt){
        Application.Quit();
        Debug.Log("Cerrando juego...");
    }
}