using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string Nombre; //Almacena el nombre del audio a controlar
    public AudioClip clip; //Instancia de los audios
    // Limita los datos a un rango preestablecido entre (Valor Minimo , Valor Maximo)
    [Range(0f,1f)]public float volumen = 1f; // Almacena los datos de "Volume";
    public bool mute;
    [Range(-3f,3f)]public float tono = 1f;  //Almacena los datos de "Pitch"
    [Header("256 = Min 0 = Max")]
    [Header("Esta opcion permite establecer la importancia de un audio en la escena")]
    [Range(0,256)]public int prioridad = 128; //  Almacena el dato de "Loop"  
    [Header("Esta opcion permite que el audio se repita infinitamente")]
    public bool repetir; //  Almacena el dato de "Loop"   
    [HideInInspector] // Oculta el siguiente valor para que no se vea en el inspector
    public AudioSource source; // Almacena el audio que reproducira la escena


}
