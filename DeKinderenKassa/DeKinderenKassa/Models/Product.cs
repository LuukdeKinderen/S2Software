﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DeKinderenKassa.Models
{
    public class Product
    {
        public long Id { get; set; }

        private string _key;

        public string Key
        {
            get
            {
                if(_key == null)
                {
                    _key = Regex.Replace(Naam.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set { _key = value; }
        }


        [Required(ErrorMessage = "Naam is verplicht")]
        [StringLength(100,MinimumLength =3,ErrorMessage = "Naam moet tussen de 3 en 100 letters bevatten")]
        public string Naam { get; set; }

        [StringLength(500, ErrorMessage = "Omschrijving mag maximaal 500 tekens bevatten")]
        public string Omschrijving { get; set; }

        [Required(ErrorMessage ="Prijs is verplicht")]
        [Range(0.01,10000.00,ErrorMessage ="Prijs moet tussen de 0,01 en 10.000 zijn")]
        public decimal Prijs { get; set; }
    }
}