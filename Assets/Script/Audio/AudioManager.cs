using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sonidos; // Matriz encargada de almacenar todos los audios del Juego

    [Range(0f,1f)]public static float _VolumenAmbiente;
    public static bool _MuteSonidos;

    void Awake()
    {
        foreach (Sound s in sonidos) // Funcion encargadda de buscar multiples datos en una Matriz
        {
            // Estos datos se compara con valores obtenidos de otro Script
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volumen;
            s.source.mute = s.mute;
            s.source.pitch = s.tono;
            s.source.priority = s.prioridad;
            s.source.loop = s.repetir;
            _MuteSonidos = s.mute;
            if (s.Nombre == "Ambiente")
            {
                _VolumenAmbiente = s.volumen;

            }
        }
    }
    void Start()
    {
        Play("Ambiente");
    }
    void Update()
    {
        foreach (Sound s in sonidos) // Funcion encargadda de buscar multiples datos en una Matriz
        {
            // Estos datos se compara con valores obtenidos de otro Script
            s.source.volume = s.volumen;
            s.source.pitch = s.tono;
            s.source.priority = s.prioridad;
            s.source.loop = s.repetir;
            s.source.mute = _MuteSonidos;
            if (s.Nombre == "Ambiente")
            {
                s.volumen = _VolumenAmbiente;
            }
        }
    }

    // Metodo encargado de iniciar un sonido segun el nombre del audio
    public void Play (string name)
    {
        Sound s = Array.Find(sonidos, sound => sound.Nombre == name ); // Busca en una matriz un nombre 
        if (s == null) // Cuando no se encuentra el dato
        {
            Debug.LogWarning("El sonido : " + name + " no se encuentra"); // Mensaje de Advertencia
            return; // Retorna la ejecucion del codigo
        }
        s.source.Play(); // Llama a la funcion "Play" almacenada en la matriz 
    }
}
