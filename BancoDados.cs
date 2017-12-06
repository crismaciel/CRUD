using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExemploCRUD
{
    public class BancoDados
    {
        SqlConnection cn;

        SqlCommand comandos;
        SqlDataReader rd;

        public bool Adicionar (Categoria cat)
        {
            bool rs = false;
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlespress;Initial Catalog=Papelaria";
                cn.Open(); //abrindo o banco de dados
                comandos = new SqlCommand(); //comandos =>objeto
                comandos.Connection = cn; //estabelece conexao entre os comandos e o banco de dados

                comandos.CommandType = CommandType.Text; //tipo de comando q sera executado

                comandos.CommandText  = "insert into categoria(titulo) values(@vt)";

                comandos.Parameters.AddWithValue("@vt",cat.Titulo);

                int r = comandos.ExecuteNonQuery();

                if (r > 0)
                    rs = true;
                    comandos.Parameters.Clear();
            }

            catch(SqlException se)
            {
                throw new Exception("Erro ao tentar cadastrar. " + se.Message);
            }

            catch(Exception ex)
            {
                throw new Exception ("Erro inesperado. " + ex.Message);
            }

            finally
            {
                cn.Close();
            }

            return rs;
        } 


        public bool Atualizar (Categoria cat)
        {
            bool rs = false;
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlespress;Initial Catalog=Papelaria";
                cn.Open(); //abrindo o banco de dados
                comandos = new SqlCommand(); //comandos =>objeto
                comandos.Connection = cn; //estabelece conexao entre os comandos e o banco de dados

                comandos.CommandType = CommandType.Text; //tipo de comando q sera executado

                comandos.CommandText  = "update categoria set titulo=@vt where idcategoria = @vi";

                comandos.Parameters.AddWithValue("@vt",cat.Titulo);
                comandos.Parameters.AddWithValue("@vi",cat.IdCategoria);

                int r = comandos.ExecuteNonQuery();

                if (r > 0)
                    rs = true;
                    comandos.Parameters.Clear();
            }

            catch(SqlException se)
            {
                throw new Exception("Erro ao tentar atualizar. " + se.Message);
            }

            catch(Exception ex)
            {
                throw new Exception ("Erro inesperado. " + ex.Message);
            }

            finally
            {
                cn.Close();
            }

            return rs;
        } 

    
        public bool Apagar (Categoria cat)
        {
        bool rs = false;
        try
        {
        cn = new SqlConnection();
        cn.ConnectionString = @"Data Source = .\sqlespress;Initial Catalog=Papelaria";
        cn.Open(); //abrindo o banco de dados
        comandos = new SqlCommand(); //comandos =>objeto
        comandos.Connection = cn; //estabelece conexao entre os comandos e o banco de dados

        comandos.CommandType = CommandType.Text; //tipo de comando q sera executado

        comandos.CommandText  = "detele categoria set titulo=@vt where idcategoria = @vi";

        comandos.Parameters.AddWithValue("@vi",cat.IdCategoria);

        int r = comandos.ExecuteNonQuery();

        if (r > 0)
            rs = true;
            comandos.Parameters.Clear();
        }

        catch(SqlException se)
        {
            throw new Exception("Erro ao tentar atualizar. " + se.Message);
        }

        catch(Exception ex)
        {
            throw new Exception ("Erro inesperado. " + ex.Message);
        }

        finally
        {
            cn.Close();
        }

        return rs;
        } 
        public List<Categoria> ListarCategorias (string titulo)
        {
            List<Categoria> lista = new List<Categoria>();

            
        

            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlespress;Initial Catalog=Papelaria";
                cn.Open(); //abrindo o banco de dados
                comandos = new SqlCommand(); //comandos =>objeto
                comandos.Connection = cn; //estabelece conexao entre os comandos e o banco de dados
                comandos.CommandType = CommandType.Text; //tipo de comando q sera executado
                comandos.CommandText  = "Select *from categoria where idcategoria=@vi";
                comandos.Parameters.AddWithValue("@vi",titulo);
                rd = comandos.ExecuteReader();

                while(rd.Read())
                {
                    Categoria ct = new Categoria()
                    {
                        IdCategoria=rd.GetInt32(0), Titulo = rd.GetString(1)
                    };
                    lista.Add(ct);
                }
                comandos.Parameters.Clear();
            }
            catch(SqlException se)
            {
                throw new Exception("Erro ao tentar listar. "+se.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro insperado. "+ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }
          
        public bool AdicionarCliente(Cliente cliente)
        {
            bool rs = false;
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress;initial catalog=Papelaria;user id=sa; password=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.StoredProcedure;
                comandos.CommandText = "sp_CadCliente";

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.VarChar,50);
                pnome.Value = cliente.nomeCliente;
                comandos.Parameters.Add(pnome);

                SqlParameter pemail = new SqlParameter("@email",SqlDbType.VarChar,100);
                pemail.Value = cliente.Email;
                comandos.Parameters.Add(pemail);

                SqlParameter pcpf = new SqlParameter("@cpf",SqlDbType.VarChar, 20);
                pcpf.Value = cliente.CPF;
                comandos.Parameters.Add(pcpf);

                int r = comandos.ExecuteNonQuery();

                if (r > 0)
                rs = true;

                comandos.Parameters.Clear();

                catch(SqlException se)
                {
                    throw new Exception("Erro ao tentar inserir os dados "+ se.Message);
                }

                catch(Exception ex)
                {
                    throw new Exception ("Erro insperado "+ex.Message);
                }

            }
        }
    }       
}