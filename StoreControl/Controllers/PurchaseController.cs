using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreControl.Infrastructure.Database.Context;
using StoreControl.Infrastructure.Database.DAO.Interfaces;
using StoreControl.Infrastructure.Database.Models;
using StoreControl.Shared.Model;

namespace StoreControl.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseDAO _PurchaseDAO;
        private readonly IMapper _Mapper;

        public PurchaseController(
            IPurchaseDAO pPurchaseDAO,
            IMapper pMapper)
        {
            this._PurchaseDAO = pPurchaseDAO;
            this._Mapper = pMapper;
        }

        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(PurchaseModel[]), 200)]
        public IActionResult Get()
        {
            var data = _PurchaseDAO.Query().Include(pX => pX.CustomerAccount).ToList();
            return Ok(_Mapper.Map<List<PurchaseModel>>(data));
        }

        [HttpGet]
        [ProducesResponseType(typeof(PurchaseModel), 200)]
        public IActionResult GetCustomerAccountData(Guid pPurchaseId)
        {
            var data = _PurchaseDAO.GetByKey(pPurchaseId);
            if (data == null)
                return NotFound();
            return Ok(_Mapper.Map<PurchaseModel>(data));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PurchaseModel), 200)]
        public IActionResult Post([FromBody]PurchaseModel pPurchase)
        {
            var purchase = _Mapper.Map<Purchase>(pPurchase);
            if (purchase.ID != null && purchase.ID != Guid.Empty)
                _PurchaseDAO.Update(purchase);
            else
                _PurchaseDAO.Add(purchase);
            _PurchaseDAO.SaveChanges();
            pPurchase.ID = purchase.ID;
            return Ok(_Mapper.Map<PurchaseModel>(purchase));
        }

        [HttpGet]
        [Route("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count()
        {
            return Ok(_PurchaseDAO.Query().Count());
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(PurchaseModel[]), 200)]
        public IActionResult Search(String pFilter)
        {
            var data = _PurchaseDAO.Query()
                .Include(pX => pX.CustomerAccount).
                Where(pX => pX.Description.Contains(pFilter) || pX.CustomerAccount.Name.Contains(pFilter) ||
                pX.CustomerAccount.CPF.Contains(pFilter)).ToList();
            return Ok(_Mapper.Map<PurchaseModel[]>(data));
        }

        [HttpDelete]
        public IActionResult Delete(Guid pPurchaseId)
        {
            _PurchaseDAO.Delete(pPurchaseId);
            _PurchaseDAO.SaveChanges();
            return Ok();
        }
    }
}