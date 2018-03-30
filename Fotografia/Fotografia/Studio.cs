using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Fotografia
{
    class Studio:Ensaio
    {   //proxy
        public override SqlDataReader ConsultaDataHora(int usuario, int tipoEnsaio)
        {
            if (usuario == 3)
            {
                return null;
            }
            ControleConsultaBase csdh = new ControleConsultaBase();
            SqlDataReader sdrStuAgenda = csdh.ConsultaDataHora(usuario, tipoEnsaio);
            return sdrStuAgenda;
        }
        //proxy
        public override SqlDataReader ConsultaEndereço(int usuario, int tipoEnsaio)
        {
            if (usuario == 3)
            {
                return null;
            }
            ControleConsultaBase cse = new ControleConsultaBase();
            SqlDataReader sdrStuEnd = cse.ConsultaEndereço(usuario, tipoEnsaio);
            return sdrStuEnd;
        }
        //proxy
        public override SqlDataReader ConsultaTema(int usuario, int tipoEnsaio)
        {
            if (usuario == 3)
            {
                return null;
            }
            ControleConsultaBase cst = new ControleConsultaBase();
            SqlDataReader sdrStuTema = cst.ConsultaTema(usuario, tipoEnsaio);
            return sdrStuTema;
        }

        public override bool SelecionarDataEHora(int usuario,int TipoEnsaio)
        {
            SqlDataReader sdrStuAgenda = ConsultaDataHora(usuario, TipoEnsaio);
            if (sdrStuAgenda != null)
            {
                if (sdrStuAgenda.HasRows)
            {
                Console.WriteLine("\n Selecione o Horario Disponível: \n");

                while (sdrStuAgenda.Read())
                {
                    Console.WriteLine(
                        sdrStuAgenda.GetInt32(0) + " - " +
                        sdrStuAgenda.GetDateTime(1)
                       );
                }
                String Tipo = Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine(" Não possui Agenda Disponível.");
            }
            return false;
            }
            else
            {
                Console.WriteLine("Não possui Agenda Disponível.");
                return false;
            }

        }

        public override bool SelecionarEndereco(int usuario,int TipoEnsaio)
        {
            SqlDataReader sdrStuEnd = ConsultaEndereço(usuario, TipoEnsaio);

            if (sdrStuEnd != null)
            {
                if (sdrStuEnd.HasRows)
             {
                Console.WriteLine("\n Selecione o Endereço Disponível para este Tipo de Ensaio: \n");
                while (sdrStuEnd.Read())
                {
                    Console.WriteLine(
                        sdrStuEnd.GetInt32(0) + " - " +
                        sdrStuEnd.GetString(1) + ", " +
                        sdrStuEnd.GetString(2) + ", " +
                        sdrStuEnd.GetInt32(3)
                       );
                }
                String Tipo = Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine(" Não possui endereço Disponível.");
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
            SqlDataReader sdrStuTema = ConsultaTema(usuario,TipoEnsaio);

            if (sdrStuTema != null)
            {

                if (sdrStuTema.HasRows)
            {
                Console.WriteLine("\n Selecione o Tema Disponível para este Tipo de Ensaio: \n");
                while (sdrStuTema.Read())
                {
                    Console.WriteLine(
                        sdrStuTema.GetInt32(0) + " - " +
                        sdrStuTema.GetString(1)
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
