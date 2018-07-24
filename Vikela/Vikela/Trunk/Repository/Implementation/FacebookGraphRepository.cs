using System;
using System.Net.Http;
using System.Threading.Tasks;
using CorePCL;
using Newtonsoft.Json;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;

namespace Vikela.Trunk.Repository.Implementation
{
    public class FacebookEmail
    {
        public string Email { get; set; }
    }

    public class FacebookGraphRepository<T> : ProjectBaseRepository, IFacebookGraphRepository<T>
        where T : BaseViewModel, new()
    {
        public FacebookGraphRepository(IMasterRepository masterRepository) : base(masterRepository)
        {
        }

        public async Task<string> GetEmailAsync(string accessToken)
        {
            var httpClient = new HttpClient();
         
            var json =
               await httpClient.GetStringAsync(
                  $"https://graph.facebook.com/me?fields=email&access_token={accessToken}");
         
            var email =
               JsonConvert.DeserializeObject<FacebookEmail>(json);
         
            return email.Email;
        }
    }
}
