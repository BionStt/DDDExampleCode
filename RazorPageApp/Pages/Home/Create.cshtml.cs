﻿using GenericServices;
using GenericServices.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.HomeController.Dtos;

namespace RazorPageApp.Pages.Home
{
    public class CreateModel : PageModel
    {
        private readonly ICrudServices _service;

        public CreateModel(ICrudServices service)
        {
            _service = service;
        }

        [BindProperty]
        public CreateBookDto Data { get; set; }

        public void OnGet()
        {
            Data = new CreateBookDto();
            Data.BeforeDisplay(_service.Context);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Data.BeforeDisplay(_service.Context);
                return Page();
            }
            //Now I need to set up the Authors collection before calling create
            Data.BeforeSave(_service.Context);
            _service.CreateAndSave(Data);
            if (_service.IsValid)
                return RedirectToPage("BookUpdated", new { message = _service.Message});

            //Error state
            _service.CopyErrorsToModelState(ModelState, Data, nameof(Data));
            Data.BeforeDisplay(_service.Context);
            return Page();
        }
    }
}