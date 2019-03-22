using UnityEngine;
using UnityEngine.UI;

public class Producto : MonoBehaviour
{

    public string nombreDelPrducto;
    public Image imagenDelProducto;
    public float valorBaseDelProducto;
    [Range(0,100)]public float porcentajeDeIncremento;
    [Range(1,100)]public int maxMejoras = 1;
    public Text textoValor,textoNombre,TextoMejorasRealizadas;
    [HideInInspector]
    public Button botonLocal;
    [HideInInspector]
    public int mejorasEchas = 0;
    private float valorFinal;
    private Slider barraInfo;

    void Awake()
    {
        botonLocal = GetComponent<Button>();
        barraInfo = GetComponentInChildren<Slider>();
    }
    void Start()
    {
        botonLocal.onClick.AddListener(Mejoras);
        textoNombre.text = nombreDelPrducto;
        barraInfo.maxValue = maxMejoras;
    }
    void Update()
    {
        barraInfo.value = mejorasEchas;
        botonLocal.interactable = InteraccionBoton;
        TextoMejorasRealizadas.text = mejorasEchas.ToString("00.");
        if (mejorasEchas < maxMejoras)
        {
            textoValor.text = TextoValor;
        }
        else
        {
            textoValor.text = "Max!";
        }
        
    }
    public bool InteraccionBoton
    {
        get
        {
            if (mejorasEchas < maxMejoras)
            {
                if (ValorObjeto >= Dinero.dineroTotal)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

        }
    }
    public float ValorObjeto
    {
        get
        {           
            if (mejorasEchas == 0)
            {
                return valorBaseDelProducto;
            }
            else
            {
                return valorFinal;
            }      
        }
    }
    void Mejoras()
    {
        if (Dinero.dineroTotal >= ValorObjeto)
        {
            if (mejorasEchas < maxMejoras)
            {
                Dinero.dineroTotal -= ValorObjeto;
                mejorasEchas++;
                if (mejorasEchas == 1)
                {
                    valorFinal = (valorBaseDelProducto * 2) + (valorBaseDelProducto * porcentajeDeIncremento);
                }
                else if (mejorasEchas > 1)
                {
                    valorFinal = (valorFinal + valorBaseDelProducto) + (valorFinal * porcentajeDeIncremento);
                }
            }
        }
        else
        {
            print("No hay dinero");
        }

    }
    public string TextoValor
    {
        get
        {
            float numero = Mathf.Clamp(ValorObjeto, -999999999999999999, 999999999999999999);

            if (numero > 999999999999999999 || numero < -999999999999999999)
            {
                return (numero.ToString("0,,,,,.##Q"));
            }
            else if (numero > 999999999999999 || numero < -999999999999999)
            {
                return (numero.ToString("0,,,,,.##C"));
            }
            else if (numero > 999999999999 || numero < -999999999999)
            {
                return (numero.ToString("0,,,,.##T"));
            }
            else if (numero > 999999999 || numero < -999999999)
            {
                return (numero.ToString("0,,,.##B"));
            }
            else if (numero > 999999 || numero < -999999)
            {
                return (numero.ToString("0,,.##M"));
            }
            else if (numero > 999 || numero < -999)
            {
                return numero.ToString("0,.#K");
            }
            else if (numero <= 999 || numero >= -999)
            {
                return numero.ToString("0.0");
            }
            else
            {
                return numero.ToString();
            }
        }
    }
}
