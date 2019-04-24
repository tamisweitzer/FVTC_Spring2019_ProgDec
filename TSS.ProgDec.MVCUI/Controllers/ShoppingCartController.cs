using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSS.ProgDec.BL;


namespace TSS.ProgDec.MVCUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingCart cart;

        // GET: ShoppingCart
        public ActionResult Index()
        {
            GetShoppingCart();
            return View(cart);
        }


        // partial view to show cart in sidebar
        [ChildActionOnly]
        public ActionResult CartDisplay()
        {
            GetShoppingCart();
            return PartialView(cart);
        }


        public ActionResult AddToCart(int id)
        {
            GetShoppingCart();
            BL.ProgDec progDec = new BL.ProgDec();
            progDec.Id = id;
            progDec.LoadById();
            cart.Add(progDec);
            Session["cart"] = cart;
            return RedirectToAction("Index", "ProgDec");
        }

        public ActionResult RemoveFromCart(int id)
        {
            GetShoppingCart();
            BL.ProgDec progDec = cart.Items.FirstOrDefault(i => i.Id == id);
            cart.Remove(progDec);
            Session["cart"] = cart;
            return RedirectToAction("Index");   // remember, this is showing the index of the shopping cart
        }

        private void GetShoppingCart()
        {
            if (Session["cart"] == null)
            {
                cart = new ShoppingCart();
            }
            else
            {
                cart = (ShoppingCart)Session["cart"];
            }
        }
    }
}