using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    float axis;
    float agachar;
    BoxCollider2D boxCollider2D;

    public float force;

    //Velocidade do personagem
    public float velocidade;

    public Text GameOver;
    public Text Nota;
    public Text Tempo;

    private float _nota;
    private bool _taNoChao;
    private float _tempoInicio;

    public GameController gameController;

    // Use this for initialization
    void Start()
    {
        //Inicializamos o Componente Animator para podermos trabalhar com os parametros que criamos.
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        GameOver.enabled = false;
        _nota = 7.0f;
        Nota.text = "Nota: " + String.Format("{0:#,##0.0}", _nota);
        _taNoChao = true;
        _tempoInicio = Time.time;
        print(_tempoInicio);
    }

    private string ConvertTempo(float segundos)
    {
        int minutos;
        string s_minutos, s_segundos;

        minutos = (int)(segundos / 60);
        s_minutos = minutos.ToString();

        segundos = (int)segundos - (minutos * 60);
        s_segundos = segundos.ToString();

        return s_minutos.PadLeft(2, '0') + ":" + s_segundos.PadLeft(2, '0');
    }

    // Executado em sincronismo com a fisica do jogo.
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        axis = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && _taNoChao == true && agachar >= 0)
        {
            rb.AddForce(new Vector2(0, force));
        }

        agachar = Input.GetAxis("Vertical");

        if (agachar < 0)
        {
            animator.SetBool("Academico", true);
            boxCollider2D.offset = new Vector2(-0.01722497f, 0.0140816f);
            boxCollider2D.size = new Vector2(0.3866502f, 0.9360656f);
        }
        else
        {
            animator.SetBool("Academico", false);
            boxCollider2D.offset = new Vector2(-0.01722497f, -0.003445029f);
            boxCollider2D.size = new Vector2(0.3866502f, 1.181442f);
        }

        rb.AddForce(new Vector2(axis * velocidade, 0));

        if (!gameController.reprovado.activeSelf)
            Tempo.text = ConvertTempo(Time.time - _tempoInicio);
        

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

        AplicaPontos(collision.gameObject);

        Destroy(collision.gameObject);

        if (_nota < 4)
        {
            GameOver.enabled = true;
            GameOver.text = "Deu ruim";
            gameController.GameOver();
        }
    }

    private void AplicaPontos(GameObject gameObject)
    {
        Item item = gameObject.GetComponent<Item>();


        if (gameObject.CompareTag("Enemy"))
        {
            _nota -= item.ValorPontuacao;
        }
        else if (gameObject.CompareTag("Ally"))
        {
            _nota += item.ValorPontuacao;
        }

        if (_nota > 10)
            _nota = 10;

        Nota.text = "Nota: " + String.Format("{0:#,##0.0}", _nota);
    }
}
