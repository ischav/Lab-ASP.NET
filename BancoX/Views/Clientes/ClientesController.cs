using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BancoX.Models;
using System.Net;

namespace BancoX.Views.Clientes
{
    public class ClientesController : Controller
    {
        Entities BD = new Entities();

        // GET: Clientes
        public ActionResult Index()
        {
            ModeloIntermedio modelo = new ModeloIntermedio();
            modelo.listaPersonas = BD.cliente.ToList();
            modelo.listaNumeros = BD.telefono.ToList();
            modelo.listaCuentas = BD.cuenta.ToList();
            return View(modelo);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloIntermedio modelo)
        {
            if (ModelState.IsValid)
            {
                BD.cliente.Add(modelo.ModeloCliente);
                BD.SaveChanges();
                if (modelo.ModeloTelf1.numero != null)
                {
                    modelo.ModeloTelf1.cedula = modelo.ModeloCliente.cedula;
                    BD.telefono.Add(modelo.ModeloTelf1);
                }
                if (modelo.ModeloTelf2.numero != null)
                {
                    modelo.ModeloTelf2.cedula = modelo.ModeloCliente.cedula;
                    BD.telefono.Add(modelo.ModeloTelf2);
                }
                if (modelo.ModeloCuenta1.numero != null)
                {
                    modelo.ModeloCuenta1.cedula = modelo.ModeloCliente.cedula;
                    BD.cuenta.Add(modelo.ModeloCuenta1);
                }
                if (modelo.ModeloCuenta2.numero != null)
                {
                    modelo.ModeloCuenta2.cedula = modelo.ModeloCliente.cedula;
                    BD.cuenta.Add(modelo.ModeloCuenta2);
                }
                if (modelo.ModeloCuenta3.numero != null)
                {
                    modelo.ModeloCuenta3.cedula = modelo.ModeloCliente.cedula;
                    BD.cuenta.Add(modelo.ModeloCuenta3);
                }
                BD.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Debe completar toda la información necesaria.");
                return View(modelo);
            }
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente c = BD.cliente.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            ModeloIntermedio modelo = new ModeloIntermedio();
            modelo.ModeloCliente = c;
            List<telefono> telefonos = new List<telefono>();
            telefonos = BD.telefono.Where(a => a.cedula == c.cedula).ToList();
            int countt = telefonos.Count();
            if (countt == 1)
            {
                modelo.ModeloTelf1 = telefonos.ElementAt(0);
            }
            else if (countt == 2)
            {
                modelo.ModeloTelf2 = telefonos.ElementAt(1);
            }

            List<cuenta> cuentas = new List<cuenta>();
            cuentas = BD.cuenta.Where(a => a.cedula == c.cedula).ToList();
            int countc = cuentas.Count();
            if (countc == 1)
            {
                modelo.ModeloCuenta1 = cuentas.ElementAt(0);
            }
            else if (countc == 2)
            {
                modelo.ModeloCuenta2 = cuentas.ElementAt(1);
            }
            else if (countc == 3)
            {
                modelo.ModeloCuenta3 = cuentas.ElementAt(2);
            }
            return View(modelo);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente c = BD.cliente.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }

            ModeloIntermedio modelo = new ModeloIntermedio();
            modelo.ModeloCliente = c;
            List<telefono> telefonos = new List<telefono>();
            telefonos = BD.telefono.Where(a => a.cedula == c.cedula).ToList();
            int countt = telefonos.Count();
            if (countt == 1)
            {
                modelo.ModeloTelf1 = telefonos.ElementAt(0);
            }
            else if (countt == 2)
            {
                modelo.ModeloTelf2 = telefonos.ElementAt(1);
            }

            List<cuenta> cuentas = new List<cuenta>();
            cuentas = BD.cuenta.Where(a => a.cedula == c.cedula).ToList();
            int countc = cuentas.Count();
            if (countc == 1)
            {
                modelo.ModeloCuenta1 = cuentas.ElementAt(0);
            }
            else if (countc == 2)
            {
                modelo.ModeloCuenta2 = cuentas.ElementAt(1);
            }
            else if (countc == 3)
            {
                modelo.ModeloCuenta3 = cuentas.ElementAt(2);
            }

            return View(modelo);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente c = BD.cliente.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            ModeloIntermedio modelo = new ModeloIntermedio();
            modelo.ModeloCliente = c;
            List<telefono> telefonos = new List<telefono>();
            telefonos = BD.telefono.Where(a => a.cedula == c.cedula).ToList();
            int countt = telefonos.Count();
            if (countt == 1)
            {
                modelo.ModeloTelf1 = telefonos.ElementAt(0);
            }
            else if (countt == 2)
            {
                modelo.ModeloTelf2 = telefonos.ElementAt(1);
            }

            List<cuenta> cuentas = new List<cuenta>();
            cuentas = BD.cuenta.Where(a => a.cedula == c.cedula).ToList();
            int countc = cuentas.Count();
            if (countc == 1)
            {
                modelo.ModeloCuenta1 = cuentas.ElementAt(0);
            }
            else if (countc == 2)
            {
                modelo.ModeloCuenta2 = cuentas.ElementAt(1);
            }
            else if (countc == 3)
            {
                modelo.ModeloCuenta3 = cuentas.ElementAt(2);
            }

            return View(modelo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            cliente c = BD.cliente.Find(id);
            BD.cliente.Remove(c);
            BD.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

