using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingJQMVC.Models
{
    public class PupilDetail
    {


        public int PupilId { get; set; }


        public string CurrentAddress { get; set; }
        public string Stream { get; set; }
        public string FathersName { get; set; }
        public string PermanentAddress { get; set; }

        public virtual Pupil Pupil { get; set; }

    }
}