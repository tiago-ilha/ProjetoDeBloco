using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Avaliacao.Modelos.Avaliacoes.Dominio.Enums
{
    public class TipoSituacaoAvaliacaoEnum
    {
        public static TipoSituacaoAvaliacaoEnum Cadastrada = new TipoSituacaoAvaliacaoEnum(1, "Cadastrada");
        public static TipoSituacaoAvaliacaoEnum Enviada = new TipoSituacaoAvaliacaoEnum(2, "Enviada");
        public static TipoSituacaoAvaliacaoEnum Respondida = new TipoSituacaoAvaliacaoEnum(3, "Respondida");

        public int Valor { get; private set; }
        public string Descricao { get; private set; }

        public TipoSituacaoAvaliacaoEnum(int valor, string descricao)
        {
            Valor = valor;
            Descricao = descricao;
        }
    }
}
