using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using S8__API.Models;
using Newtonsoft.Json;
using HttpClientExtension;

namespace S8__Client.Controllers
{
    public sealed class API
    {
        private static readonly HttpClient client = new HttpClient();

        private API()
        {
            client.BaseAddress = new Uri("http://localhost:64862/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private static readonly object padlock = new object();
        private static API instance = null;

        public static API Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new API();
                    }
                    return instance;
                }
            }
        }

        public async Task<User> GetUser(int id)
        {
            User user = null;
            HttpResponseMessage response = client.GetAsync("https://localhost:5001/api/users/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(resp);
            }
            return user;
        }

        public async Task<User> GetUser(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return await GetUser(id);
            return null;
        }

        public async Task<User> GetUser(string username, string password)
        {
            User user = null;
            HttpResponseMessage response = client.GetAsync("https://localhost:5001/api/users/" + username + "/" + password).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(resp);
            }
            return user;
        }

        public async Task<ICollection<Donnees>> GetDonneesAsync()
        {
            ICollection<Donnees> donnees = new List<Donnees>();
            HttpResponseMessage response = client.GetAsync("https://localhost:5001/api/Donnees").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                donnees = JsonConvert.DeserializeObject<List<Donnees>>(resp);
            }
            return donnees;
        }

        public async Task<Donnees> GetDonneesAsync(int? id)
        {
            Donnees Donnees = null;
            HttpResponseMessage response = client.GetAsync("https://localhost:5001/api/Donnees/5/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Donnees = JsonConvert.DeserializeObject<Donnees>(resp);
            }
            return Donnees;
        }

        public async Task<Uri> AjoutDonneesAsync(Donnees donnees)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:5001/api/Donnees", donnees);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri> ModifDonneesAsync(Donnees donnees)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:5001/api/Donnees/" + donnees.Id, donnees);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri> SupprDonneesAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("https://localhost:5001/api/Donnees/" + id);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
