using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientNotifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvcdemo.Data;
using mvcdemo.Models;
using mvcdemo.Repository;
using static ClientNotifications.Helpers.NotificationHelper;

namespace mvcdemo.Controllers
{
    public class PetController : Controller
    {
        private IPetRepository _petRepository;
        private UserManager<ApplicationUser> _userManger;
        private IClientNotification _clientNotification;
        public PetController(IClientNotification clientNotification,
                                IPetRepository petRepository,
                                UserManager<ApplicationUser> userManager)
        {
            _petRepository = petRepository;
            _clientNotification = clientNotification;
            _userManger = userManager;
        }

        public IActionResult Index(string search = null)
        {
            if(!string.IsNullOrEmpty(search)){
                var foundPets = _petRepository.SearchPets(search);
                return View(foundPets);
            }

            var pets = _petRepository.GetAllPets();
            return View(pets);
        }

        [Authorize]
        public IActionResult MyPets(){
            var userId = _userManger.GetUserId(HttpContext.User);
            var pets = _petRepository.GetPetByUserId(userId);
            return View(pets);
        }

        public IActionResult Details(int id)
        {
            var pet = _petRepository.GetSinglePet(id);
            return View(pet);
        }

        [HttpGet]
        [Authorize]
        public IActionResult New()
        {
            ViewBag.IsEditMode = "false";
            var pet = new Pet();
            return View(pet);
        }

        [HttpPost]
        [Authorize]
        public IActionResult New(Pet pet, string IsEditMode)
        {
            if(!ModelState.IsValid){
                ViewBag.IsEditMode = IsEditMode;
                return View(pet);
            }
            try
            {
                var userId = _userManger.GetUserId(this.HttpContext.User);
                pet.UserId = userId;

                if (IsEditMode.Equals("false"))
                {
                    _petRepository.Create(pet);

                    _clientNotification.AddSweetNotification("Success",
                                 "Your pet is created!",
                                 NotificationType.success);
                }
                else
                {
                    _petRepository.Edit(pet);
                    _clientNotification.AddSweetNotification("Success",
                                 "Your pet has been edited!",
                                 NotificationType.success);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _clientNotification.AddSweetNotification("Error",
                                 "Your pet could not be created or edited!",
                                 NotificationType.error);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var loggedInUserId = _userManger.GetUserId(HttpContext.User);

                ViewBag.IsEditMode = "true";

                var pet = _petRepository.GetSinglePet(Id);

                if(!pet.UserId.Equals(loggedInUserId))
                {
                    return Content("You are not authorized for this action");
                }

                return View("New", pet);
            }
            catch (Exception ex)
            {
                return Content("Could  not find the pet");
            }
        }

        public IActionResult Delete(int Id)
        {
            try
            {
                var pet = _petRepository.GetSinglePet(Id);
                _petRepository.Delete(pet);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IActionResult VerifyName(string name){
            if(_petRepository.VerifyName(name)){
                return Json($"The pet with name {name} already exists in database. Please try another name");
            }

            return Json(true);
        }

        public IActionResult AutocompleteResult(string search){
            return Json(_petRepository.SearchPets(search));
        }
    }
}