using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreControl.Infrastructure.Database.Context;
using StoreControl.Infrastructure.Database.DAO.Interfaces;
using StoreControl.Infrastructure.Database.Models;
using StoreControl.Shared.Model;

namespace StoreControl.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerAccountController : Controller
    {
        private readonly ICustomerAccountDAO _CustomerAccountDAO;
        private readonly IMapper _Mapper;

        public CustomerAccountController(
            ICustomerAccountDAO pCustomerAccountDAO,
            IMapper pMapper)
        {
            this._CustomerAccountDAO = pCustomerAccountDAO;
            this._Mapper = pMapper;
        }

        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(CustomerAccountModel[]), 200)]
        public IActionResult Get()
        {
            var data = _CustomerAccountDAO.Query().Where(pX => pX.Status == Shared.Enum.Status.Enable);
            return Ok(_Mapper.Map<List<CustomerAccountModel>>(data));
        }

        [HttpGet]
        [ProducesResponseType(typeof(CustomerAccountModel), 200)]
        public IActionResult GetCustomerAccountData(Guid pCustomerAccountId)
        {
            var data = _CustomerAccountDAO.GetByKey(pCustomerAccountId);
            if (data == null)
                return NotFound();
            return Ok(_Mapper.Map<CustomerAccountModel>(data));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerAccountModel), 200)]
        public IActionResult Post([FromBody]CustomerAccountModel pCustomerAccount)
        {
            var customerAccount = _Mapper.Map<CustomerAccount>(pCustomerAccount);
            if (customerAccount.ID != null && customerAccount.ID != Guid.Empty)
                _CustomerAccountDAO.Update(customerAccount);
            else
                _CustomerAccountDAO.Add(customerAccount);
            _CustomerAccountDAO.SaveChanges();
            pCustomerAccount.ID = customerAccount.ID;
            return Ok(_Mapper.Map<CustomerAccountModel>(customerAccount));
        }

        [HttpGet]
        [Route("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count()
        {
            return Ok(_CustomerAccountDAO.Query().Where(pX => pX.Status == Shared.Enum.Status.Enable).Count());
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(CustomerAccountModel[]), 200)]
        public IActionResult Search(String pFilter)
        {
            var data = _CustomerAccountDAO.Query().Where(pX => pX.Status == Shared.Enum.Status.Enable && pX.Name.Contains(pFilter) || pX.CPF.Contains(pFilter)).ToList();
            return Ok(_Mapper.Map<CustomerAccountModel[]>(data));
        }

        [HttpDelete]
        public IActionResult Delete(Guid pCustomerAccountId)
        {
            _CustomerAccountDAO.Delete(pCustomerAccountId);
            _CustomerAccountDAO.SaveChanges();
            return Ok();
        }
    }
}