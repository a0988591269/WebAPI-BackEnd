using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Result;
using System;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly EFContext _dbContext;

        public DepartmentController(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public JsonResult Get()
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

        [HttpPost]
        public JsonResult Post(Department model)
        {
            var result = new Result();

            try
            {
                result.IsSuccess = true;
                result.Message = "新增成功";
                result.Data = model;
                _dbContext.Department.Add(model);
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
        public JsonResult Update(Department model)
        {
            var result = new Result();

            try
            {
                var query = _dbContext.Department.FirstOrDefault(x => x.DepartmentId == model.DepartmentId);

                if (query != null)
                {
                    result.IsSuccess = true;
                    result.Message = "更新成功";
                    result.Data = model;

                    query.DepartmentName = model.DepartmentName;

                    _dbContext.Department.Update(query);
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
                var query = _dbContext.Department.FirstOrDefault(x => x.DepartmentId == id);

                if (query != null)
                {
                    result.IsSuccess = true;
                    result.Message = "刪除成功";
                    result.Data = query;

                    _dbContext.Department.Remove(query);
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
    }
}
