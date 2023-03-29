using AvonalleRegisterApi.DTOs;
using AvonalleRegisterApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvonalleRegisterApi.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpPost("v1/user")]
        public async Task<IActionResult> PostAsync([FromBody] UserDto model)
        {
            try
            {
                var response = await _userService.PostAsync(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar inserir um novo usuário: {ex.Message}");
            };
        }
    }
}
