using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DataAccess.Models;

namespace DataAccess
{
    public static class AutoMapperBootStrapper
    {
        private static MapperConfiguration _config { get; set; }

        public static void ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Question, QuestionModel>();
                cfg.CreateMap<QuestionModel, Question>();
                cfg.CreateMap<Answer, AnswerModel>();
                cfg.CreateMap<AnswerModel, Answer>();
                cfg.CreateMap<UserLog, UserLogModel>();
                cfg.CreateMap<UserLogModel, UserLog>();
                cfg.CreateMap<Error, ErrorModel>();
                cfg.CreateMap<ErrorModel, Error>();
            });

            _config = config;
        }

        public static MapperConfiguration GetConfig()
        {
            return _config;
        }

        public static IMapper GetMapper()
        {
            return _config.CreateMapper();
        }

    }
}