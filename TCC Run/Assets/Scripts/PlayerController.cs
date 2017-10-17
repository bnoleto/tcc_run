using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    float axis;

    public float force;

    //Velocidade do personagem
    public float velocidade;

    public Text GameOver;
    public Text Nota;
    public Text Tempo;

    private float _nota;
    private bool _taNoChao;

    // Use this for initialization
    void Start()
    {
        //Inicializamos o Componente Animator para podermos trabalhar com os parametros que criamos.
        animator = GetComponent<Animator>();
        GameOver.enabled = false;
        _nota = 7.0f;
        Nota.text = "Nota: " + String.Format("{0:#,##0.0}", _nota);
        _taNoChao = true;

    }

    private string ConvertTempo(float segundos)
    {
        int minutos;
        string s_minutos, s_segundos;

        minutos = (int)(segundos / 60);
        s_minutos = minutos.ToString();

        segundos = (int)Time.time - (minutos * 60);
        s_segundos = segundos.ToString();



        return s_minutos.PadLeft(2, '0') + ":" + s_segundos.PadLeft(2, '0');
    }

    // Executado em sincronismo com a fisica do jogo.
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        axis = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && _taNoChao == true)
        {
            rb.AddForce(new Vector2(0, force));
        }

        rb.AddForce(new Vector2(axis * velocidade, 0));

        Tempo.text = ConvertTempo(Time.time);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            _taNoChao = false;
        }
        //print(_taNoChao);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chao")
        {
            _taNoChao = true;
        }

        //print(_taNoChao);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            RemovePontos(collision.gameObject);

            Destroy(collision.gameObject);

            if (_nota < 4)
            {
                GameOver.enabled = true;
                GameOver.text = "Deu ruim";
            }
        }
    }

    private void RemovePontos(GameObject gameObject)
    {
        float razao_diminuicao = 0.5f;

        if (_nota >= razao_diminuicao)
        {
            _nota -= razao_diminuicao;
        }
        Nota.text = "Nota: " + String.Format("{0:#,##0.0}", _nota);
    }
}
