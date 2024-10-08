﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = null!;

        //RELATIONS: HIJOS (Puede Ser Nulo )
        //Al crear un pais inicialmente no tiene equipos
        public ICollection<Team>? Teams { get; set; }
        //Prop lectura. no se mapea o guarda en BDatos
        public int TeamsCount => Teams == null ? 0 : Teams.Count;
    }
}
