using Enums;
using UnityEngine;

namespace Classes
{
    [System.Serializable]
    public class Movimentacao
    {
        #region Contrutores
        public Movimentacao(GameObject item)
        {
            Item = item;
        }

        public Movimentacao(GameObject item, EstiloCombate estiloCombate)
        {
            Item = item;
            EstiloCombate = estiloCombate;
        }
        #endregion

        private float randomVertical;
        private Vector2 posicaoFixa;

        [HideInInspector]
        public GameObject Item;

        [Tooltip("Dificuldade desse estilo de combate.")]
        public Dificuldade Dificuldade = Dificuldade.Facil;
        [Tooltip("Estilo de movimentação que o item assumira ao se mover na tela.")]
        public EstiloCombate EstiloCombate = EstiloCombate.Padrao;
        [Tooltip("Velocidade de movimento do objeto.")]
        [Range(5, 30)]
        public float Velocidade = 5;

        [Space]
        [Range(0, 30)]
        public float VelocidadeRotacaoHorizontal;
        [Range(0, 30)]
        public float VelocidadeRotacaoVertical;
        [Tooltip("Altura que o objeto irá flutuar.")]
        public float Alcance;

        public void InicializarMovimentacao()
        {
            Item.GetComponent<Rigidbody2D>().velocity = new Vector2(Velocidade * -1, 0);
            randomVertical = Random.value * 10;
            posicaoFixa = Item.transform.position;
        }

        /// <summary>
        /// Movimenta o objeto com base no estilo de combate escolhido.
        /// </summary>
        public void Mover()
        {
            

            switch (EstiloCombate)
            {
                case EstiloCombate.Circular:
                    Item.transform.position = new Vector2(Item.transform.position.x,
                                                          posicaoFixa.y + Mathf.Cos((randomVertical + Time.time) * VelocidadeRotacaoVertical) * Alcance);
                    break;
                case EstiloCombate.Guiado:
                    break;
                default:
                    break;
            }
        }
    }
}
