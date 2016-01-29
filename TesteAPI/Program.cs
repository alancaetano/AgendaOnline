using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TesteAPI
{
    class Program
    {
        static void Main(string[] args)
        {


        }

        private static void EnviarConversa()
        {
            string enderecoControllerConversas = "http://localhost:8800/api/Conversas";
            string DATA = @"{'tipo':'C',
                             'usuario': [{'firstName':'John', 'lastName':'Doe'},{'firstName':'Anna', 'lastName':'Smith'}]";


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(enderecoControllerConversas);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = DATA.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(DATA);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            string response = responseReader.ReadToEnd();
                            Console.Out.WriteLine(response);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }
        }
    }
}
