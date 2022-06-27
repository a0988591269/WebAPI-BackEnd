using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Result;
using System;
using System.IO;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EFContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(EFContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var result = new Result();

            try
            {
                result.IsSuccess = true;
                result.Data = _dbContext.Employee.AsQueryable();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return new JsonResult(result);
        }

        [HttpPost]
        public JsonResult Post(Employee model)
        {
            var result = new Result();

            try
            {
                result.IsSuccess = true;
                result.Message = "新增成功";
                result.Data = model;
                _dbContext.Employee.Add(model);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "新增失敗";
            }

            return new JsonResult(result);
        }

        [HttpPut]
        public JsonResult Update(Employee model)
        {
            var result = new Result();

            try
            {
                var query = _dbContext.Employee.FirstOrDefault(x => x.EmployeeId == model.EmployeeId);

                if (query != null)
                {
                    result.IsSuccess = true;
                    result.Message = "更新成功";
                    result.Data = model;

                    query.EmployeeName = model.EmployeeName;
                    query.Department = model.Department;
                    query.DateOfJoin = model.DateOfJoin;
                    query.PhotoFileName = model.PhotoFileName;

                    _dbContext.Employee.Update(query);
                    _dbContext.SaveChanges();
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "查無資料";
                    result.Data = model;
                    return new JsonResult(result);
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "更新失敗";
            }

            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = new Result();

            try
            {
                var query = _dbContext.Employee.FirstOrDefault(x => x.EmployeeId == id);

                if (query != null)
                {
                    result.IsSuccess = true;
                    result.Message = "刪除成功";
                    result.Data = query;

                    _dbContext.Employee.Remove(query);
                    _dbContext.SaveChanges();
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "查無資料";
                    return new JsonResult(result);
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "刪除失敗";
            }

            return new JsonResult(result);
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postFile = httpRequest.Files[0];
                string filename = postFile.FileName;
                var physicalPath = $"{_env.ContentRootPath}/Photos/{filename}";

                using (var fs = new FileStream(physicalPath, FileMode.Create))
                {
                    postFile.CopyTo(fs);
                }

                return new JsonResult(filename);
            }
            catch (Exception ex)
            {

                return new JsonResult("anonymous.png");
            }
        }

        [Route("GetAllDepartment")]
        [HttpGet]
        public JsonResult GetAllDepartment()
        {
            var result = new Result();

            try
            {
                result.IsSuccess = true;
                result.Data = _dbContext.Department.AsQueryable();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return new JsonResult(result);
        }
    }
}
