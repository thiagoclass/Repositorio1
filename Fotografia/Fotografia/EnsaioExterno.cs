using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Fotografia
{
    class EnsaioExterno : Ensaio
    {   //proxy
        public override SqlDataReader ConsultaDataHora(int usuario, int tipoEnsaio)
        {
            if (usuario ==3)
            {
                return null;
            }
            ControleConsultaBase csdh = new ControleConsultaBase();
            SqlDataReader sdrEnsExtAgenda = csdh.ConsultaDataHora(usuario, tipoEnsaio);
            return sdrEnsExtAgenda;
        }
        //proxy
        public override SqlDataReader ConsultaEndereço(int usuario, int tipoEnsaio)
        {
            if (usuario == 3)
            {
                return null;
            }
            ControleConsultaBase cse = new ControleConsultaBase();
            SqlDataReader sdrEnsExtEnd = cse.ConsultaEndereço(usuario,tipoEnsaio);
            return sdrEnsExtEnd;
        }
        //proxy
        public override SqlDataReader ConsultaTema(int usuario, int tipoEnsaio)
        {
            if (usuario == 3)
            {
                return null;
            }
            ControleConsultaBase cst = new ControleConsultaBase();
            SqlDataReader sdrEnsExtTema = cst.ConsultaTema(usuario, tipoEnsaio);
            return sdrEnsExtTema;
        }

        public override bool SelecionarDataEHora(int usuario, int TipoEnsaio)
        {
            SqlDataReader sdrEnsExtAgenda = ConsultaDataHora(usuario, TipoEnsaio);

            if (sdrEnsExtAgenda != null)
            {
                if (sdrEnsExtAgenda.HasRows)
                {
                    Console.WriteLine("\n Selecione o Horario Disponível: \n");
                    while (sdrEnsExtAgenda.Read())
                    {
                        Console.WriteLine(
                            sdrEnsExtAgenda.GetInt32(0) + " - " +
                            sdrEnsExtAgenda.GetDateTime(1)
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
                Console.WriteLine(" Não possui Agenda Disponível.");
                return false;
            }
        }

        public override bool SelecionarEndereco(int usuario,int TipoEnsaio)
        {
            SqlDataReader sdrEnsExtEnd = ConsultaEndereço(usuario, TipoEnsaio);

            if (sdrEnsExtEnd != null)
            {
                if (sdrEnsExtEnd.HasRows)
            {
                Console.WriteLine("\n Selecione o Endereço Disponível para este Tipo de Ensaio: \n");
                while (sdrEnsExtEnd.Read())
                {
                    Console.WriteLine(
                        sdrEnsExtEnd.GetInt32(0) + " - " +
                        sdrEnsExtEnd.GetString(1) + ", " +
                        sdrEnsExtEnd.GetString(2) + ", " +
                        sdrEnsExtEnd.GetInt32(3)
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
                Console.WriteLine(" Não possui endereço Disponível.");
                return false;
            }
}

        public override bool SelecionarTema(int usuario,int TipoEnsaio)
        {
            
            SqlDataReader sdrEnsExtTema;
            sdrEnsExtTema = ConsultaTema(usuario,TipoEnsaio);
            if (sdrEnsExtTema != null)
            {
                if (sdrEnsExtTema.HasRows)
            {
                Console.WriteLine("\n Selecione o Tema Disponível para este Tipo de Ensaio: \n");
                while (sdrEnsExtTema.Read())
                {
                    Console.WriteLine(
                        sdrEnsExtTema.GetInt32(0) + " - " +
                        sdrEnsExtTema.GetString(1)
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
                Console.WriteLine(" Não possui Tema Disponível.");
                return false;
            }
        }
    }
}
