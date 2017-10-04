using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Velocidade da animação.")]
    public float Velocidade;
    [Tooltip("Altura que o objeto irá flutuar.")]
    public float Alcance;
	[Tooltip("Indicará se é inimigo ou amigo")]
	public string tipo;

    private Vector3 _posicaoInicial;

	private void OnTriggerExit2D(Collider2D colisor){

		if (colisor.gameObject.CompareTag ("AreaDeJogo")) {
			Destroy (this.gameObject);
		}
		
	}

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Velocidade, 0);
        //_posicaoInicial = transform.position;
    }

    private void Update()
    {
        //transform.position = _posicaoInicial + new Vector3(0, (Mathf.Sin(Time.time * Velocidade) + 1) / 2, 0) * Alcance;
    }
		
}
