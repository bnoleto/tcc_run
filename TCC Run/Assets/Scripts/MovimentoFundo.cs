using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoFundo : MonoBehaviour
{
    public float velocidade = 10.0f;
    public Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * velocidade;
        rend.material.mainTextureOffset = new Vector2(offset, 0);
        //print(offset);
    }

}
