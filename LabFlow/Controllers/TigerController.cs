using LabFlow.Application.Interfaces;
using LabFlow.Application.ViewModels;
using LabFlow.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LabFlow.Controllers
{
    [Authorize]
    public class TigerController : BaseController
    {
        private readonly ITigerAppService _tigerAppService;

        public TigerController(ITigerAppService tigerAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _tigerAppService = tigerAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("tiger-management/list-all")]
        public IActionResult Index()
        {
            return View(_tigerAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("tiger-management/tiger-details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tigerViewModel = _tigerAppService.GetById(id.Value);

            if (tigerViewModel == null)
            {
                return NotFound();
            }

            return View(tigerViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteTigerData")]
        [Route("tiger-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteTigerData")]
        [Route("tiger-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TigerViewModel tigerViewModel)
        {
            if (!ModelState.IsValid) return View(tigerViewModel);
            _tigerAppService.Register(tigerViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Tiger Registered!";

            return View(tigerViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteTigerData")]
        [Route("tiger-management/edit-tiger/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tigerViewModel = _tigerAppService.GetById(id.Value);

            if (tigerViewModel == null)
            {
                return NotFound();
            }

            return View(tigerViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteTigerData")]
        [Route("tiger-management/edit-tiger/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TigerViewModel tigerViewModel)
        {

            if (!ModelState.IsValid) return View(tigerViewModel);
            //Just example 
            FootballViewModel footballViewModel = new FootballViewModel();
            footballViewModel.Loss = 0;
            _tigerAppService.PlayFootball(tigerViewModel,footballViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Updated!";

            return View(tigerViewModel);
        }

        [AllowAnonymous]
        [Route("tiger-management/tiger-history/{id:guid}")]
        public JsonResult History(Guid id)
        {
            var tigerHistoryData = _tigerAppService.GetAllHistory(id);
            return Json(tigerHistoryData);
        }
    }
}
