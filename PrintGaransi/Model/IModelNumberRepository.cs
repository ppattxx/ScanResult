﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintGaransi.Model
{
    public interface IModelNumberRepository
    {
        public List<GaransiModel> GetAllModelCodes();
    }
}
