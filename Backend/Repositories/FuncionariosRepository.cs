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
                            IdFuncionarios = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString(),

                            Sobrenome = rdr["Sobrenome"].ToString()



                        };


                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }


        public void Cadastrar(FuncionariosDomain funcionario)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                con.Open();


                string queryInsert = "INSERT INTO Funcionarios (Nome,Sobrenome) VALUES (@Nome,@Sobrenome)";


                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);

                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);





                cmd.ExecuteNonQuery();
            }
        }

        public FuncionariosDomain BuscarPorId(int id)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string querySelectById = "SELECT IdFuncionarios, Nome ,Sobrenome FROM Funcionarios WHERE IdFuncionarios = @ID";


                con.Open();


                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);


                    rdr = cmd.ExecuteReader();


                    if (rdr.Read())
                    {

                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionarios = Convert.ToInt32(rdr["IdFuncionarios"]),

                            Nome = rdr["Nome"].ToString(),


                            Sobrenome = rdr["Sobrenome"].ToString()
                            
                        };

                        return funcionario;
                    }

                    return null;
                }
            }
        }


        public void AtualizarIdCorpo(FuncionariosDomain funcionario)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome , Sobrenome = @Sobrenome WHERE IdFuncionarios = @ID";


                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    cmd.Parameters.AddWithValue("@ID", funcionario.IdFuncionarios);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);


                    con.Open();


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionarios = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id,FuncionariosDomain funcionario)
        {
            
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
               
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome , Sobrenome = @Sobrenome WHERE IdFuncionarios = @ID";

                
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                   
                    con.Open();

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

