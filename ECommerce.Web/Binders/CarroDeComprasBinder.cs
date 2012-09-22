using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Domain.AgregadoPedido;

namespace ECommerce.Web.Binders
{
    public class CarroDeComprasBinder : IModelBinder
    {
        private const string CarroDeComprasSessionKey = "carroDeComprasSessionKey";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var carroDeCompras = controllerContext.HttpContext.Session[CarroDeComprasSessionKey];

            if (carroDeCompras == null)
            {
                carroDeCompras = new CarroDeCompras();
                controllerContext.HttpContext.Session[CarroDeComprasSessionKey] = carroDeCompras;
            }

            return carroDeCompras;
        }
    }
}