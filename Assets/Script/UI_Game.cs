using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Game : MonoBehaviour
{
    public Button botonTienda,botonMenu,botonOpciones,botonCreditos,botonSalir,botonMute;
    public Button botonDespausaTienda, botonDespausaMenu;
    public Text textoDinero,textoDineroXSegundos,numeroArboles;
    public GameObject panelTienda, panelMenu,panelCreditos,panelOpciones;
    public Slider barraEstadoMundo,barraAudio;


    public static float _MaxArboles;

    void Awake()
    {
    }
    void Start()
    {
        barraEstadoMundo.maxValue = _MaxArboles;
        botonTienda.onClick.AddListener(Tienda);
        botonMenu.onClick.AddListener(Menu);
        botonDespausaMenu.onClick.AddListener(Despausa);
        botonDespausaTienda.onClick.AddListener(Despausa);
        botonOpciones.onClick.AddListener(Opciones);
        botonCreditos.onClick.AddListener(Creditos);
        botonMute.onClick.AddListener(Mute);
        botonSalir.onClick.AddListener(ExitGame);
        panelTienda.SetActive(false);
        panelMenu.SetActive(false);
        panelOpciones.SetActive(false);
        panelCreditos.SetActive(true);
        botonOpciones.gameObject.SetActive(true);
        botonCreditos.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        barraEstadoMundo.value = Mathf.Clamp(Toques.cont,0,1000);
        textoDinero.text = Dinero.TextoNumero;
        textoDineroXSegundos.text = TextoNumero + " /Seg";
        numeroArboles.text = Toques.cont.ToString();
        AudioManager._VolumenAmbiente = barraAudio.value;
    }
    void Tienda()
    {
        panelTienda.SetActive(true);
        panelMenu.SetActive(false);

    }
    void Opciones()
    {
        botonOpciones.gameObject.SetActive(false);
        botonCreditos.gameObject.SetActive(true);
        panelOpciones.SetActive(true);
        panelCreditos.SetActive(false);

    }
    void Creditos()
    {
        botonCreditos.gameObject.SetActive(false);
        botonOpciones.gameObject.SetActive(true);
        panelOpciones.SetActive(false);
        panelCreditos.SetActive(true);

    }
    void Menu()
    {
        panelTienda.SetActive(false);
        panelMenu.SetActive(true);
    }
    void Despausa()
    {
        panelTienda.SetActive(false);
        panelMenu.SetActive(false);
    }
    public string TextoNumero
    {
        get
        {
            float numero = Mathf.Clamp(Toques.dineroXSegundo, -999999999999999999, 999999999999999999);

            if (numero > 999999999999 || numero < -999999999999)
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
    public void Mute()
    {
        AudioManager._MuteSonidos =! AudioManager._MuteSonidos;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
