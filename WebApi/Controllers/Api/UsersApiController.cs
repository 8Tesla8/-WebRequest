using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers.Api
{
    //no need to write api
    public class UsersApiController : ApiController
    {

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult CreateUser([FromBody]User newUser)
        {
            //try
            //{
            //    //journal = new LogJournal(ControllerContext, HttpContext.Current.Request, newUser);

            //    tableHandler.Create(newUser);


            //    //journal.WriteInfo(tableHandler.Status);
            //    if (tableHandler.Status == StatusRequest.Created)
            //    {
            //        //rigistration in other db for token
            //        HttpResponseMessage response = null;
            //        using (var client = new HttpClient())
            //        {
            //            UserModel registerModel = new UserModel
            //            {
            //                UserName = newUser.Email,
            //                Password = newUser.Password,
            //                ConfirmPassword = newUser.Password
            //            };
            //            response = client.PostAsJsonAsync(ServerConfiguration.ServerUrl +
            //                "/api/AppAccount/Register", registerModel).Result;
            //        }

            //        //journal.WriteInfo("Second registartion");
            //        //journal.WriteInfo("StatusCode :"+ response.StatusCode.ToString());
            //        if (response.StatusCode == HttpStatusCode.OK)
            //        {
            //            //set role
            //            using (AuthContext context = new AuthContext())
            //            {
            //                var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            //                var currentNewUser = userManager.FindByName(newUser.Email);
            //                userManager.AddToRole(currentNewUser.Id, "User");
            //            }


            //            return Ok();
            //        }
            //        else
            //        {
            //            //проверка создался ли User во 2 базе(ForTokenDb)
            //            using (AuthContext context = new AuthContext())
            //            {
            //                var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            //                var currentNewUser = userManager.FindByName(newUser.Email);

            //                if (currentNewUser != null)
            //                {
            //                    userManager.AddToRole(currentNewUser.Id, "User");

            //                    return Ok();
            //                }
            //            }
            //        }
            //        //TODO сделать что то с system.threading.tasks.task 1 system.string


            //        //journal.WriteInfo("BadRequest :" + response.Content.ReadAsStringAsync());
            //        return BadRequest(response.StatusCode.ToString() + ' ' +
            //                     response.Content.ReadAsStringAsync());
            //    }

            //    User userExist = tableHandler.Find(newUser.Email);
            //    if (userExist != null)
            //        tableHandler.Delete(newUser.Email);

            //    return BadRequest(DbValidator.WriteErrors(tableHandler.ErrorMassage)); //, journal));
            //}
            //catch (Exception ex)
            //{
            //    //если пользователь создался в 1 базе и возникли сложности в создании 
            //    //пользователя во второй(для токена) найти и удалить его 
            //    User userExist = tableHandler.Find(newUser.Email);
            //    if (userExist != null)
            //    {
            //        tableHandler.Delete(newUser.Email);
            //        using (AuthContext context = new AuthContext())
            //        {
            //            var us = context.Users.FirstOrDefault(u => u.UserName.Equals(newUser.Email));
            //            context.Users.Remove(us);
            //            context.SaveChanges();
            //        }
            //    }


            //    //journal.WriteInfo(ex);
            //    return BadRequest(ex.Message);
            //}

            //+++++
            return Ok();
        }

        //diference between PUT and PATCH 
        //when you call PUT you send all obj
        //when you call PATCH you send a part of obj
        [HttpPatch]
        public IHttpActionResult EditUser([FromBody]User newUserInfo)
        {
            //try
            //{
            //    //LogJournal journal = new LogJournal(ControllerContext, HttpContext.Current.Request, newUserInfo);


            //    var currentUserEmail = User.Identity.GetUserName();
            //    newUserInfo.Email = currentUserEmail;


            //    tableHandler.Edit(newUserInfo);


            //    //journal.WriteInfo(tableHandler.Status);
            //    if (tableHandler.Status == StatusRequest.Edited)
            //    {
            //        return Ok();
            //    }
            //    return BadRequest(DbValidator.WriteErrors(tableHandler.ErrorMassage)); //, journal));
            //}
            //catch (Exception ex)
            //{
            //    //journal.WriteInfo(ex);
            //    return BadRequest(ex.Message);
            //}



            //+++++
            return Ok();
        }
    }
}
