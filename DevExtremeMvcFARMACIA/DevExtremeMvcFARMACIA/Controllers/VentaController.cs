using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DevExtremeMvcFARMACIA.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
//using System.Web.Mvc;
using Newtonsoft.Json;


using System.Net.Http.Formatting;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Web;
//using System.Web.Mvc;
namespace DevExtremeMvcFARMACIA.Controllers
{
    public class VentaController : ApiController
    {
        private static readonly HttpClient client = new HttpClient();

        // GET: api/Ventas
        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var apiUrl = "http://localhost:50426/api/Ventas";
            var respuestaJson = await GetAsync(apiUrl);
            List<Venta> listaVentas = JsonConvert.DeserializeObject<List<Venta>>(respuestaJson);
            return Request.CreateResponse(DataSourceLoader.Load(listaVentas, loadOptions));
        }

        public static async Task<string> GetAsync(string uri)
        {
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // POST: api/Ventas
        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form)
        {
            var values = form.Get("values");

            var httpContent = new StringContent(values, Encoding.UTF8, "application/json");

            var url = "http://localhost:50426/api/Ventas";
            var response = await client.PostAsync(url, httpContent);

            var result = response.Content.ReadAsStringAsync().Result;

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // PUT: api/Ventas/5
        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form)
        {
            // Obtener el ID de la venta que se está modificando
            var key = Convert.ToInt32(form.Get("key"));
            var values = form.Get("values");

            var apiUrlGetVenta = "http://localhost:50426/api/Ventas/" + key;
            var respuestaVenta = await GetAsync(apiUrlGetVenta);
            Venta venta = JsonConvert.DeserializeObject<Venta>(respuestaVenta);

            JsonConvert.PopulateObject(values, venta);

            string jsonString = JsonConvert.SerializeObject(venta);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var url = "http://localhost:50426/api/Ventas/" + key;
            var response = await client.PutAsync(url, httpContent);

            var result = response.Content.ReadAsStringAsync().Result;

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Ventas/5
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));

            var apiUrlDelVenta = "http://localhost:50426/api/Ventas/" + key;
            var respuestaVenta = await client.DeleteAsync(apiUrlDelVenta);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
