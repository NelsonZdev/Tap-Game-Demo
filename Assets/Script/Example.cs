using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Example : MonoBehaviour
{
    public string dinero;
    public int numberOfSides;
    public float polygonRadius;
    public Vector2 polygonCenter;

    private int ayuda = 1;
    void Start()
    {
    }
    void Update()
    {

    }

    /*public string TextoValor
    {
        get
        {
            float numero = Mathf.Clamp(dinero = Convert.ToSingle(), -999999999999999999, 999999999999999999);

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
        set
        {
            
        }
    }*/
    /*
    // Dibuje un polígono en el plano XY con una posición específica, número de lados 
    // y radio. 
    void DebugDrawPolygon(Vector2 center, float radius, int numSides)
    {
        // La esquina que se usa para iniciar el polígono (paralela al eje X).
        Vector2 startCorner = new Vector2(radius, 0) + center;

        // El punto de esquina "anterior", inicializado en la esquina inicial.
        Vector2 previousCorner = startCorner;

        // Para cada esquina después de la esquina inicial ... 
        for (int i = 1; i < numSides; i++)
        {
            // Calcule el ángulo de la esquina en radianes. 
            float cornerAngle = 2f * Mathf.PI / (float)numSides * i;

            // Obtener las coordenadas X e Y del punto de la esquina.
            Vector2 currentCorner = new Vector2(Mathf.Cos(cornerAngle) * radius, Mathf.Sin(cornerAngle) * radius) + center;

            // Dibuja un lado del polígono conectando la esquina actual a la anterior.
            Debug.DrawLine(currentCorner, previousCorner);

            // Habiendo usado la esquina actual, ahora se convierte en la esquina anterior. .
            previousCorner = currentCorner;
        }

        // Dibuja el lado final conectando la última esquina a la esquina inicial.
        Debug.DrawLine(startCorner, previousCorner);
    }
    */
}
