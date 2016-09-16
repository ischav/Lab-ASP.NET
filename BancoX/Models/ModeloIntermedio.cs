using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BancoX.Models;

namespace BancoX.Models
{
    public class ModeloIntermedio
    {
        public cliente ModeloCliente { set; get; }
        public telefono ModeloTelf1 { set; get; }
        public telefono ModeloTelf2 { set; get; }
        public cuenta ModeloCuenta1 { set; get; }
        public cuenta ModeloCuenta2 { set; get; }
        public cuenta ModeloCuenta3 { set; get; }
        public List<cliente> listaPersonas = new List<cliente>();
        public List<telefono> listaNumeros = new List<telefono>();
        public List<cuenta> listaCuentas = new List<cuenta>();
    }
}