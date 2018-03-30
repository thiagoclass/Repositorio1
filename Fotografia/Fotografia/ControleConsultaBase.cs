using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fotografia
{
    class ControleConsultaBase : Ensaio
    {   //Proxy - Real Subject
        public override SqlDataReader ConsultaDataHora(int usuario, int tipoEnsaio)
        {
            SqlConnection ConAgenda = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\thiag\\OneDrive\\Documentos\\Visual Studio 2017\\Projetos\\Fotografia\\Fotografia\\BdFoto.mdf;Integrated Security=True");
            SqlCommand codAgenda;
            SqlDataReader sdrAgenda;
            ConAgenda.Open();
            if (usuario == 1)
            {
                codAgenda = new SqlCommand("Select id,DataDisponivel " +
                "                       From Agenda as e", ConAgenda);
            }
            else
            {
                codAgenda = new SqlCommand("Select id,DataDisponivel " +
                "                       From Agenda as e" +
            "                       where isnull(ensaio,0) = 0", ConAgenda);
            }
                
            sdrAgenda = codAgenda.ExecuteReader();
            
            return sdrAgenda;
        }

        //Proxy - Real Subject
        public override SqlDataReader ConsultaEndereço(int usuario, int tipoEnsaio)
        {
            SqlConnection ConEnd = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\thiag\\OneDrive\\Documentos\\Visual Studio 2017\\Projetos\\Fotografia\\Fotografia\\BdFoto.mdf;Integrated Security=True");
            SqlCommand codEnd;
            SqlDataReader sdrEnd;
            ConEnd.Open();
            if (usuario == 1)
            {
                codEnd = new SqlCommand("Select distinct e.id,e.nome,e.logradouro,e.numero " +
"                       From Endereco as e", ConEnd);
            }
            else
            {
                codEnd = new SqlCommand("Select distinct e.id,e.nome,e.logradouro,e.numero " +
            "                       From Endereco as e" +
        "                       join Ensaio as es" +
        "                       on e.id = es.endereco" +
        "                       where es.studio = " + tipoEnsaio, ConEnd);

            }
            sdrEnd = codEnd.ExecuteReader();
            
            return sdrEnd;
        }
        //Proxy - Real Subject
        public override SqlDataReader ConsultaTema(int usuario, int tipoEnsaio)
        {
            SqlConnection ConTema = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\thiag\\OneDrive\\Documentos\\Visual Studio 2017\\Projetos\\Fotografia\\Fotografia\\BdFoto.mdf;Integrated Security=True");
            SqlCommand codTema;
            SqlDataReader sdrTema;
            ConTema.Open();
            if (usuario == 1)
            {
                codTema = new SqlCommand("Select distinct e.id,e.nome " +
                    "                       From Tema as e", ConTema);

            }
            else
            {
                codTema = new SqlCommand("Select distinct e.id,e.nome " +
                "                       From Tema as e" +
            "                       join Ensaio as es" +
            "                       on e.id = es.tema" +
            "                       where es.studio = " + tipoEnsaio, ConTema);

            }
            sdrTema = codTema.ExecuteReader();
            
            return sdrTema;
        }
        

        public override bool SelecionarDataEHora(int usuario, int TipoEnsaio)
        {
            throw new NotImplementedException();
        }

   
        public override bool SelecionarEndereco(int usuario, int TipoEnsaio)
        {
            throw new NotImplementedException();
        }
        
        public override bool SelecionarTema(int usuario, int TipoEnsaio)
        {
            throw new NotImplementedException();
        }
    }
}
