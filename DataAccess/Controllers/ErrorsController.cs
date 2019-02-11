using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccess.Models;

namespace DataAccess.Controllers
{
    public class ErrorsController : ApiController
    {
        private ChatdataEntities db = new ChatdataEntities();

        // GET: api/Errors
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Errors/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Errors
        public IHttpActionResult Post([FromBody]ErrorModel error)
        {
            var success = LogErrorInfo(error);

            if (!success)
            {
                return NotFound();
            }
            
            return Ok();
        }



        // PUT api/Errors/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Errors/5
        public void Delete(int id)
        {
        }

        private bool LogErrorInfo(ErrorModel errorModel)
        {
            var success = false;

            using (var db = new ChatdataEntities())
            {
                var autoMapper = AutoMapperBootStrapper.GetMapper();

                var error = autoMapper.Map<ErrorModel, Error>(errorModel);

                db.Errors.Add(error);
                db.SaveChanges();

                success = true;
            }

            return success;
        }
    }
}