using AutoMapper;
using MindmapRevisionApp.Dtos;
using MindmapRevisionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MindmapRevisionApp.Controllers.Api
{
    public class MindmapController : ApiController
    {
        private ApplicationDbContext _context;

        public MindmapController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMindmaps()
        {
            return Ok(_context.Mindmaps.ToList().Select(Mapper.Map<Mindmap, MindmapDto>));
        }

        public IHttpActionResult GetMindmap(int id)
        {
            var mindmap = _context.Mindmaps.SingleOrDefault(c => c.Id == id);
            if (mindmap == null)
                return NotFound();
            return Ok(Mapper.Map<Mindmap, MindmapDto>(mindmap));
        }

        [HttpPost]
        public IHttpActionResult CreateMindmap(MindmapDto mindmapDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var mindmap = Mapper.Map<MindmapDto, Mindmap>(mindmapDto);
            _context.Mindmaps.Add(mindmap);
            _context.SaveChanges();
            mindmapDto.Id = mindmap.Id;
            return Created(new Uri(Request.RequestUri + "/" + mindmap.Id), mindmapDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMindmap(int id, MindmapDto mindmapDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var mindmapInDb = _context.Mindmaps.SingleOrDefault(c => c.Id == id);
            if (mindmapInDb == null)
                return NotFound();
            Mapper.Map<MindmapDto, Mindmap>(mindmapDto, mindmapInDb);

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMindmap(int id)
        {
            var mindmapInDb = _context.Mindmaps.SingleOrDefault(c => c.Id == id);
            if (mindmapInDb == null)
                return NotFound();
            _context.Mindmaps.Remove(mindmapInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
