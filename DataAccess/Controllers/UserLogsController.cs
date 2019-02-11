using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Models;

namespace DataAccess.Controllers
{
    public class UserLogsController : ApiController
    {
        // GET api/userlogs
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/userlogs/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/userlogs
        public IHttpActionResult Post([FromBody]UserLogModel userLog)
        {
            var id = LogUserActivity(userLog);

            if (id == 0)
            {
                return NotFound();
            }
            userLog.Id = id;

            return Ok(userLog);

        }

        private int LogUserActivity(UserLogModel userLogMOdel)
        {
            using (var db = new ChatdataEntities())
            {
                var autoMapper = AutoMapperBootStrapper.GetMapper();

                var newUserLog = autoMapper.Map<UserLogModel, UserLog>(userLogMOdel);


                // Add the UserLog object to UserLogs
                db.UserLogs.Add(newUserLog);

                // Save the changes to the database
                db.SaveChanges();

                return newUserLog.Id;
            }

        }
    }
}
