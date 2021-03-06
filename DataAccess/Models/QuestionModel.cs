﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DataAccess.Models
{
    [DataContract]
    public class QuestionModel
    {
        [DataMember]
        public int QuestionId { get; set; }
        [DataMember]
        public string QuestionText { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [DataMember]
        public string LuisIntent { get; set; }
    }
}