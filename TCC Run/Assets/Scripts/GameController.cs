using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Enemy> Inimigos;

    // Use this for initialization
    void Start()
    {
        // Invoca o método SpawnEnemy a cada 5 segundos.
        Invoke("SpawnEnemy", 5.0f);
    }

    /// <summary>
    /// Instancia um inimigo em uma posição aleatória.
    /// </summary>
    private void SpawnEnemy()
    {
        System.Random rand = new System.Random();
        int posicao = rand.Next(Inimigos.Count);
        double altura = (rand.NextDouble() * 5) - 2.5;

        Instantiate(Inimigos[posicao], new Vector3(15, float.Parse(altura.ToString()), 0), Quaternion.identity);
    }
}
