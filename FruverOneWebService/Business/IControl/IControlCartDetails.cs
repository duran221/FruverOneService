﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IControl
{
    interface IControlCartDetails
    {
        void NewCart(char Cart);
        float CalcPrice();
    }
}
