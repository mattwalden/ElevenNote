using ElevenNote.Models.ViewModels;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.Web.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        [Authorize]
        public ActionResult Index()
        {

            if (TempData["Result"] != null)
            {
                ViewBag.Success = TempData["Result"];
                TempData.Remove("Result");
            }
            
            var noteService = new ElevenNote.Services.NoteService();
            var notes = noteService.GetAllForUser(Guid.Parse(User.Identity.GetUserId()));

            return View(notes);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateGet()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(NoteEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var noteService = new NoteService();
                var userId = Guid.Parse(User.Identity.GetUserId());
                var result = noteService.Create(model, userId);
                TempData.Remove("Result");
                TempData.Add("Result", result ? "Note added." : "Note not added.");
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditGet(int id )
        {
            var noteService = new NoteService();
            var userId = Guid.Parse(User.Identity.GetUserId());
            
            var note = noteService.GetById(id, userId);



            return View(note);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(NoteEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var noteService = new NoteService();
                var userId = Guid.Parse(User.Identity.GetUserId());
                var result = noteService.Update(model, userId);
                TempData.Add("Result", result ? "Note updated." : "Note not updated.");
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
           
                var noteService = new NoteService();
                var userId = Guid.Parse(User.Identity.GetUserId());
                var result = noteService.Delete(id, userId);
            TempData.Remove("Result");
            TempData.Add("Result", result ? "Note Deleted." : "Note not Deleted.");
                return RedirectToAction("Index");
           
            
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            var noteService = new NoteService();
            var userId = Guid.Parse(User.Identity.GetUserId());

            var note = noteService.GetById(id, userId);



            return View(note);


        }
        // Validate Input false Allows CKEDIT To Work 
        [ValidateInput(false)]
        [HttpGet]
        [ActionName("Details")]
        public ActionResult DetailsGet(int id)
        {
            var noteService = new NoteService();
            var userId = Guid.Parse(User.Identity.GetUserId());

            var note = noteService.GetById(id, userId);



            return View(note);
        }

       

    }





}