using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Moble_List_Application.Data;
using Moble_List_Application.Models;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Moble_List_Application.Controllers
{
    public class MobilesController : Controller
    {
        private readonly MobileDBContext mobileDBContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MobilesController(MobileDBContext _mobileDBContext, IWebHostEnvironment _webHostEnvironment)
        {
            mobileDBContext = _mobileDBContext;
            webHostEnvironment = _webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Mobile_List> mobileList = mobileDBContext.mobile_Lists.ToList();
            return View(mobileList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Mobile_List Moble)
        {
            string webrootpath = webHostEnvironment.WebRootPath;

            var file = HttpContext.Request.Form.Files;

            if (file.Count > 0)
            {
                string newfilename = Guid.NewGuid().ToString();
                var uploade = Path.Combine(webrootpath, @"Images\Mobile");

                var extension = Path.GetExtension(file[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploade, newfilename + extension), FileMode.Create))
                {
                    file[0].CopyTo(filestream);
                }
                Moble.Mobile_logo = @"\Images\Mobile\" + newfilename + extension;
            }
            if (ModelState.IsValid)
            {
                mobileDBContext.mobile_Lists.Add(Moble);
                mobileDBContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = mobileDBContext.mobile_Lists.FirstOrDefault(x => x.id == id);
            if (result == null)
            {
                return NotFound(); // Handle the case where the record with the given id is not found.
            }

            return View(result);
        }

     [HttpPost]
public IActionResult Edit(int id, Mobile_List updatedMobile)
{
    if (id != updatedMobile.id)
    {
        return BadRequest(); // Handle a bad request if the ID doesn't match.
    }

    var existingMobile = mobileDBContext.mobile_Lists.FirstOrDefault(x => x.id == id);
    if (existingMobile == null)
    {
        return NotFound(); // Handle the case where the record with the given id is not found.
    }
            string webrootpath = webHostEnvironment.WebRootPath;

            var file = HttpContext.Request.Form.Files;

            if (file.Count > 0)
            {
                string newfilename = Guid.NewGuid().ToString();
                var uploade = Path.Combine(webrootpath, @"Images\Mobile");

                var extension = Path.GetExtension(file[0].FileName);
                var oldfilepath = Path.Combine(webrootpath, existingMobile .Mobile_logo.Trim('\\'));

                if (System.IO.File.Exists(oldfilepath))
                {
                    System.IO.File.Delete(oldfilepath);
                }

                using (var filestream = new FileStream(Path.Combine(uploade, newfilename + extension), FileMode.Create))
                {
                    file[0].CopyTo(filestream);
                }
                existingMobile.Mobile_logo = @"\Images\Mobile\" + newfilename + extension;
            }

            // Update the properties of the existing Mobile_List with values from the form
            existingMobile.Mobile_name = updatedMobile.Mobile_name;
    existingMobile.Mobile_Brand = updatedMobile.Mobile_Brand;
    existingMobile.Mobile_description = updatedMobile.Mobile_description;

    if (ModelState.IsValid)
    {
        mobileDBContext.mobile_Lists.Update(existingMobile);
        mobileDBContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    return View(existingMobile);
}

        public IActionResult Delete(int id)
        {
            var res = mobileDBContext.mobile_Lists.AsNoTracking().FirstOrDefault(x => x.id == id);
            if (res == null)
            {
                return NotFound(); // Handle the case where the record with the given id is not found.
            }
            string webrootpath = webHostEnvironment.WebRootPath;

            var oldfilepath = Path.Combine(webrootpath, res.Mobile_logo.Trim('\\'));

            if (System.IO.File.Exists(oldfilepath))
            {
                System.IO.File.Delete(oldfilepath);
            }


            mobileDBContext.mobile_Lists.Remove(res);
            mobileDBContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
