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
    public class AnswersController : ApiController
    {
        private ChatdataEntities db = new ChatdataEntities();

        // GET: api/Answers
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Answers/5
        public IHttpActionResult Get(int id)
        {
            var answers = GetAnswers(id);

            if (answers == null)
            {
                return NotFound();
            }

            return Ok(answers);
        }

        // POST api/Answers
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Answers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Answers/5
        public void Delete(int id)
        {
        }

        private List<AnswerModel> GetAnswers(int questionId)
        {
            var answerList = new List<Answer>();
            //var questionToReturn = new Question();
            var answerModelList = new List<AnswerModel>();

            using (var db = new ChatdataEntities())
            {
                try
                {
                    answerList = (from Answer in db.Answers
                                    where Answer.QuestionId == questionId
                                    select Answer)
                                .ToList();
                }

                catch (Exception ex)
                {
                    var foo = ex.Message;
                }

                if (answerList.Count > 0)
                {
                    var autoMapper = AutoMapperBootStrapper.GetMapper();

                    answerModelList = autoMapper.Map<List<Answer>, List<AnswerModel>>(answerList);
                }
            }

            return answerModelList;
        }
    }
}