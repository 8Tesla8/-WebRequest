using Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TransferEntites.ServerRecievedEntites;

namespace ConsoleApp
{
    //instal nuget newtonsoft.json
    //instal nuget Microsoft.AspNet.WebApi.Client


    //I do not know if it is wordk ????
    //simple example how use webRequest to the server

    public class ServerCommunicator
    {
        private User newUser;


        private string APP_PATH = "http:locahost:8082"; //get adress from web api server, proect properties 

        private string token;


        public void StartPoint()
        {
            bool closeApp = false;


            do
            {
                Console.WriteLine("\nSERVER: {0}", APP_PATH);
                Console.Write(
                                  "1: if you want to pass regestrations\n" +
                                  "2: if you already have account\n" +
                                  "3: show device programs(only for User)\n" +
                                  "4: bind device to user, first need to do registration\n" +
                                  "5: get user devices(only for User)\n" +
                                  "6: get block category(fonly for Device)\n" +
                                  "+++++++++++++\n" +
                                  "7: AddRoles();\n" +
                                  "8: RegisterForTokenTestUserAndDevices();\n" +
                                  "9: SetRolesTestUsersDevice();\n" +
                                  "0: exit\n" +
                                  "Enter number: ");
                int choise = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choise)
                {
                    case 1:
                        string strReg = Register();
                        Console.WriteLine(strReg);

                        //tokenDictionary = GetTokenDictionary(newUser.Email, newUser.Password);
                        //token = tokenDictionary["access_token"];

                        var result = GetToken(newUser.Email, newUser.Password);
                        Console.WriteLine(result);
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.Write("Enter your email: ");
                        string email = Console.ReadLine();

                        Console.Write("Enter your password: ");
                        string password = Console.ReadLine();

                        //tokenDictionary = GetTokenDictionary(email, password);
                        //token = tokenDictionary["access_token"];

                        var tokenResult = GetToken(email, password);
                        Console.WriteLine(tokenResult);
                        break;

                    case 3:
                        string usersResp = GetPrograms(token);
                        Console.WriteLine(usersResp);
                        break;

                    case 4:
                        string deviceResp = BindDevice();
                        Console.WriteLine(deviceResp);
                        break;

                    case 5:
                        string devices = GetDevices(token);
                        Console.WriteLine(devices);
                        break;

                    case 6:
                        string rez = GetBlockCategory();
                        Console.WriteLine(rez);
                        break;

                    //case 7:
                    //    AddRoles();
                    //    break;

                    case 8:
                        RegisterForTokenTestUserAndDevices();
                        break;

                    //case 9:
                    //    SetRolesTestUsersDevice();
                    //    break;

                    case 0:
                        closeApp = true;
                        break;
                }

            } while (!closeApp);

        }

