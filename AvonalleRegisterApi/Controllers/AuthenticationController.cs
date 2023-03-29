using AutoMapper;
using AvonalleRegisterApi.Domain.Models;
using AvonalleRegisterApi.DTOs;
using AvonalleRegisterApi.Services;
using AvonalleRegisterApi.Services.Interfaces;
using AvonalleRegisterApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AvonalleRegisterApi.Controllers;

public class AuthenticationController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly TokenService _tokenService;

    public AuthenticationController(IMapper mapper, IUserService userService, TokenService tokenService)
    {
        _mapper = mapper;
        _userService = userService;
        _tokenService = tokenService;
    }

    [HttpPost("v1/login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDto model)
    {
        try
        {
            var user = await _userService.LoginAsync(model.Logon, model.Password);
            var mappingUser = _mapper.Map<User>(user);
            if (mappingUser == null)
                return BadRequest(
                    new ResultViewModel<string>("Não foi possível realizar o login, por favor verifique as suas credenciais."));

            var result = new
            {
                mappingUser.Logon,
                token = _tokenService.GenerateToken(mappingUser)
            };
            return Ok(new ResultViewModel<dynamic>(result));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResultViewModel<string>($"Erro interno: {ex.Message}"));
        }
    }
}
