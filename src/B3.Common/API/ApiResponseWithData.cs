namespace B3.Common.API
{
    public class ApiResponseWithData<T> : ApiResponse
    {
        public T Data { get; set; }
    }
}
