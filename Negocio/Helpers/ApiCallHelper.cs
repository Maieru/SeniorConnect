using Negocio.TOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Negocio.Helpers
{
    public class ApiCallHelper
    {
        public async Task<ApiResponseTO<T>> Get<T>(string endpoint, string jwtToken = null, Dictionary<string, string> parameters = null)
        {
            var httpClient = FabricaHttpClient(jwtToken);
            var finalUrl = MontaUrlFinal(endpoint, parameters);
            var response = await httpClient.GetAsync(finalUrl);

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponseTO<T>>(responseString);
        }

        public async Task<ApiResponseTO<TOut>> Post<TOut, TData>(string endpoint, TData data, string jwtToken = null)
        {
            var httpClient = FabricaHttpClient(jwtToken);

            var conteudoRequisicao = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(endpoint, conteudoRequisicao);

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponseTO<TOut>>(responseString);
        }

        private HttpClient FabricaHttpClient(string authorizationToken = null)
        {
            var retorno = new HttpClient();
            
            retorno.BaseAddress = new Uri(UrlHelper.GetWebsiteUrl());
            
            if (authorizationToken != null)
                retorno.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorizationToken);

            return retorno;
        }

        private string MontaUrlFinal(string endpoint, Dictionary<string, string> parametros)
        {
            var retorno = new StringBuilder().Append(endpoint);

            if (parametros != null && parametros.Any())
            {
                retorno.Append("?");

                foreach (var parameter in parametros)
                    retorno.Append($"{parameter.Key}={parameter.Value}&");

                retorno.Remove(retorno.Length - 1, 1);
            }

            return retorno.ToString();
        }
    }
}
