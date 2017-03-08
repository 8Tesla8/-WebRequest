using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TransferEntites.ServerRecievedEntites;

namespace WebApi.Controllers.Api
{
    //no need to write api
    public class DeviceApiController : ApiController
    {

        public IHttpActionResult GetDevices()
        {
            //try
            //{
            //    //journal = new LogJournal(ControllerContext, HttpContext.Current.Request, "email: " + email);

            //    //access
            //    //1 option
            //    var currentUserEmail = User.Identity.GetUserName();

            //    //2 option
            //    //IPrincipal principal = Thread.CurrentPrincipal;
            //    //IIdentity identity = principal == null ? null : principal.Identity;
            //    //string name = identity == null ? "" : identity.Name;


            //    var foundDevice = _tableHandler.GetAllUserDevice(currentUserEmail);

            //    //journal.WriteInfo(_tableHandler.Status);
            //    if (_tableHandler.Status == StatusRequest.Found)
            //    {
            //        return Json(foundDevice);
            //    }

            //    return BadRequest(DbValidator.WriteErrors(_tableHandler.ErrorMassage));//, journal));
            //}
            //catch (Exception ex)
            //{
            //    //journal.WriteInfo(ex);
            //    return BadRequest(ex.Message);
            //}


            //+++
            return Ok();
        }


        [HttpPost]
        public IHttpActionResult BindDevice([FromBody]DeviceInfoToServer receivedDeviceInfoToServer)
        {
            //try
            //{
            //    //journal = new LogJournal(ControllerContext, HttpContext.Current.Request, receivedDeviceInfo);


            //    //access
            //    var currentUserEmail = User.Identity.GetUserName();

            //    receivedDeviceInfoToServer.Email = currentUserEmail;



            //    _tableHandler.BindDeviceAndUser(receivedDeviceInfoToServer);

            //    //journal.WriteInfo(_tableHandler.Status);
            //    if (_tableHandler.Status == StatusRequest.Ok)
            //    {
            //        return Ok();
            //    }
            //    return BadRequest(DbValidator.WriteErrors(_tableHandler.ErrorMassage));//, journal));
            //}
            //catch (Exception ex)
            //{
            //    //journal.WriteInfo(ex);
            //    return BadRequest(ex.Message);
            //}

            //++++
            return Ok();
        }

        //diference between PUT and PATCH 
        //when you call PUT you send all obj
        //when you call PATCH you send a part of obj
        [HttpPatch]
        public IHttpActionResult EditDevice([FromBody]DeviceInfoToServer receivedNewDeviceInfoToServer)
        {
            //try
            //{
            //    //journal = new LogJournal(ControllerContext, HttpContext.Current.Request, receivedNewDeviceInfo);

            //    ITableUsersHandler userHandler = _dbHandler.UsersHandler;

            //    //access
            //    var currentUserEmail = User.Identity.GetUserName();

            //    if (!userHandler.IsUserHaveAccess(currentUserEmail, receivedNewDeviceInfoToServer.Guid))
            //        return BadRequest("invalid data");


            //    receivedNewDeviceInfoToServer.Email = currentUserEmail;


            //    _tableHandler.Edit(receivedNewDeviceInfoToServer);

            //    //journal.WriteInfo(_tableHandler.Status);
            //    if (_tableHandler.Status == StatusRequest.Edited)
            //    {
            //        return Ok();
            //    }
            //    return BadRequest(DbValidator.WriteErrors(_tableHandler.ErrorMassage));//, journal));
            //}
            //catch (Exception ex)
            //{
            //    //journal.WriteInfo(ex);
            //    return BadRequest(ex.Message);
            //}

            //++++
            return Ok();
        }


        public IHttpActionResult DeleteDevice(string guid)
        {
            ////journal = new LogJournal(ControllerContext, HttpContext.Current.Request, deleteInfo);


            ////access
            //var currentUserEmail = User.Identity.GetUserName();
            ////проверка идет внутри удаления есть ли у пользователя девайс с переданным гуидом

            //_tableHandler.Delete(guid, currentUserEmail);

            ////journal.WriteInfo(_tableHandler.Status);
            //if (_tableHandler.Status == StatusRequest.Deleted)
            //{
            //    return Ok();
            //}
            //return BadRequest(DbValidator.WriteErrors(_tableHandler.ErrorMassage));//, journal));

            //+++
            return Ok();
        }
    }
}
