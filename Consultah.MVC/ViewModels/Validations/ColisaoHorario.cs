﻿using ConsultaH.Application.Interface;
using Ninject;
using System;
using System.ComponentModel.DataAnnotations;

namespace Consultah.MVC.ViewModels.Validations
{
    public class ColisaoHorario : ValidationAttribute
    {
        [Inject]
        public IConsultaAppService _consultaApp { get; set; }

        public override bool IsValid(object value)
        {
            var horario = Convert.ToDateTime(value);
            var horarioColide = !_consultaApp.DateExists(horario);

            return horarioColide;
        }
    }
}