using Classes;
using Enums;
using UnityEngine;

public class Item : MonoBehaviour
{
    public TipoItem Tipo;
    
    public double ValorPontuacao;

    [Space]
    [Tooltip("Lista com todos os estilos de movimentação dos obstáculos.\nCaso não tenha nenhum estilo de combate configurado, é executado o modo padrão.")]
    public Movimentacao[] ModosDeCombate;

    private Vector3 _posicaoInicial;
    /// <summary>
    /// Modo de combate escolhido.
    /// </summary>
    private int _escolhido;

    private void Start()
    {
        // Caso não contenha nenhum estilo definido, um estilo padrão é adicionado.
        if (ModosDeCombate.Length == 0)
            ModosDeCombate = new Movimentacao[] { new Movimentacao(this.gameObject, EstiloCombate.Padrao) };
        else
            foreach (var combate in ModosDeCombate)
            {
                combate.Item = this.gameObject;
            }

        _escolhido = Random.Range(0, ModosDeCombate.Length);
        ModosDeCombate[_escolhido].InicializarMovimentacao();
    }

    private void Update()
    {
        ModosDeCombate[_escolhido].Mover();
    }

    private void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.gameObject.CompareTag("AreaDeJogo"))
        {
            Destroy(this.gameObject);
        }
    }

}
