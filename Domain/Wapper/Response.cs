
using System.Net;

namespace Domain.Wapper;

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
        public Response(string messenge)
        {
            Messenge = messenge;
        }

    }

