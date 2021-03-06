﻿using LocationApp.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationApp.Data;
using System.ServiceModel.Web;
using LocationApp.Data.Dto;
using LocationApp.Data.UnitOfWork;
using System.Net;

namespace LocationApp.Core.Core
{
    public class UserTitleLogic
    {
        WebOperationContext webOperationContext = WebOperationContext.Current;

        public string AddUserTitle(UserTitleDto userTitleDto)
        {
            try
            {
                usertitle item = new usertitle();
                item.UserTitleID = userTitleDto.UserTitleId;
                item.TitleName = userTitleDto.TitleName;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<usertitle>().Insert(item);
                    unitofWork.saveChanges();
                    return (webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.OK).ToString();
                }
            }
            catch (Exception ex)
            {
                return (webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError).ToString();
            }
        }

        public string SetUserTitle(UserTitleDto userTitleDto)
        {
            try
            {
                usertitle item = new usertitle();
                item.UserTitleID = userTitleDto.UserTitleId;
                item.TitleName = userTitleDto.TitleName;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<usertitle>().Update(item);
                    unitofWork.saveChanges();
                    return (webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.OK).ToString();
                }
            }
            catch (Exception)
            {
                return (webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError).ToString();
            }
        }
        public string DelUserTitle(int userTitleId)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedUserTitle = unitofWork.GetRepository<usertitle>().GetById(x => x.UserTitleID == userTitleId);
                    unitofWork.GetRepository<usertitle>().Delete(selectedUserTitle);
                    unitofWork.saveChanges();
                    return (webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.OK).ToString();
                }
            }
            catch (Exception)
            {
                return (webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError).ToString();
            }
        }
        public UserTitleDto GetUserTitle(int userTitleId)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    usertitle item = new usertitle();
                    item = unitofWork.GetRepository<usertitle>().GetById(x => x.UserTitleID == userTitleId);
                    UserTitleDto userTitleDto = new UserTitleDto();
                    userTitleDto.TitleName = item.TitleName;
                    userTitleDto.UserTitleId = item.UserTitleID;

                    return userTitleDto;
                }
            }
            catch (Exception)
            {
                return new UserTitleDto();
            }
        }
        
        
        //public List<usertitle> GetUserTitleList()
        //{
        //    try
        //    {
        //        using (UnitOfWork unitofWork = new UnitOfWork())
        //        {
        //            List<UserTitleDto> userTitleDtoList = new List<UserTitleDto>();

        //            //var item = unitofWork.GetRepository<usertitle>().Select(x=>x.);
        //            UserTitleDto userTitleDto = new UserTitleDto();
        //            userTitleDtoList.Add(userTitleDto);
        //            return null;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return new List<usertitle>();
        //    }
        //}
    }
}
