using Newtonsoft.Json;

namespace MobileTemplate.DataContracts.User
{
    public class UserDataContract
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
