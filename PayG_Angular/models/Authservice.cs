using Newtonsoft.Json;
using System.Text;

namespace PayG_Angular.models
{
    public class Authservice
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public string baseaddress { get; set; }

        private readonly IWebHostEnvironment webHostEnvironment;
        // private readonly IHttpContextAccessor _hca; 


        public Authservice(IHttpContextAccessor contextAccessor)
        {
           
            _contextAccessor = contextAccessor;

        }

        public async Task<bool> RegisterUserAsync(register r)
        {
           
            var model = new register 


            {
                FIRSTNAME = r.FIRSTNAME,
                LASTNAME = r.LASTNAME,
                USERNAME = r.USERNAME,

                PASSWORD = r.PASSWORD,
                appcode = "BaseAddress",

            };

            //****************---------************************
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseaddress);     //APIGateway_BaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                string serializedObject = JsonConvert.SerializeObject(model);
                HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/api/auth/register", contentPost);
                //****************************************** 

                if (response.IsSuccessStatusCode)
                {
                    //

                    //

                    return true;
                }
            }
            return false;
        }

        //internal Task<string[]> LoginAsync(object USERNAME, object PASSWORD)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<string[]> LoginAsync(string USERNAME, string PASSWORD)
        //{

        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        var model = new register
        //        {
        //            USERNAME = USERNAME,
        //            PASSWORD = PASSWORD,

        //            appcode = "BaseAddress"
        //        };



        //        client.BaseAddress = new Uri(baseaddress);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        string serializedObject = JsonConvert.SerializeObject(model);
        //        HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
        //        var response = await client.PostAsync("Auth/login", contentPost);

        //        //***************************************888

        //        // var response = await client.SendAsync(request);
        //        if (response.IsSuccessStatusCode)
        //        {

        //            var content = await response.Content.ReadAsStringAsync();
        //            var handler = new JwtSecurityTokenHandler();

        //            //JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);
        //            //jwtdecode()
        //            JToken jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);
        //            // j.Value

        //            String[] accessToken = new String[] { "", "", "" };
        //            accessToken[0] = jwtDynamic.Value<string>("auth_token");



        //            var token = handler.ReadJwtToken(accessToken[0]);


        //            //    IJwtValidator _validator = new JwtValidator(_serializer, _provider);
        //            //  IJwtDecoder decoder = new JwtDecoder(_serializer, _validator, _urlEncoder, _algorithm);
        //            //   var token1 = decoder.DecodeToObject<JwtToken>(accessToken);
        //            //   DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(token1.exp);

        //            //var accessTokenExpiration = token.ValidTo.ToUniversalTime();//jwtDynamic.Value<DateTime>(".exp");
        //            //var accessTokenExpiration = dateTimeOffset.LocalDateTime;
        //            //////////////////////handler.ValidateToken(token)

        //            var accessTokenExpiration = TimeZoneInfo.ConvertTimeFromUtc(token.ValidTo, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        //            accessToken[1] = accessTokenExpiration.ToString();
        //            _contextAccessor.HttpContext.Session.SetString("AccessTokenExpirationDate", accessTokenExpiration.ToString());

        //            accessToken[2] = jwtDynamic.Value<string>("user_roleId");
        //            _contextAccessor.HttpContext.Session.SetString("employeeRoleId", accessToken[2].ToString());


        //            return accessToken;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //    finally
        //    {

        //    }
        //}

        //internal Task<bool> RegisterUserAsync(Register r)
        //{
        //    throw new NotImplementedException();
        //}
    }

            }
