using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Peoples.Domains;

namespace T_Peoples.Interfaces
{
    interface IFuncionario
    {
        List<FuncionariosDomain> Listar();

        void Cadastrar(FuncionariosDomain funcionario);

        FuncionariosDomain BuscarPorId(int id);

        void AtualizarIdCorpo(FuncionariosDomain funcionario);

        void Deletar(int id);

        void AtualizarIdUrl(int id, FuncionariosDomain funcionario);


    }

}
