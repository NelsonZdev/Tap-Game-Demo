using System.Collections;
using UnityEngine;

public class EstadosObjetos : MonoBehaviour
{
    public Sprite m0x100, m25x100, m50x100, m75x100;
    [HideInInspector]
    public SpriteRenderer localSprite;
    // Start is called before the first frame update
    void Start()
    {
        localSprite = GetComponent<SpriteRenderer>();
        localSprite.sprite = m0x100;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
