﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC98.Software.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CC98.Software.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index( [FromServices] SoftwareDbContext q)
        {
            Data.Category[] m;
            var result = from i in q.Categories select i;
            m = result.ToArray();
            return View(m); ;
        }

        public IActionResult desktop()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Upload(UploadWare m, [FromServices] SoftwareDbContext q)
        {
            System.IO.FileStream a = System.IO.File.OpenWrite(System.IO.Path.Combine("File", m.File.FileName));
            m.File.CopyTo(a);
            System.IO.FileStream b = System.IO.File.OpenWrite(System.IO.Path.Combine("File", m.File.FileName));
            m.Photo.CopyTo(b);
            //新开空文件 返回文件流 将IFormFile格式文件转为FileStream存入本地服务器
            Data.Software newfile = new Data.Software
            {

                Introduction = m.Introduction,
                Platform = m.Platform,
                Size = m.File.Length,
                FileLocation = System.IO.Path.Combine("File", m.File.FileName),
                PhotoLocation = System.IO.Path.Combine("File", m.Photo.FileName),
                UpdateTime = DateTimeOffset.Now,
                DownloadNum = 0,
            };


            q.Softwares.Add(newfile);
            return View();
        }

        public IActionResult game()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult android()
        {
            return View();
        }

        public IActionResult apple()
        {
            return View();
        }

        public IActionResult houtai([FromServices] SoftwareDbContext q)
        {
            Data.Software[] m;
            var result = from i in q.Softwares select i;
            m = result.ToArray();
            return View(m); ;
        }

        public IActionResult UnAccepted(int id, [FromServices] SoftwareDbContext q)
        {
            Data.Software m;
            m = q.Softwares.Find(id);
            if (m == null)
            {
                return NotFound();
            }
            else
            {
                q.Softwares.Remove(m);
            }
            return RedirectToAction("houtai");
        }

        public IActionResult Accepted(int id, [FromServices] SoftwareDbContext q)
        {
            Data.Software m;
            m = q.Softwares.Find(id);
            if (m == null)
            {
                return NotFound();
            }
            else
            {
                m.IsAccepted = true;
            }
            return RedirectToAction("houtai");
        }

        public IActionResult NewCategory(string name, [FromServices] SoftwareDbContext q)
        {
            Data.Category m = new Category();
            m.Name = name;
            return RedirectToAction("houtai");
        }

        public IActionResult Delete(int id, [FromServices] SoftwareDbContext q)
        {
            Category m;
            m = q.Categories.Find(id);
            if (m == null)
            {
                return NotFound();
            }
            else
            {
                q.Categories.Remove(m);
            }
            return RedirectToAction("CategoryManagement");
        }

        public IActionResult CategoryManagement([FromServices] SoftwareDbContext q)
        {
            Category[] m;          
            var result = from i in q.Categories  select i;
            m = result.ToArray();
            return View(m); ;
        }

        public IActionResult New2Category(string name, int id, [FromServices] SoftwareDbContext q)
        {
            Data.Category m = new Category();
            Data.Category n;
            n = q.Categories.Find(id);
            m.Name = name;
            m.Parent = n;
            return RedirectToAction("houtai");
        }
    }
}
