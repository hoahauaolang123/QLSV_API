using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLSV.Data;
using QLSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaoVienController : ControllerBase
    {
        QLSVDBContext _Context;
        public GiaoVienController(QLSVDBContext Context)
        {
            _Context = Context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var GiaoViens = _Context.GiaoVien.ToList();
                if (GiaoViens.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(GiaoViens);
                }
               
            }
            catch (Exception)
            {
                return NoContent();
            }            
        }
        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            try
            {
                var giaoVien = _Context.GiaoVien.Where(x => x.IdGV == Id);
                if(giaoVien == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(giaoVien);
                }
                
            }
            catch (Exception)
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] MGiaoVien request)
        {
            GiaoVien giaoVien = new GiaoVien();
          //  giaoVien.IdGV = request.IdGV;
            giaoVien.MaGV = request.MaGV;
            giaoVien.TenGV = request.TenGV;
            try
            {

               _Context.GiaoVien.Add(giaoVien);
               _Context.SaveChanges();
           

                //   _Context.SaveChanges();

             return CreatedAtAction(
        nameof(GetAll),
        new { id = giaoVien.IdGV },giaoVien);
            }
            catch(Exception)
            {
                return StatusCode(500, "loi");
            }
          
        }
        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] MGiaoVien request)
        {
            try
            {
                var giaoVien = _Context.GiaoVien.FirstOrDefault(x => x.IdGV == Id);
                if (giaoVien == null)
                {
                    return NoContent();
                }
                else
                {
                    giaoVien.MaGV=request.MaGV; ;
                    giaoVien.TenGV=request.TenGV;
                    return Ok(giaoVien);
                }

            }
            catch (Exception)
            {
                return NoContent();
            }
        }
        [HttpDelete("Delete/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var giaoVien = _Context.GiaoVien.FirstOrDefault(x => x.IdGV == Id);
                if (giaoVien == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }
                _Context.Entry(giaoVien).State = EntityState.Deleted;
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "loi");
            }
            var giaoViens= _Context.GiaoVien.ToList();

            return Ok(giaoViens);
        }
    }
   
}
