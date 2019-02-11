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
using AutoMapper;

namespace DataAccess.Controllers
{
    [RoutePrefix("api/questions")]
    public class QuestionsController : ApiController
    {
        private ChatdataEntities db = new ChatdataEntities();

        // GET: api/questions
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/questions/5
        [Route("{intentName}")]
        public IHttpActionResult Get(string intentName)
        {
            var question = GetQuestionByIntent(intentName);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // POST api/questions
        public void Post([FromBody]string value)
        {
        }

        // PUT api/questions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/questions/5
        public void Delete(int id)
        {
        }

        private QuestionModel GetQuestionByIntent(string intentName)
        {
            var questionList = new List<Question>();
            var questionToReturn = new Question();
            var questionModel = new QuestionModel();

            using (var db = new ChatdataEntities())
            {

                questionList = (from Question in db.Questions
                                where Question.LuisIntent == intentName
                                select Question).ToList();

                if (questionList.Count > 0)
                {
                    var autoMapper = AutoMapperBootStrapper.GetMapper();

                    questionModel = autoMapper.Map<Question, QuestionModel>(questionList[0]);
                }
            }

            return questionModel;
        }
    }
}