using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toques : MonoBehaviour
{
    public static int cont;
    public Button toques;

    public static float dineroXSegundo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Aumento());
        toques.onClick.AddListener(Entrada);
    }
    // Update is called once per frame
    void Update()
    {
    }
    void Entrada(){
        dineroXSegundo += Dinero._ValorArboles;
        cont += 1;
    }
    IEnumerator Aumento()
    {
        while (true)
        {
            if (cont < -10)
            {
                cont += 1;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
