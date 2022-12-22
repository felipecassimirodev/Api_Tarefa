using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassimiro.Dominio.Enum
{
    public enum Status
    {
        [Description("Não Iniciado")]
        NaoIniciado = 0,
        [Description("Em Andamento")]
        EmAndamento = 1,
        [Description("Aguardando Terceiro")]
        AguardandoTerceiro = 5,
        [Description("Cancelado")]
        Cancelado = 7,
        [Description("Concluído")]
        Concluido = 9
    }
}
