using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Fotografia
{
    class HomeStudio:Ensaio
    {   //proxy
        public override SqlDataReader ConsultaDataHora(int usuario, int tipoEnsaio)
        {
            if (usuario == 3)
            {
                return null;
            }
            ControleConsultaBase csdh = new ControleConsultaBase();
            SqlDataReader sdrHomStuAgenda = csdh.ConsultaDataHora(usuario, tipoEnsaio);
            return sdrHomStuAgenda;
        }
        //proxy
        public override SqlDataReader ConsultaEndereço(int usuario, int tipoEnsaio)
        {
            if (usuario == 3)
            {
                return null;
            }
            ControleConsultaBase cse = new ControleConsultaBase();
            SqlDataReader sdrHomStuEnd = cse.ConsultaEndereço(usuario, tipoEnsaio);
            return sdrHomStuEnd;
        }
        //proxy
        public override SqlDataReader ConsultaTema(int usuario, int tipoEnsaio)
        {
            if (usuario == 3)
            {
                return null;
            }
            ControleConsultaBase cst = new ControleConsultaBase();
            SqlDataReader sdrHomStuTema = cst.ConsultaTema(usuario, tipoEnsaio);
            return sdrHomStuTema;
        }
        public override bool SelecionarDataEHora(int usuario,int TipoEnsaio)
        {
            
            SqlDataReader sdrHomStuAgenda = ConsultaDataHora(usuario, TipoEnsaio);

            if (sdrHomStuAgenda != null)
            {
                if (sdrHomStuAgenda.HasRows)
            {
                Console.WriteLine("\n Selecione o Horario Disponível: \n");
                while (sdrHomStuAgenda.Read())
                {
                    Console.WriteLine(
                        sdrHomStuAgenda.GetInt32(0) + " - " +
                        sdrHomStuAgenda.GetDateTime(1)
                       );
                }
                String Tipo = Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("Não possui Agenda Disponível.");
            }
            return false;
            }
            else
            {
                Console.WriteLine(" Não possui Agenda Disponível.");
                return false;
            }

        }

        public override bool SelecionarEndereco(int usuario, int TipoEnsaio)
        {
            SqlDataReader sdrHomStuEnd = ConsultaEndereço(usuario, TipoEnsaio);

            if (sdrHomStuEnd != null)
            {

                if (sdrHomStuEnd.HasRows)
            {
                Console.WriteLine("\n Selecione o Endereço Disponível para este Tipo de Ensaio: \n");
                while (sdrHomStuEnd.Read())
                {
                    Console.WriteLine(
                        sdrHomStuEnd.GetInt32(0) + " - " +
                        sdrHomStuEnd.GetString(1) + ", " +
                        sdrHomStuEnd.GetString(2) + ", " +
                        sdrHomStuEnd.GetInt32(3)
                       );
                }
                String Tipo = Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("Não possui endereço Disponível.");
            }
            return false;
            }
            else
            {
                Console.WriteLine("Não possui endereço Disponível.");
                return false;
            }
        }

        public override bool SelecionarTema(int usuario, int TipoEnsaio)
        {
            SqlDataReader sdrHomStuTema = ConsultaTema(usuario, TipoEnsaio);

            if (sdrHomStuTema != null)
            {

                if (sdrHomStuTema.HasRows)
            {
                Console.WriteLine("\n Selecione o Tema Disponível para este Tipo de Ensaio: \n");
                while (sdrHomStuTema.Read())
                {
                    Console.WriteLine(
                        sdrHomStuTema.GetInt32(0) + " - " +
                        sdrHomStuTema.GetString(1)
                       );
                }
                String Tipo = Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine(" Não possui Tema Disponível.");
            }
            return false;
            }
            else
            {
                Console.WriteLine("Não possui Tema Disponível.");
                return false;
            }
        }
    }
}
