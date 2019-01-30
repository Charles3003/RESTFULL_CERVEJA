using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_RESTFULL_NEGOCIO.Negocio
{
    public class Autenticar_Usuario_NG
    {
    }
    public class Autenticar_Usuario_Grid_BD
    {
        public int Codigo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool E_Distribuidora { get; set; }
        public string Nome_Razao_Social { get; set; }
        public byte[] Imagem { get; set; }
        public short? Codigo_Perfil { get; set; }
    }
}


