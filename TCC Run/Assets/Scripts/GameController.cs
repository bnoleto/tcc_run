using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Item> Inimigos;

    // Use this for initialization
    void Start()
    {
        // Invoca o método SpawnEnemy a cada 5 segundos.
        InvokeRepeating("SpawnEnemy", 5.0f, 5.0f);
    }

    /// <summary>
    /// Instancia um inimigo em uma posição aleatória.
    /// </summary>
    private void SpawnEnemy()
    {
        int posicao = Random.Range(0, Inimigos.Count);
        double altura = (Random.value * 5) - 2.5;

        Instantiate(Inimigos[posicao], new Vector3(15, float.Parse(altura.ToString()), 0), Quaternion.identity);
    }
}
