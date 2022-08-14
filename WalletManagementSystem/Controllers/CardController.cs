using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletManagementBL;
using WalletManagementEntity;

namespace WalletManagementSystem.Controllers
{
    [Authorize(Roles ="User")]
    public class CardController : Controller
    {
        private readonly CardBL _cardBL;
        public CardController(CardBL card)
        {
            _cardBL = card;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> GetCard()
        {
            int id = Convert.ToInt32(TempData.Peek("UserId"));
            var data = await _cardBL.GetCard(id);
            return PartialView("GetCard", data);
        }
        
        [HttpGet]
        public async Task<PartialViewResult> AddCard()
        {
            return PartialView("AddCard",new Card());
        }
        [HttpPost]
        public async Task<IActionResult> AddCard(Card card)
        {
            var res = await _cardBL.AddCard(card);
            if (!res)
                ViewBag.Error = "Something went wrong";
            return View("Index");
        }

        public async Task<IActionResult>DeleteCard(int id )
        {
            var res = await _cardBL.DeleteCard(id);
            if (!res)
                ViewBag.Error = "Something went wrong";
            return View("Index");
        }
    }
}
