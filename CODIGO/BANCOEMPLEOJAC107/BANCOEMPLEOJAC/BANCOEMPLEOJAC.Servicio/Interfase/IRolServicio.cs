﻿using BANCOEMPLEOJAC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCOEMPLEOJAC.Servicio.Interfase
{
    public interface IRolServicio
    {
        Task<List<RolDTO>> Lista(string buscar);
    }
}