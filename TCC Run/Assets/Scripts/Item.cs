using Assets.Scripts.Enums;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Tooltip("Velocidade da animação.")]
    [Range(5, 30)]
    public float Velocidade;
    [Tooltip("Altura que o objeto irá flutuar.")]
    public float Alcance;
    [Tooltip("Indicará se é inimigo ou amigo")]
    public TipoItem tipo;
    [Tooltip("Valor que o item irá afetar a pontuação do jogador.")]
    [Range(0, 10)]
    public double valorPontuacao;

    private Vector3 _posicaoInicial;

    private void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.gameObject.CompareTag("AreaDeJogo"))
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Velocidade * -1, 0);
        //_posicaoInicial = transform.position;
    }

    private void Update()
    {
        if (Time.time > 150)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Cos(Time.time * 12) * 2.5f);
        }
        else if (Time.time > 120)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Cos(Time.time * 10) * 2.5f);
        }
        else if (Time.time > 90)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Cos(Time.time * 5) * 2.5f);
        }
        else if (Time.time > 60)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Cos(Time.time * 3) * 2.5f);
        }
        else if (Time.time > 30)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Cos(Time.time * 2) * 2.5f);
        }
    }

}
