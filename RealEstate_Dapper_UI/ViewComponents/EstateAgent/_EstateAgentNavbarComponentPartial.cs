using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentNavbarComponentPartial:ViewComponent
    {
        private readonly ILoginService _loginService;

        public _EstateAgentNavbarComponentPartial(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Username = _loginService.getUserName;
            return View();
        }
    }
}
