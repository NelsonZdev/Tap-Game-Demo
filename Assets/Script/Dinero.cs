using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dinero : MonoBehaviour
{

    public float numeroArboles = 0;
    public float valorArboles;

    public static float dineroTotal = 0;
    public static float _ValorArboles;
    private float valorBaseArboles;

    // Start is called before the first frame update
    void Awake()
    {
        valorBaseArboles = valorArboles;
        _ValorArboles = valorArboles;
    }
    void Start()
    {
        StartCoroutine(Contador(1));
    }

    // Update is called once per frame
    void Update()
    {
        _ValorArboles = valorArboles;
        numeroArboles = Toques.cont;
    }

    public static string TextoNumero
    {
        get
        {
            float numero = Mathf.Clamp(dineroTotal, -999999999999999999, 999999999999999999);

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
    public void MejoraArboles()
    {
        valorArboles += valorArboles;
    }

    IEnumerator Contador(float segundos)
    {
        while (true)
        {
            dineroTotal += (valorArboles * numeroArboles);
            yield return new WaitForSeconds(segundos);
        }
    }
}
