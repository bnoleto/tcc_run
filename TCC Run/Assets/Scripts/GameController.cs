using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Enemy> Inimigos;

    private float contador;

    // Use this for initialization
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;

        if (contador > 5)
        {
            System.Random rand = new System.Random();
            int posicao = rand.Next(Inimigos.Count);
            double altura = (rand.NextDouble() * 5) - 2.5;

            Instantiate(Inimigos[posicao], new Vector3(15, float.Parse(altura.ToString()), 0), Quaternion.identity);

            contador = 0;
        }
    }
}
