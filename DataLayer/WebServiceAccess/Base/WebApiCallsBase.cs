using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DatataLayer.WebServiceAccess.Base
{
    public abstract class WebApiCallsBase
    {
        protected readonly string ServiceAddress;
        protected readonly string EmployeeBaseUri;
       


        protected WebApiCallsBase()
        {
            ServiceAddress = ConfigurationManager.AppSettings["ServiceAddress"];
            EmployeeBaseUri = $"{ServiceAddress}/api/Employees";
           
        }

        internal async Task<string> GetJsonFromGetResponseAsync(string uri)
        {
            try
            {

                using (var client = new HttpClient(new HttpClientHandler { MaxConnectionsPerServer = 100  }))
                {
                    var response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"The Call to {uri} failed.  Status code: {response.StatusCode}");
                    }
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                //Do something intelligent here
                Console.WriteLine(ex);
                throw;
            }

        }
        internal async Task<T> GetItemAsync<T>(string uri)
            where T : class, new()
        {
            try
            {
                var json = await GetJsonFromGetResponseAsync(uri);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                //Do something intelligent here
                Console.WriteLine(ex);
                throw;
            }
        }

        

        internal async Task<IList<T>> GetItemListAsync<T>(string uri)
            where T : class, new()
        {
            try
            {
                return JsonConvert.DeserializeObject<IList<T>>(await GetJsonFromGetResponseAsync(uri));
            }
            catch (Exception ex)
            {
                //Do something intelligent here
                Console.WriteLine(ex);
                throw;
            }
        }

        internal async Task<IQueryable<T>> GetItemQuery<T>(string uri)
            where T : class, new()
        {
            try
            {
                var response = JsonConvert.DeserializeObject<IList<T>>(await GetJsonFromGetResponseAsync(uri));
                return response.AsQueryable();
            }
            catch (Exception ex)
            {
                //Do something intelligent here
                Console.WriteLine(ex);
                throw;
            }
        }

        

        protected static async Task<string> ExecuteRequestAndProcessResponse(
            string uri, Task<HttpResponseMessage> task)
        {
            try
            {
                var response = await task;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"The Call to {uri} failed.  Status code: {response.StatusCode}");
                }
                //return response.Headers.Location.AbsoluteUri;
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                //Do something intelligent here
                Console.WriteLine(ex);
                throw;
            }
        }

        protected StringContent CreateStringContent(string json)
        {
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        protected async Task<string> SubmitPostRequestAsync(string uri, string json)
        {
            using (var client = new HttpClient())
            {
                var task = client.PostAsync(uri, CreateStringContent(json));
                return await ExecuteRequestAndProcessResponse(uri, task);
            }
        }

        protected async Task<HttpResponseMessage> SubmitPostRequestAsyncTask(string uri, string json)
        {
            using (var client = new HttpClient())
            {
                return await client.PostAsync(uri, CreateStringContent(json));
                
            }
        }

        protected async Task<HttpResponseMessage> SubmitPostRequestAsyncTask(string uri, HttpContent content)
        {
            using (var client = new HttpClient())
            {
                return await client.PostAsync(uri, content);

            }
        }

        protected async Task<IList<T>> SubmitPostRequestListAsync<T>(string uri, string json) where T: class, new()
        {
            using (var client = new HttpClient(new HttpClientHandler { MaxConnectionsPerServer = 100 }))
            {
                var task = client.PostAsync(uri, CreateStringContent(json));
                return JsonConvert.DeserializeObject<IList<T>>(await ExecuteRequestAndProcessResponse(uri, task));
                //return await ExecuteRequestAndProcessResponse(uri, task);
            }
        }

        protected async Task<string> SubmitPutRequestAsync(string uri, string json)
        {
            using (var client = new HttpClient(new HttpClientHandler { MaxConnectionsPerServer = 100 }))
            {
                Task<HttpResponseMessage> task = client.PutAsync(uri, CreateStringContent(json));
                return await ExecuteRequestAndProcessResponse(uri, task);
            }
        }
        protected async Task SubmitDeleteRequestAsync(string uri)
        {
            try
            {
                using (var client = new HttpClient(new HttpClientHandler { MaxConnectionsPerServer = 100 }))
                {
                    Task<HttpResponseMessage> deleteAsync = client.DeleteAsync(uri);
                    var response = await deleteAsync;
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                //Do something intelligent here
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}