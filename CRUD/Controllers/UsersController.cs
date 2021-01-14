using CRUD.Models.Context;
using CRUD.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    public class UsersController : Controller
    {
        private readonly Context _context;
        public UsersController(Context context)
        {
            _context = context; /// o próprio core gerencia o instanciamento da classe
        }

        public IActionResult Index()
        {
            var list = _context.User.ToList();
            UserTypeLoad();
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            var user = new User();
            UserTypeLoad();
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.User.Add(user); /// adiciona o usuário no contexto
                _context.SaveChanges(); /// faz o commit

                return RedirectToAction("Index"); /// toda vez que salvar o usuário redireciona para a listagem
            }

            UserTypeLoad();
            return View(user); /// se não for válido, retorna todos os campos para que sejam preenchidos os que faltam
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var user = _context.User.Find(Id);

            UserTypeLoad();
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.User.Update(user);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            
            else
            {
                UserTypeLoad();
                return View(user);
            }
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var user = _context.User.Find(Id);
            UserTypeLoad();
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(User _user)
        {
            var user = _context.User.Find(_user.Id);
            if (user != null)
            {
                _context.User.Remove(user);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(user);
        }


        [HttpGet]
        public IActionResult Details(int Id)
        {
            var user = _context.User.Find(Id);
            UserTypeLoad();
            return View(user);
        }


        public void UserTypeLoad() /// retorna para a tela os tipos de usuário 
        {
            var UserTypeItems = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Administrator"},
                new SelectListItem { Value = "2", Text = "Technician"},
                new SelectListItem { Value = "3", Text = "User"},
            };

            ViewBag.UserTypes = UserTypeItems;
        }
    }
}
