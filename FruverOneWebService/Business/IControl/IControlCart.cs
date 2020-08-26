using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IControl
{
    public interface IControlCart
    {
        bool GetCartDetails();
        bool DeleteCartDetails(int CartDetails);
        bool UpdateQuantity();
        void ViewCartDetails();
        float CalcPrice();

    }
}