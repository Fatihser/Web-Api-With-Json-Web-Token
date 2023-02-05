﻿using FSEJwtApp.Front.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace FSEJwtApp.Front.Controllers
{
	public class AccountController : Controller
	{
		private readonly IHttpClientFactory httpClientFactory;

		public AccountController(IHttpClientFactory httpClientFactory)
		{
			this.httpClientFactory = httpClientFactory;
		}

		public IActionResult Login()
		{
			return View(new UserLoginModel());
		}

		[HttpPost]
		public async Task<IActionResult> Login(UserLoginModel model)
		{
			if (ModelState.IsValid)
			{
				var client=this.httpClientFactory.CreateClient();

				var content = new StringContent(JsonSerializer.Serialize(
					model),Encoding.UTF8,"application/json");

				var response=await client.PostAsync("http://localhost:5149/api/Auth/Login",content);
				if (response.IsSuccessStatusCode)
				{
					var jsonData = await response.Content.ReadAsStringAsync();
					var tokenModel=JsonSerializer.Deserialize<JwtTokenResponseModel>(jsonData,
						new JsonSerializerOptions
						{
							PropertyNamingPolicy=JsonNamingPolicy.CamelCase
						});

					if (tokenModel!=null)
					{
						JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
						var token = handler.ReadJwtToken(tokenModel.Token);

						var claims = token.Claims.ToList();
						if (tokenModel.Token!=null)
						{
							claims.Add(new Claim("accesToken", tokenModel.Token));
						}
						var claimsIdentity = new ClaimsIdentity(claims,
							JwtBearerDefaults.AuthenticationScheme);

						var authProps = new AuthenticationProperties
						{
							ExpiresUtc = tokenModel.ExpireDate,
							IsPersistent = true,
						};

						await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,
							new ClaimsPrincipal(claimsIdentity),authProps);

						return RedirectToAction("Index", "Home");
					}
				}
				else
				{
					ModelState.AddModelError("", "Kullanici adi veya sifre hatali.");
				}
			}
			return View(model);
		}
	}
}
