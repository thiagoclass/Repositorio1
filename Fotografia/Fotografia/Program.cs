using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Fotografia
{
    class Program
    {
        static void Main(string[] args)
        {
            String usuario;
            Menu:
            Console.WriteLine("Qual seu Nome?");
            String Nome = Console.ReadLine();

            SqlConnection sqlca = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\thiag\\OneDrive\\Documentos\\Visual Studio 2017\\Projetos\\Fotografia\\Fotografia\\BdFoto.mdf;Integrated Security=True");
            SqlCommand codca;
            SqlDataReader sqrca;
            sqlca.Open();
            codca = new SqlCommand("Select id,nome from Caloteiros where nome = '" + Nome + "'", sqlca);
            sqrca = codca.ExecuteReader();
            if (sqrca.HasRows)
            {
                usuario = "3";

            }
            else
            {


             

                Associado:
                Console.WriteLine("Você é associado? 1-S/2-N");
                usuario = Console.ReadLine();
                if (usuario != "1" & usuario != "2")
                {
                    Console.WriteLine("Escolher entre 1 e 2!");
                    goto Associado;
                }
            }

            sqlca.Close();

            SqlConnection sql = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\thiag\\OneDrive\\Documentos\\Visual Studio 2017\\Projetos\\Fotografia\\Fotografia\\BdFoto.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cod;
            SqlDataReader sqr;
            
            sql.Open();
            cod = new SqlCommand("Select id,nome from Estudio", sql);
            sqr = cod.ExecuteReader();

            Console.WriteLine("\n Selecione o tipo de Ensaio: \n");
            if (sqr.HasRows)
            {
                while (sqr.Read())
                {
                    Console.WriteLine("{0}\t{1}", 
                        sqr.GetInt32(0) + " - ",
                        sqr.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("\n Não possui Tipo de Ensaio Disponível. \n");
            }
            sql.Close();
           
           String Tipo = Console.ReadKey().KeyChar.ToString();

           
            FabricaEnsaio Fabrica = new FabricaEnsaio();
            Ensaio Ens;
            Ens = Fabrica.PegarEnsaio(Tipo);
            if (Ens == null)
            {
                Console.WriteLine("\n Não foi encontrado tipo de Ensaio para o Código. \n");

            }
            else
            {
                Ens.Agendar(Convert.ToInt32(usuario), Convert.ToInt32(Tipo));
            }
            goto Menu;
        }
    }
}
