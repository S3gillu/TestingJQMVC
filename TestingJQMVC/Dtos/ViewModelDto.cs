using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingJQMVC.Dtos
{
    public class ViewModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public long Age { get; set; }
        public string CurrentAddress { get; set; }
        public string Stream { get; set; }
        public string FathersName { get; set; }
        public string PermanentAddress { get; set; }

    }
}