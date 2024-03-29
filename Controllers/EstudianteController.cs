﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SIGEM_TAEX.Models;

using System.Net;
using Newtonsoft.Json;

namespace SIGEM_TAEX.Controllers
{
    public class EstudianteController : Controller
    {

        private Estudiante objEstudiante = new Estudiante();
        // GET: Estudiante
        public ActionResult Index(string Criterio)
        {
            if (Criterio == null || Criterio == "")
            {
                return View(objEstudiante.Listar());
            }
            else
            {
                return View(objEstudiante.Buscar(Criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(objEstudiante.Obtener(id));
        }

        public ActionResult Buscar(string Criterio)
        {
            return View
                (
                Criterio == null || Criterio == "" ? objEstudiante.Listar()
                    : objEstudiante.Buscar(Criterio)

                );
        }

        private Escuela_Profesional objEscuelaProfesional = new Escuela_Profesional();
        public ActionResult AgregarEditar(int id = 0)
        {//
            ViewBag.Docente = objEscuelaProfesional.Listar();
            //  

            return View(
                id == 0 ? new Estudiante()
                        : objEstudiante.Obtener(id)
            );
        }

        public ActionResult AgregarEditarModificar(int id = 0)
        {//
            ViewBag.Docente = objEscuelaProfesional.Listar();
            //  

            return View(
                id == 0 ? new Estudiante()
                        : objEstudiante.Obtener(id)
            );
        }
        //////////////////////////////////////////////////
        public static string primero_nombre_temporal = "";
        public static string segundo_nombre_temporal = "";
        public static string apellido_paterno_temporal = "";
        public static string apellido_materno_temporal = "";
        public static string dni_docente_temporal = "";
        //////////////////////////////////////////////////
        public ActionResult Guardar(Estudiante model, string submitButton)
        {
            switch (submitButton)
            {
                case "Consultar en RENIEC":

                    if (model.Tipo_Identificacion.Equals("DNI"))
                    {
                        //
                        string dni = Convert.ToString(model.Numero_Identificacion);

                        if (dni != null && !dni.Equals(""))
                        {
                            String url = "https://quertium.com/api/v1/reniec/dni/" + dni + "?token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.MTM3NA.VXfwWGycEWoyGTtzUb3YSNI0688GiCIY6FTXETFEO_c";

                            WebClient wc = new WebClient();
                            var datos = wc.DownloadString(url);
                            // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
                            var rs = JsonConvert.DeserializeObject<Root>(datos);
                            primero_nombre_temporal = Convert.ToString(rs.primerNombre);
                            segundo_nombre_temporal = Convert.ToString(rs.segundoNombre);
                            apellido_paterno_temporal = Convert.ToString(rs.apellidoPaterno);
                            apellido_materno_temporal = Convert.ToString(rs.apellidoMaterno);

                            dni_docente_temporal = dni;
                        }
                        //
                    }

                    return RedirectToAction("AgregarEditar");

                case "Guardar Datos":
                    if (ModelState.IsValid)
                    {
                        model.Guardar();
                        return Redirect("~/Estudiante");
                    }

                    else
                    {
                        return View("~/View/Estudiante/AgregarEditar.cshtml", model);
                    }

                ///
                case "Limpiar Consulta":
                    primero_nombre_temporal = "";
                    segundo_nombre_temporal = "";
                    apellido_paterno_temporal = "";
                    apellido_materno_temporal = "";
                    dni_docente_temporal = "";

                    return RedirectToAction("AgregarEditar");

            }

            return View();
        }

        public ActionResult Eliminar(int id)
        {
            objEstudiante.ID_Estudiante = id;
            objEstudiante.Eliminar();
            return Redirect("~/Estudiante");
        }
    }
}