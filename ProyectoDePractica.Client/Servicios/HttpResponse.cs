namespace ProyectoDePractica.Client.Servicios
{
    public class HttpResponse<T>
    {
        public HttpResponse(T response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            this.httpResponseMessage = httpResponseMessage;
        }

        public T Response { get; set; }
        public bool Error { get; set; }
        public HttpResponseMessage httpResponseMessage { get; set; }
    }
}
