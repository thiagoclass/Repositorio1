using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fotografia
{
    public class FabricaEnsaio
    {
        //factory Method
        public Ensaio PegarEnsaio(String Tipo)
        {
            switch (Tipo)
            {
                case "1":
                    return new HomeStudio();
                case "2":
                    return new Studio();
                case "3":
                    return new EnsaioExterno();
                
            }
            return null;
        }
    }
}
