
using System.Net;

namespace Domain;

    public class Response<T>
    {
        public int StatusCode { get; set; }
        public string Messenge { get; set; }
        public T Data { get; set; }
        public Response(HttpStatusCode code) => StatusCode = (int)code;
        public Response(T data)
        {
            StatusCode = 200;
            Data = data;
        }
        public Response(HttpStatusCode code,string messenge)
        {
            StatusCode = (int)code;
            Messenge = messenge;
        }
         public Response(HttpStatusCode code,string messenge,T data)
        {
            StatusCode = (int)code;
            Messenge = messenge;
            Data=data;
        }

    }

