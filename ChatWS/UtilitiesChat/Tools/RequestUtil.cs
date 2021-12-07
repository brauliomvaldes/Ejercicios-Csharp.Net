 
using System;
using System.Net;
using UtilitiesChat.Models.WS;

namespace UtilitiesChat
{
    public class RequestUtil
    {
        public Reply oReply { get; set; }
        public RequestUtil()
        {
            oReply = new Reply();
        }

        public Reply Execute<T>(string url, string method, T objetRequest)
        {
            oReply.result = 0;
            string result = "";
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                //convertir un objeto a string en formato json
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objetRequest);

                //crear el requerimiento con los parametros necesarios
                WebRequest request = WebRequest.Create(url);
                //encabezados
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json; charset=utf-8";
                request.Timeout = 60000;

                //escribir el objeto convertido en Json en el cuerpo de la solicitud (Request Body)
                //abrir el flujo del WebRequest
                //convierte el objeto en Json
                using (var oStreamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    //se ecribe el json en el flujo
                    oStreamWriter.Write(json);
                    //se libera el flujo y se termina de escribir en el Request Body
                    oStreamWriter.Flush();
                }

                //realizar la solicitud (Get) y recibir la respuesta (Response)
                //se trae la respuesta desde la solicitud request(WebRequest)
                var oHttpRespose = (HttpWebResponse)request.GetResponse();

                //se lee la respuesta en un flujo
                using (var oStreamReader = new StreamReader(oHttpRespose.GetResponseStream()))
                {
                    //recibe un Json de respuesta como resultado en un string
                    result = oStreamReader.ReadToEnd();
                }


                //convierte un string en formato json en un objeto
                oReply = Newtonsoft.Json.JsonConvert.DeserializeObject<Reply>(result);
                oReply.result = 1;
                oReply.message = "Transacción Exitosa";

            }
            catch (TimeoutException ex)
            {
                oReply.message = "Servidor no responde, no se realizó transacción";
            }
            catch (Exception ex)
            {
                oReply.message = "Ocurrio un error, vuelva a intentarlo";
            }
            return oReply;
        }
    }
}
}
