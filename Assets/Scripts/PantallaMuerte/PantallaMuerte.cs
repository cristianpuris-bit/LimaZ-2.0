using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaMuerte : MonoBehaviour
{
    public GameObject panelMuerte; 
    public string nombreEscenaMenu = "Menu";
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void MostrarPantallaMuerte()
    {
        panelMuerte.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void Reintentar()
    {
        Time.timeScale = 1f; 
        Scene escenaActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escenaActual.name);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(nombreEscenaMenu);
    }
}
