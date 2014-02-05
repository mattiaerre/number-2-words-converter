using System;
using System.Web.Mvc;
using N2W.CORE.Services;

namespace N2W.WEB.Controllers
{
  public class HomeController : Controller
  {
    private readonly INumberToWordsService _service;

    public HomeController(INumberToWordsService service)
    {
      _service = service;
    }

    public ActionResult Index()
    {
      return View();
    }

    public string GetWords(int number)
    {
      try
      {
        return _service.GetWords(number);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }
  }
}