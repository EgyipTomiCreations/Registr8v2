using System.Text.Json.Serialization;

namespace Registr8
{
    public class Utilites
    {

        public string JSON(object o)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(o);
        }

        public T OBJECT<T>(string j)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(j);
        }

        public async Task<T> GetMethod<T>(string endpoint, string token = null)
        {
            if (token != null)
            {
                if (!Globals.client.DefaultRequestHeaders.Contains("Authorization"))
                {
                    Globals.client.DefaultRequestHeaders.Add("Authorization", token);
                }
            }
            var response = await Globals.client.GetAsync(endpoint);
            return OBJECT<T>(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<T> PostMethod<T>(string endpoint, object post, string token = null)
        {
            if (token != null)
            {
                if (!Globals.client.DefaultRequestHeaders.Contains("Authorization"))
                {
                    Globals.client.DefaultRequestHeaders.Add("Authorization", token);
                }
            }
            System.Diagnostics.Debug.WriteLine(JSON(post));

            var response = await Globals.client.PostAsync(endpoint, new StringContent(JSON(post), System.Text.Encoding.UTF8, "application/json"));
            return OBJECT<T>(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<Token> Login(AuthReq req)
        {
            Token t = await PostMethod<Token>("Login/login", req);
            if (t.Guid != Guid.Empty)
            {
                return t;
            }
            t.FelhKategoria = Auth.FelhKategoria.UnAuth;
            return t;
        }

        public string Hash(string plaintext)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(plaintext)));
        }

        public async Task Logout()
        {
            await PostMethod<string>("Login/logout", null, Globals.token.Guid.ToString());
        }
    }
}
