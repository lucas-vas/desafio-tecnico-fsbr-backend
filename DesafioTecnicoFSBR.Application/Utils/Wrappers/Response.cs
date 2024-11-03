namespace DesafioTecnicoFSBR.Application.Utils.Wrappers
{
    public sealed class Response<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        private Response
        (
            bool succeeded,
            string message,
            T data
        ) 
        {
            Succeeded = succeeded;
            Message = message;
            Data = data;
        }

        private Response
        (
            bool succeeded,
            string message
        )
        {
            Succeeded = succeeded;
            Message = message;
        }

        public static Response<T> Success(T data, string? message = null)
        {
            var response = new Response<T>
            (
                succeeded: true,
                message: message ?? string.Empty,
                data: data
            );

            return response;
        }

        public static Response<T> Fail(string message)
        {
            var response = new Response<T>
            (
                succeeded: false,
                message: message
            );

            return response;
        }
    }
}
