using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

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