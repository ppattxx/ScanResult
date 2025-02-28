using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintGaransi.Model
{
    internal interface INumberModelRepository
    {
        List<NumberModel> GetAllNumbers();
        NumberModel GetNumber(string partCode);
    }
}
