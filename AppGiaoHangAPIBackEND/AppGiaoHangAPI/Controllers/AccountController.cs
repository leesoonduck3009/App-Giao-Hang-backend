﻿using AppGiaoHangAPI.Interface.IRepository;
using AppGiaoHangAPI.Model.HelperModel;
using AppGiaoHangAPI.Model.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppGiaoHangAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountRepository accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [HttpGet("", Name = "GetAllAccount")]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult<ResponeInfo>> getAllAccount()
        {
            ResponeInfo responeInfo = new ResponeInfo();
            try
            {
                responeInfo.statusCode = System.Net.HttpStatusCode.OK;
                Stream a = HttpContext.Request.Body;
                ErrorMessageInfo error = await accountRepository.getAllAccount();
                if (error.isErrorEx || !error.isSuccess)
                {

                    responeInfo.error_code = error.error_code;
                    responeInfo.message = error.message;
                    return BadRequest(responeInfo);
                }
                responeInfo.data = error.data;
                return await Task.FromResult(responeInfo);
            }
            catch (Exception ex)
            {
                responeInfo.statusCode = System.Net.HttpStatusCode.InternalServerError;
                responeInfo.message = ex.Message;
                return BadRequest(responeInfo);
            }
        }
        [HttpPost("", Name = "PostNewAccount")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ResponeInfo>> createNewAccount(List<Account> accounts)
        {
            ResponeInfo responeInfo = new ResponeInfo();
            try
            {
                responeInfo.statusCode = System.Net.HttpStatusCode.OK;
                Stream a = HttpContext.Request.Body;
                ErrorMessageInfo error = await accountRepository.createNewAccount(accounts);
                if (error.isErrorEx || !error.isSuccess)
                {

                    responeInfo.error_code = error.error_code;
                    responeInfo.message = error.message;
                    return BadRequest(responeInfo);
                }
                responeInfo.data = error.data;
                return await Task.FromResult(responeInfo);
            }
            catch (Exception ex)
            {
                responeInfo.statusCode = System.Net.HttpStatusCode.InternalServerError;
                responeInfo.message = ex.Message;
                return BadRequest(responeInfo);
            }
        }
        [HttpGet("{id}", Name = "GetAccountByID")]
        [Authorize]
        public async Task<ActionResult<ResponeInfo>> getAccountByID(long id)
        {
            ResponeInfo responeInfo = new ResponeInfo();
            try
            {
                responeInfo.statusCode = System.Net.HttpStatusCode.OK;
                Stream a = HttpContext.Request.Body;
                ErrorMessageInfo error = await accountRepository.getAccountByID(id);
                if (error.isErrorEx || !error.isSuccess)
                {

                    responeInfo.error_code = error.error_code;
                    responeInfo.message = error.message;
                    return BadRequest(responeInfo);
                }
                responeInfo.data = error.data;
                return await Task.FromResult(responeInfo);
            }
            catch (Exception ex)
            {
                responeInfo.statusCode = System.Net.HttpStatusCode.InternalServerError;
                responeInfo.message = ex.Message;
                return BadRequest(responeInfo);
            }
        }
        [HttpPut("", Name = "UpdateAccount")]
        [Authorize(Roles = "admin")]

        public async Task<ActionResult<ResponeInfo>> updateAccount(List<Account> accounts)
        {
            ResponeInfo responeInfo = new ResponeInfo();
            try
            {
                responeInfo.statusCode = System.Net.HttpStatusCode.OK;
                Stream a = HttpContext.Request.Body;
                ErrorMessageInfo error = await accountRepository.updateAccount(accounts);
                if (error.isErrorEx || !error.isSuccess)
                {

                    responeInfo.error_code = error.error_code;
                    responeInfo.message = error.message;
                    return BadRequest(responeInfo);
                }
                responeInfo.data = error.data;
                return Ok(responeInfo);
            }
            catch (Exception ex)
            {
                responeInfo.statusCode = System.Net.HttpStatusCode.InternalServerError;
                responeInfo.message = ex.Message;
                return BadRequest(responeInfo);
            }
        }
        [HttpPost("change-password", Name = "ChangePasswordAccount")]
        public async Task<ActionResult<ResponeInfo>> changePassword( Account account)
        {
            ResponeInfo responeInfo = new ResponeInfo();
            try
            {
                responeInfo.statusCode = System.Net.HttpStatusCode.OK;
                Stream a = HttpContext.Request.Body;
                ErrorMessageInfo error = await accountRepository.changePassword(account);
                if (error.isErrorEx || !error.isSuccess)
                {

                    responeInfo.error_code = error.error_code;
                    responeInfo.message = error.message;
                    return BadRequest(responeInfo);
                }
                responeInfo.data = error.data;
                return Ok(responeInfo);
            }
            catch (Exception ex)
            {
                responeInfo.statusCode = System.Net.HttpStatusCode.InternalServerError;
                responeInfo.message = ex.Message;
                return BadRequest(responeInfo);
            }
        }
        [HttpDelete("", Name = "DeleteAccount")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ResponeInfo>> deleteAccount(List<Account> accounts)
        {
            ResponeInfo responeInfo = new ResponeInfo();
            try
            {
                responeInfo.statusCode = System.Net.HttpStatusCode.OK;
                Stream a = HttpContext.Request.Body;
                ErrorMessageInfo error = await accountRepository.deleteAccount(accounts);
                if (error.isErrorEx || !error.isSuccess)
                {
                    responeInfo.error_code = error.error_code;
                    responeInfo.message = error.message;
                    return BadRequest(responeInfo);
                }
                responeInfo.data = error.data;
                return Ok(responeInfo);
            }
            catch (Exception ex)
            {
                responeInfo.statusCode = System.Net.HttpStatusCode.InternalServerError;
                responeInfo.message = ex.Message;
                return BadRequest(responeInfo);
            }
        }
    }
}
