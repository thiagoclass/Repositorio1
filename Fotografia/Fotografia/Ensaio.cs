using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Fotografia
{
    public abstract class Ensaio
    {
        public abstract bool SelecionarEndereco(int usuario,int TipoEnsaio);
        public abstract bool SelecionarTema(int usuario, int TipoEnsaio);
        public abstract bool SelecionarDataEHora(int usuario, int TipoEnsaio);
        //Template Method
        public void Agendar(int usuario, int TipoEnsaio) {
            bool Erro;
            Erro = SelecionarEndereco(usuario, TipoEnsaio);
            if (Erro == false)
            {
                return;
            }
            Erro = SelecionarTema(usuario, TipoEnsaio);
            if (Erro == false)
            {
                return;
            }
            Erro = SelecionarDataEHora(usuario, TipoEnsaio);
            if (Erro == false)
            {
                return;
            }
            Console.WriteLine("Ensaio Agendado com Sucesso!");
            Console.ReadKey();

        }

        public abstract SqlDataReader ConsultaEndereço(int usuario,int tipoEnsaio);
        public abstract SqlDataReader ConsultaTema(int usuario, int tipoEnsaio);
        public abstract SqlDataReader ConsultaDataHora(int usuario, int tipoEnsaio);

    }
}
