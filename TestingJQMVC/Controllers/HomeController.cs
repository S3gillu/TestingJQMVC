using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TestingJQMVC.Dtos;
using TestingJQMVC.Models;

namespace TestingJQMVC.Controllers
{
    public class HomeController : ApiController
    {

         PupilContext db;
       
       
        public HomeController()
        {
            db = new PupilContext();
        }
   
        public IEnumerable<ViewModelDto> GetHome()
        {
            return db.ViewModels.ToList().Select(Mapper.Map<ViewModel, ViewModelDto>);
        }
        public ViewModelDto GetHome(int id)
        {
            var member = db.ViewModels.SingleOrDefault(x => x.Id == id);
            if (member == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<ViewModel, ViewModelDto>(member);

        }
        [HttpPost]


        //Post Operation
        public IHttpActionResult CreateMember(ViewModelDto viewModelDto)
        {
            if (!ModelState.IsValid)

                return BadRequest();
            var member = Mapper.Map<ViewModelDto, ViewModel>(viewModelDto);
            db.ViewModels.Add(member);
            db.SaveChanges();
            viewModelDto.Id = member.Id;
            return Created(new Uri(Request.RequestUri + "/" + member.Id), viewModelDto);

        }

        [HttpPut]
        //Put Operation
        public void UpdateMember(int id, ViewModelDto viewModelDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var memberInDb = db.ViewModels.SingleOrDefault(c => c.Id == id);
            if (memberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(viewModelDto, memberInDb);

            db.SaveChanges();


        }
        [HttpDelete]
        //Delete Operation
        public void DeleteMember(int id)
        {
            var memberInDb = db.ViewModels.SingleOrDefault(c => c.Id == id);
            if (memberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            db.ViewModels.Remove(memberInDb);
            db.SaveChanges();
        }
     

    }
}
