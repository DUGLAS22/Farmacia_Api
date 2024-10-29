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
    public class InventarioController : ApiController
    {
        private static readonly HttpClient client = new HttpClient();
        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var apiUrl = "http://localhost:50426/api/Inventarios";
            var respuestaJson = await GetAsync(apiUrl);
            //System.Diagnostics.Debug.WriteLine(respuestaJson); imprimir info
            List<Inventario> listainventario = JsonConvert.DeserializeObject<List<Inventario>>(respuestaJson);
            return Request.CreateResponse(DataSourceLoader.Load(listainventario, loadOptions));
        }

        public static async Task<string> GetAsync(string uri)
        {
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form)
        {

            var values = form.Get("values");

            var httpContent = new StringContent(values, System.Text.Encoding.UTF8, "application/json");

            var url = "http://localhost:50426/api/Inventarios";
            var response = await client.PostAsync(url, httpContent);

            var result = response.Content.ReadAsStringAsync().Result;

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form)
        {
            //Parámetros del form
            var key = Convert.ToInt32(form.Get("key")); //llave que estoy modificando
            var values = form.Get("values"); //Los valores que yo modifiqué en formato JSON

            var apiUrlGetinventario = "http://localhost:50426/api/Inventarios/" + key;
            var respuestainventario = await GetAsync(apiUrlGetinventario = "http://localhost:50426/api/Inventarios/" + key);
            Inventario inventario = JsonConvert.DeserializeObject<Inventario>(respuestainventario);

            JsonConvert.PopulateObject(values, inventario);

            string jsonString = JsonConvert.SerializeObject(inventario);
            var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");


            var url = "http://localhost:50426/api/Inventarios/" + key;
            var response = await client.PutAsync(url, httpContent);

            var result = response.Content.ReadAsStringAsync().Result;

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));

            var apiUrlDeInventario = "http://localhost:50426/api/Inventarios/" + key;
            var respuestainventario = await client.DeleteAsync(apiUrlDeInventario);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