        public string GetBlockCategory()
        {
            using (var client = CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/api/BlockApp").Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public string BindDevice()
        {
            Console.Write("Enter device guid: ");
            string guid = Console.ReadLine();

            Console.Write("Enter device password: ");
            string password = Console.ReadLine();

            using (var client = CreateClient(token))
            {
                DeviceInfoToServer device = new DeviceInfoToServer()
                {
                    Guid = guid,
                    Password = password,
                };

                var response = client.PostAsJsonAsync(APP_PATH + "/api/DevicesApi", device).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        //public void AddRoles()
        //{
        //    using (AuthContext context = new AuthContext())
        //    {
        //        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        //        if (!roleManager.RoleExists("User"))
        //        {
        //            // create role   
        //            var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //            role.Name = "User";
        //            roleManager.Create(role);
        //            Console.WriteLine("User role Added");
        //        }
        //        else
        //        {
        //            Console.WriteLine("User role is exist");
        //        }
        //        if (!roleManager.RoleExists("Device"))
        //        {
        //            // create role   
        //            var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //            role.Name = "Device";
        //            roleManager.Create(role);
        //            Console.WriteLine("Device role Added");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Device role is exist");
        //        }
        //    }
        //}



        //public void SetRolesTestUsersDevice()
        //{
        //    //set Users roles 
        //    using (AuthContext context = new AuthContext())
        //    {
        //        var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
        //        var currentUser1 = userManager.FindByName("w1@gmail.com");
        //        if (currentUser1 != null)
        //        {
        //            userManager.AddToRole(currentUser1.Id, "User");
        //            Console.WriteLine("User Role set");
        //        }
        //        else
        //        {
        //            Console.WriteLine("User w1@gmail.com not found");
        //        }
        //        var currentUser2 = userManager.FindByName("w2@gmail.com");
        //        if (currentUser2 != null)
        //        {
        //            userManager.AddToRole(currentUser2.Id, "User");
        //            Console.WriteLine("User Role set");
        //        }
        //        else
        //        {
        //            Console.WriteLine("User w2@gmail.com not found");
        //        }
        //    }
        //    //set Device role
        //    using (AuthContext context = new AuthContext())
        //    {
        //        var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
        //        var currentUser1 = userManager.FindByName("1EC5F557");
        //        if (currentUser1 != null)
        //        {
        //            userManager.AddToRole(currentUser1.Id, "Device");
        //            Console.WriteLine("Device Role set");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Device 1EC5F557 not found");
        //        }
        //        var currentUser2 = userManager.FindByName("1EC5F558");
        //        if (currentUser2 != null)
        //        {
        //            userManager.AddToRole(currentUser2.Id, "Device");
        //            Console.WriteLine("Device Role set");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Device 1EC5F558 not found");
        //        }
        //        var currentUser3 = userManager.FindByName("1EC5F559");
        //        if (currentUser3 != null)
        //        {
        //            userManager.AddToRole(currentUser3.Id, "Device");
        //            Console.WriteLine("Device Role set");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Device 1EC5F559 not found");
        //        }
        //    }
        //}

        private void RegisterForTokenTestUserAndDevices()
        {
            using (var client = new HttpClient())
            {
                UserModel registerModel1 = new UserModel
                {
                    UserName = "w1@gmail.com",
                    Password = "Password6",
                    ConfirmPassword = "Password6"
                };


                UserModel registerModel2 = new UserModel
                {
                    UserName = "w2@gmail.com",
                    Password = "Password6",
                    ConfirmPassword = "Password6"
                };

                var response1 = client.PostAsJsonAsync(APP_PATH + "/api/AppAccount/Register", registerModel1).Result;
                var response2 = client.PostAsJsonAsync(APP_PATH + "/api/AppAccount/Register", registerModel2).Result;

                Console.WriteLine(response1.StatusCode.ToString() + ' ' +
                                  response1.Content.ReadAsStringAsync());

                Console.WriteLine(response2.StatusCode.ToString() + ' ' +
                                  response2.Content.ReadAsStringAsync());
            }

            //Registrate in token db 
            using (var client = new HttpClient())
            {
                UserModel registerModel1 = new UserModel
                {
                    UserName = "1EC5F557",
                    Password = "Password6",
                    ConfirmPassword = "Password6"
                };

                UserModel registerModel2 = new UserModel
                {
                    UserName = "1EC5F558",
                    Password = "Password6",
                    ConfirmPassword = "Password6"
                };

                UserModel registerModel3 = new UserModel
                {
                    UserName = "1EC5F559",
                    Password = "Password6",
                    ConfirmPassword = "Password6"
                };


                var response1 = client.PostAsJsonAsync(APP_PATH + "/api/AppAccount/Register", registerModel1).Result;
                var response2 = client.PostAsJsonAsync(APP_PATH + "/api/AppAccount/Register", registerModel2).Result;
                var response3 = client.PostAsJsonAsync(APP_PATH + "/api/AppAccount/Register", registerModel3).Result;

                Console.WriteLine(response1.StatusCode.ToString() + ' ' +
                                  response1.Content.ReadAsStringAsync());

                Console.WriteLine(response2.StatusCode.ToString() + ' ' +
                                  response2.Content.ReadAsStringAsync());

                Console.WriteLine(response3.StatusCode.ToString() + ' ' +
                                  response3.Content.ReadAsStringAsync());
            }
        }

        // регистрация
        private string Register()
        {
            Console.WriteLine();
            Console.Write("Enter prefix email \"___test@gmail.com\" : ");
            string email = Console.ReadLine();
            email += "test@gmail.com";

            //Console.Write("Enter your password \n(password must be more than 8 symbols, must containe one digita and one upper character) \nexample \"1TestPassword\": ");
            //string password = Console.ReadLine();

            string password = "Password6";

            //UserModel registerModel = new UserModel
            //{
            //    UserName = email,
            //    Password = password,
            //    ConfirmPassword = password
            //};
            using (var client = new HttpClient())
            {
                newUser = new User
                {
                    Email = email,
                    Password = password,
                    Name = "Alex"
                };

                string rezult = null;

                // "/api/Usersapi"
                var responseMyRegis = client.PostAsJsonAsync(APP_PATH + "/api/Usersapi", newUser).Result;
                if (responseMyRegis.StatusCode == HttpStatusCode.OK)
                {
                    rezult = responseMyRegis.StatusCode.ToString() + ' ' +
                             responseMyRegis.Content.ReadAsStringAsync();
                }
                else
                {
                    rezult = responseMyRegis.StatusCode.ToString() + ' ' +
                             responseMyRegis.Content.ReadAsStringAsync();
                }
                return rezult;
            }
        }

        private string GetToken(string userName, string password)
        {
            using (var client = new HttpClient())
            {
                User user = new User
                {
                    Email = userName,
                    Password = password
                };

                var response =
                    client.PostAsJsonAsync(APP_PATH + "/api/TokenApi", user).Result; // "/api/TokenApi"
                token = response.Content.ReadAsStringAsync().Result
                        .Replace("\"", string.Empty);

                //Console.WriteLine(response.StatusCode + " " + response.Content.ReadAsStringAsync().Result);

                //var result = response.Content.ReadAsStringAsync().Result;



                return response.StatusCode + " " + response.Content.ReadAsStringAsync().Result;
            }
        }

        // получение токена
        private Dictionary<string, string> GetTokenDictionary(string userName, string password)
        {
            var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>( "grant_type", "password" ),
                    new KeyValuePair<string, string>( "username", userName ),
                    new KeyValuePair<string, string> ( "Password", password )
                };
            var content = new FormUrlEncodedContent(pairs);

            using (var client = new HttpClient())
            {
                var response =
                    client.PostAsync(APP_PATH + "/Token", content).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                // Десериализация полученного JSON-объекта
                Dictionary<string, string> tokenDictionary =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                return tokenDictionary;
            }
        }

        // создаем http-клиента с токеном 
        private HttpClient CreateClient(string accessToken = "")
        {
            var client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            }
            return client;
        }

        //get data from table
        private string GetPrograms(string token)
        {
            Console.Write("Enter device guid: ");
            string guid = Console.ReadLine();

            using (var client = CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/api/programsapi/?guid=" + guid).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }



        //не использовать алгоритм устарел
        private string CreateDevice(string token)
        {
            Console.Write("Enter Device name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your password\n(password must be more than 8 symbols, must containe one digita and one upper character) \nexample \"1TestPassword\": ");
            string password = Console.ReadLine();

            //find user id
            User founUser = null;
            using (var client = CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/api/usersapi/?email=" + newUser.Email).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // Десериализация полученного JSON-объекта
                    founUser = JsonConvert.DeserializeObject<User>(result);
                }
                else
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }


            Device newDevice = new Device
            {
                Guid = System.Guid.NewGuid().ToString(),
                //Name = name,
                Password = password,

            };
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(APP_PATH + "/api/DevicesApi", newDevice).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }

        public string GetDevices(string token)
        {
            using (var client = CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/api/DevicesApi").Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
