using System.Linq;
using Business.Control;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Test.TestSearchProduct
{
    [TestClass]
    public class UnitTest1
    {
        ControlGetProduct testView = new ControlGetProduct();

        /// <summary>
        /// Buscar un producto por nombre que se encuentra registrado, obtener código
        /// </summary>
        [TestMethod]
        public void TestMethodSearchProductRegistred()
        {
            JObject testProduct = testView.getProduct("Aguacate Hass");
            Assert.AreEqual("F0701", testProduct["COD"]);
        }
        /// <summary>
        /// Buscar un producto que no se encuentra registrado
        /// </summary>

        [TestMethod]
        public void TestMethodSearchProductNoRegistred() {
            JObject testProduct = testView.getProduct("Yuca");
            Assert.AreEqual(400, testProduct["message"]);
        }

        /// <summary>
        /// Ingresar campo vacio para buscar un producto
        /// </summary>
        [TestMethod]
        public void TestMethodSearchProductSpace()
        {
            JObject testProduct = testView.getProduct("       ");
            Assert.AreEqual(400, testProduct["message"]);
        }

        /// <summary>
        /// Ingresa un número como búsqueda
        /// </summary>
        [TestMethod]
        public void TestMethodSearchProductCampoNumerico()
        {
            JObject testProduct = testView.getProduct("1289892");
            Assert.AreEqual(400, testProduct["message"]);
        }

        /// <summary>
        /// Listar nombre de productos
        /// </summary>
        [TestMethod]
        public void TestMethodListNameProductCount()
        {
            JObject testProduct = testView.getNamesProducts();
            Assert.IsTrue(testProduct["items"].Count()>0);
        }

    }
}
