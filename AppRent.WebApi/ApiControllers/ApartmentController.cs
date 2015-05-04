﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AppRent.BusinessLogic.Services.Interface;
using AppRent.Common.Filters;
using AppRent.Common.ViewModels;
using AppRent.DataAccess.UnitOfWork.Interface;


namespace AppRent.WebApi.ApiControllers
{
    public class ApartmentController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IUnitOfWork unitOfWork, IApartmentService apartmentService)
        {
            _unitOfWork = unitOfWork;
            _apartmentService = apartmentService;
        }

        
        // GET: api/Apartment
        public IEnumerable<ApartmentViewModel> Get([FromUri]ApartmentFilter filter)
        {
            return _apartmentService.GetApartments();
        }

        // GET: api/Apartment/5
        public FullApartmentViewModel Get(int id)
        {
            return _apartmentService.GetApartmentById(id);
        }

        // POST: api/Apartment
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Apartment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apartment/5
        public void Delete(int id)
        {
        }
    }
}
