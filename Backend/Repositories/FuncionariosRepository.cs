using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using T_Peoples.Domains;
using T_Peoples.Interfaces;

namespace T_Peoples.Repositories
{
    public class FuncionariosRepository : IFuncionario
    {
        private string StringConexao = "Data Source=DEV15\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132;";



        public List<FuncionariosDomain> Listar()
        {

            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string querySelectAll = "SELECT IdFuncionarios, Nome, Sobrenome from Funcionarios";


                con.Open();


                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {


                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString(),

                            Sobrenome = rdr["Sobrenome"].ToString()



                        };


                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

    }
 }

