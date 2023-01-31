﻿using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\Uploads\\Images\\a.png";
        private string _defaultPath = _currentDirectory + _folderName;
        private ICarImageService _carImagesService;
        public CarImagesController(ICarImageService serviceBase)
        {
            _carImagesService = serviceBase;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return GetResponseByResult(_carImagesService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return GetResponseByResult(_carImagesService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImages)
        {
            return GetResponseByResult(_carImagesService.Insert(file, carImages));
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImages)
        {
            return GetResponseByResult(_carImagesService.Update(file, carImages));
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm] int id)
        {
            var entity = _carImagesService.GetById(id);
            return GetResponseByResult(_carImagesService.Delete(entity.Data));
        }

        public IActionResult GetResponseByResult(IResult result)
        {
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
