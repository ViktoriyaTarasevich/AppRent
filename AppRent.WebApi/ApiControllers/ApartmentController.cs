using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AppRent.DataAccess.UnitOfWork.Interface;


namespace AppRent.WebApi.ApiControllers
{
    public class ApartmentController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        // GET: api/Apartment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Apartment/5
        public string Get(int id)
        {
            return "value";
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
