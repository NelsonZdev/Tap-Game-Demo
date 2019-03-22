using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EstadoMundo
{
    public SpriteRenderer[] spriteObjeto;
    public Sprite m0x100,m25x100,m50x100,m75x100;
}

public class SceneController : MonoBehaviour
{
    public float maxArboles = 1000;
    public EstadoMundo[] objetos;
    public Mundo mundo;
    public ParticleSystemRenderer nubes;
    public Material m0x100, m25x100, m50x100, m75x100;
    [Header("Arbol")]
    public SpriteRenderer renderArbol;
    public Sprite[] fases;


    private int mejorasArbol = 0;

    public enum Mundo
    {
        _0,_25,_50,_75
    }
    // Start is called before the first frame update
    void Awake()
    {
        UI_Game._MaxArboles = maxArboles;
    }
    void Start()
    {

    }
    float PorcentajeMundo
    {
        get
        {
            return (Toques.cont * 100) / maxArboles;
        }
    }
    float PorcentajeArbol
    {
        get
        {
            return (mejorasArbol * 100) / Tienda._MaxMejoras;
        }
    }
    // Update is called once per frame
    void Update()
    {
        EstadoToques();
        AsignacionDeSprites();
        EstadoArbol();
        nubes.material = NubeMaterial;
        mejorasArbol = Tienda._NumeroDeMejoras;
    }
    public void EstadoArbol()
    {
        renderArbol.sprite = fases[Mathf.Clamp(PorcentajeMejoras,0,fases.Length)];
    }
    int PorcentajeMejoras
    {
        get
        {
            if (PorcentajeArbol >= 98)
                return 7;
            if (PorcentajeArbol >= 84 && PorcentajeArbol < 98)
                return 6;
            if (PorcentajeArbol >= 70 && PorcentajeArbol < 84)
                return 5;
            if (PorcentajeArbol >= 56 && PorcentajeArbol < 70)
                return 4;
            if (PorcentajeArbol >= 42 && PorcentajeArbol < 56)
                return 3;
            if (PorcentajeArbol >= 28 && PorcentajeArbol < 42)
                return 2;
            if (PorcentajeArbol >= 14 && PorcentajeArbol < 28)
                return 1;
            if (PorcentajeArbol >= 0 && PorcentajeArbol < 14)
                return 0;
            else
                return -1;
        }
    }
    public void EstadoToques()
    {
        if (PorcentajeMundo >= 75)
            mundo = Mundo._75;
        if (PorcentajeMundo >= 50 && PorcentajeMundo < 75)
            mundo = Mundo._50;
        if (PorcentajeMundo >= 25 && PorcentajeMundo < 50)
            mundo = Mundo._25;
        if (PorcentajeMundo < 25)
            mundo = Mundo._0;
    }
    public Material NubeMaterial
    {
        get
        {
            if (mundo == Mundo._0)
            {
                return m0x100;
            }
            else if (mundo == Mundo._25)
            {
                return m25x100;
            }
            else if (mundo == Mundo._50)
            {
                return m50x100;
            }
            else if (mundo == Mundo._75)
            {
                return m75x100;
            }
            else
            {
                return m0x100;
            }
        }
    }
    void AsignacionDeSprites()
    {
        foreach (var objeto in objetos)
        {
            for (int i =0 ; i < objeto.spriteObjeto.Length;i++)
            {
                if (mundo == Mundo._0)
                {
                    objeto.spriteObjeto[i].sprite = objeto.m0x100;
                }
                else if (mundo == Mundo._25)
                {
                    objeto.spriteObjeto[i].sprite = objeto.m25x100;
                }
                else if (mundo == Mundo._50)
                {
                    objeto.spriteObjeto[i].sprite = objeto.m50x100;
                }
                else if (mundo == Mundo._75)
                {
                    objeto.spriteObjeto[i].sprite = objeto.m75x100;
                }
            }
        }
    }
    void SalirJuego()
    {
        Application.Quit();
    }

}
