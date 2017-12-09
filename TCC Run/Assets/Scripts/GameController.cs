using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public List<Item> Inimigos;

    public List<Item> Aliados;

    [Range(0, 100)]
    public float chanceAliado;

    public GameObject reprovado;

    // Use this for initialization
    void Start()
    {

        // Invoca o método SpawnEnemy a cada 5 segundos.
        InvokeRepeating("SpawnItem", 5.0f, 5.0f);
        reprovado.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && reprovado.activeSelf)
        {
            SceneManager.UnloadSceneAsync(1);
            SceneManager.LoadScene("menu_principal");
        }
    }

    /// <summary>
    /// Instancia um inimigo em uma posição aleatória.
    /// </summary>
    private void SpawnItem()
    {
        int bemOuMal = Random.Range(0, 100);
        double altura = (Random.value * 5) - 2.5;

        if (bemOuMal > chanceAliado)
        {
            int posicao = Random.Range(0, Inimigos.Count);

            Instantiate(Inimigos[posicao], new Vector3(15, float.Parse(altura.ToString()), 0), Quaternion.identity);
        }
        else
        {
            int posicao = Random.Range(0, Aliados.Count);
            int posicao2 = Random.Range(0, Inimigos.Count);

            double altura2 = (Random.value * 5) - 2.5;

            Instantiate(Aliados[posicao], new Vector3(15, float.Parse(altura.ToString()), 0), Quaternion.identity);
            Instantiate(Inimigos[posicao2], new Vector3(15, float.Parse(altura2.ToString()), 0), Quaternion.identity);
        }
    }

    public void GameOver()
    {
        CancelInvoke("SpawnItem");
        reprovado.SetActive(true);
        //Time.timeScale = 0;
    }
}
