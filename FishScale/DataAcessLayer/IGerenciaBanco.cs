using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishScale.DataAcessLayer
{
    interface IGerenciaBanco<Tentity> where Tentity : class
    {
        List<Tentity> Get(string sql);

        Tentity GetById(int id);

        void Cadastra(Tentity obj);

        void Atualiza(Tentity obj);

        void Exclui(int id);

    }
}
