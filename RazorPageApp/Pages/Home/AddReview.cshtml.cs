﻿using GenericServices;
using GenericServices.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.HomeController.Dtos;

namespace RazorPageApp.Pages.Home
{
    public class AddReviewModel : PageModel
    {
        private readonly ICrudServices _service;

        public AddReviewModel(ICrudServices service)
        {
            _service = service;
        }


        [BindProperty]
        public AddReviewDto Data { get; set; }

        public void OnGet(int id)
        {
            Data = _service.ReadSingle<AddReviewDto>(id);
            if (!_service.IsValid)
            {
                _service.CopyErrorsToModelState(ModelState, Data, nameof(Data));
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _service.UpdateAndSave(Data);
            if (_service.IsValid)
                return RedirectToPage("BookUpdated", new { message = _service.Message});

            //Error state
            _service.CopyErrorsToModelState(ModelState, Data, nameof(Data));
            return Page();
        }
    }
}