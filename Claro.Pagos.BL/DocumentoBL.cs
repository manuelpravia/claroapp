using Claro.Pagos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Claro.Pagos.BL
{
    public class DocumentoBL : IDocumentoBL
    {
        public List<DocumentoBE> ListarDocumentos()
        {
            List<DocumentoBE> listDocumentos = new List<DocumentoBE>();
            DocumentoBE documentoBE1 = new DocumentoBE();
            documentoBE1.cliente = "Samuel Rojas";
            documentoBE1.importe = 300;
            documentoBE1.saldo = 150;
            documentoBE1.tipoComprobante = "Boleta";
            documentoBE1.fecha = DateTime.Now;
            listDocumentos.Add(documentoBE1);

            DocumentoBE documentoBE2 = new DocumentoBE();
            documentoBE2.cliente = "Ricardo Reyes";
            documentoBE2.importe = 800;
            documentoBE2.saldo = 350;
            documentoBE2.tipoComprobante = "Boleta";
            documentoBE2.fecha = DateTime.Now;
            listDocumentos.Add(documentoBE2);

            DocumentoBE documentoBE3 = new DocumentoBE();
            documentoBE3.cliente = "Karina Campos";
            documentoBE3.importe = 200;
            documentoBE3.saldo = 100;
            documentoBE3.tipoComprobante = "Factura";
            documentoBE3.fecha = DateTime.Now;
            listDocumentos.Add(documentoBE3);

            return listDocumentos;


        }

        //public List<DocumentoBE> ListarDocumentosMock()
        //{
        //    List<DocumentoBE> listaDocumentos = new List<DocumentoBE>();
        //    string apiUrl = "http://manuel:8089/documento/consulta";
        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        try
        //        {
        //            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                string jsonResponse =await response.Content.ReadAsStringAsync();

        //                listaDocumentos = JsonConvert.DeserializeObject<List<DocumentoBE>>(jsonResponse);

        //                Console.WriteLine(jsonResponse);
        //                return listaDocumentos;
        //            }
        //            else
        //            {

        //                Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
        //                return listaDocumentos;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Ocurrió un error: " + ex.Message);
        //            return listaDocumentos;
        //        }
        //    }
        //}

        public  List<DocumentoBE> ListarDocumentosMock()
        {
            List<DocumentoBE> listaDocumentos = new List<DocumentoBE>();
            string apiUrl = "http://manuel:8089/documento/consulta";
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    Console.WriteLine("Llamando al servicio rest");
                    HttpResponseMessage response =  httpClient.GetAsync(apiUrl).Result;

                    DateTime dety = DateTime.Now;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse =  response.Content.ReadAsStringAsync().Result;

                        listaDocumentos = JsonConvert.DeserializeObject<List<DocumentoBE>>(jsonResponse);

                        Console.WriteLine(jsonResponse);
                        return listaDocumentos;
                    }
                    else
                    {

                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + response.StatusCode);
                        return listaDocumentos;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error: " + ex.Message);
                    return listaDocumentos;
                }
            }
        }
    }
}