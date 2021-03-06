﻿using LocationApp.Data.Database;
using LocationApp.Data.Dto;
using LocationApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.Core.Core
{
    public class FloorLogic
    {
        WebOperationContext webOperationContext = WebOperationContext.Current;
        public string AddFloor(FloorDto floorDto)
        {
            try
            {
                floor item = new floor();
                item.FloorID = floorDto.FloorID;
                item.Map = floorDto.Map;
                item.Name = floorDto.Name;
                item.Other = floorDto.Other;
                item.BlockID = floorDto.BlockID;
                item.BuildID = floorDto.BuildID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<floor>().Insert(item);
                    unitofWork.saveChanges();
                    return (webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.OK).ToString();
                }
            }
            catch (Exception ex)
            {
                return (webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError).ToString();
            }
        }
        public string SetFloor(FloorDto floorDto)
        {
            try
            {
                floor item = new floor();
                item.FloorID = floorDto.FloorID;
                item.Map = floorDto.Map;
                item.Name = floorDto.Name;
                item.Other = floorDto.Other;
                item.BlockID = floorDto.BlockID;
                item.BuildID = floorDto.BuildID;

                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    unitofWork.GetRepository<floor>().Update(item);
                    unitofWork.saveChanges();
                    return (webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.OK).ToString();
                }
            }
            catch (Exception ex)
            {
                return (webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError).ToString();
            }
        }
        public string DelFloor(int floorID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selectedFloor = unitofWork.GetRepository<floor>().GetById(x => x.FloorID == floorID);
                    unitofWork.GetRepository<floor>().Delete(selectedFloor);
                    unitofWork.saveChanges();
                    return (webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.OK).ToString();
                }
            }
            catch (Exception)
            {
                return (webOperationContext.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError).ToString();
            }
        }
        public FloorDto GetFloor(int floorID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    floor item = new floor();
                    item = unitofWork.GetRepository<floor>().GetById(x => x.FloorID == floorID);
                    FloorDto floorDto = new FloorDto();
                    floorDto.FloorID = item.FloorID;
                    floorDto.Map = item.Map;
                    floorDto.Name = item.Name;
                    floorDto.Other = item.Other;
                    floorDto.BlockID = (int)item.BlockID;
                    floorDto.BuildID = (int)item.BuildID;

                    return floorDto;
                }
            }
            catch (Exception)
            {
                return new FloorDto();
            }
        }
    }
}
