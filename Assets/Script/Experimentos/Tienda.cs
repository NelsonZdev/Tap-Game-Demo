using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Objeto
{
    public string nombreDelPrducto;
    public Sprite imagenDelProducto;
    public float valorBaseDelProducto;
    [Range(0, 100)] public float porcentajeDeIncremento;
    [Range(1, 100)] public int maxMejoras = 1;
    public Button.ButtonClickedEvent _onClick;
}

public class Tienda : MonoBehaviour
{
    public GameObject prefabBoton;
    public Transform contentPanel;
    public Objeto[] listaObjetos;

    public static int _NumeroDeMejoras; // Comparte informacion de mejoras del boton "Producto:_Arbol"
    public static int _MaxMejoras;
    private Producto productoArbol; //Script necesario para efectuar cambios en el sprite del arbol

    void Awake()
    {
        ListaDeCompras();
    }

    void Update()
    {
        _NumeroDeMejoras = productoArbol.mejorasEchas;
    }
    void ListaDeCompras()
    {
        foreach (var objeto in listaObjetos)
        {
            GameObject nuevoBoton = Instantiate(prefabBoton) as GameObject;
            Producto scriptProducto = nuevoBoton.GetComponent<Producto>();
            nuevoBoton.name = "Producto:_"+objeto.nombreDelPrducto;
            scriptProducto.nombreDelPrducto = objeto.nombreDelPrducto;
            scriptProducto.valorBaseDelProducto = objeto.valorBaseDelProducto;
            scriptProducto.imagenDelProducto.sprite = objeto.imagenDelProducto;
            scriptProducto.porcentajeDeIncremento = objeto.porcentajeDeIncremento;
            scriptProducto.maxMejoras = objeto.maxMejoras;
            scriptProducto.botonLocal.onClick = objeto._onClick;
            
            nuevoBoton.transform.SetParent(contentPanel);

            if (nuevoBoton.name == "Producto:_Arbol")
            {
                productoArbol = nuevoBoton.GetComponent<Producto>();
                _NumeroDeMejoras = nuevoBoton.GetComponent<Producto>().mejorasEchas;
                _MaxMejoras = nuevoBoton.GetComponent<Producto>().maxMejoras;
            }
        }
    }

}
