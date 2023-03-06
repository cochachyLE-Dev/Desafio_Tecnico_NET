using APP.Auth;
using APP.Models;
using APP.Shared;

using System.Net;
using System.Text.Json;

namespace APP.Data
{
    public class ApiContext : IApiContext
    {
        public ApiSet<Sale>? Sales => new ApiSet<Sale>();
        public ApiSet<Vendor>? Vendors => new ApiSet<Vendor>();
        public ApiSet<Service>? Services => new ApiSet<Service>();
    }
    public class ApiSet<T> {
        public async Task<Response<T>> RegisterAsync(T data)
        {
            if (typeof(T) == typeof(Sale))
                return await PostAsync<T,T>(data);
            else {
                return Response<T>.Fail(StatusCode.NotImplemented,"Not Implemented");
            }
        }
        public async Task<Response<bool>> DeleteAsync(params object[] param) 
        {
            if (typeof(T) == typeof(Sale))
                return await DeleteAsync<bool>(string.Format("api/Sale/Delete/{0}/{1}", param[0], param[1]));
            else
            {
                return Response<bool>.Fail(StatusCode.NotImplemented, "Not Implemented");
            }
        }
        public async Task<Response<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Sale))
                return await GetAsync<T>("api/Sale/All");
            else if (typeof(T) == typeof(Vendor))
                return await GetAsync<T>("api/Vendor/All");
            else if (typeof(T) == typeof(Service))
                return await GetAsync<T>("api/Service/All");
            else
            {
                return Response<T>.Fail(StatusCode.NotImplemented, "Not Implemented");
            }
        }
        public async Task<Response<T>> FirstOrDefaultAsync(params object[] param) {
            if (typeof(T) == typeof(Sale))
                return await GetAsync<T>(string.Format("api/Sale/Single/{0}/{1}", param[0], param[1]));
            else
            {
                return Response<T>.Fail(StatusCode.NotImplemented, "Not Implemented");
            }
        }
        public async Task<Response<T>> SearchAsync(string filter)
        {
            if (typeof(T) == typeof(Sale))
                return await GetAsync<T>("api/Sale/Search?filter=" + WebUtility.UrlEncode(filter));
            else if (typeof(T) == typeof(Vendor))
                return await GetAsync<T>("api/Vendor/Search?filter=" + WebUtility.UrlEncode(filter));
            else if (typeof(T) == typeof(Service))
                return await GetAsync<T>("api/Service/Search?filter=" + WebUtility.UrlEncode(filter));
            else
            {
                return Response<T>.Fail(StatusCode.NotImplemented, "Not Implemented");
            }
        }
        private const string RequestUri = "http://localhost:5071";
        private async Task<string> GetToken()
        {
            var user = new AuthenticationRequest { Email = "basicuser@vaetech.net", Password = "Abc123." };

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"{RequestUri}/api/Account/authenticate");
            var content = new StringContent(JsonSerializer.Serialize(user),null, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);            

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rsContent = await response.Content!.ReadAsStringAsync();
                var rs = JsonSerializer.Deserialize<Response<AuthenticationResponse>>(rsContent)!;

                if(rs.Successed)
                    return rs.Entity?.JWToken!;
                else
                    throw new ArgumentException(rs.Message);
            }
            else
            {
                var rs = await response.Content.ReadAsStringAsync();
                throw new Exception(rs);
            }
        }
        private async Task<Response<TResult>> GetAsync<TResult>(string query) 
        {            
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{RequestUri}/{query}");
            request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
            
            var response = await client.SendAsync(request);            
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content!.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Response<TResult>>(content)!;
            }
            else
            {
                string content = await response.Content!.ReadAsStringAsync();                
                return Response<TResult>.Fail(StatusCode.InternalError, content);
            }
        }
        private Task<Response<TResult>> PostAsync<TResult, TRequest>(TRequest data)
        {
            return Task.FromResult(Response<TResult>.Fail(StatusCode.NotImplemented, "Not Implemented"));
        }
        private async Task<Response<TResult>> DeleteAsync<TResult>(string query)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"{RequestUri}/{query}");
            request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
            var response = await client.SendAsync(request);            

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content!.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Response<TResult>>(content)!;
            }
            else
            {
                string content = await response.Content!.ReadAsStringAsync();
                return Response<TResult>.Fail(StatusCode.InternalError, content);
            }
        }
    }
}
