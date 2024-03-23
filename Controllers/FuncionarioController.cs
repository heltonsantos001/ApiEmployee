using Microsoft.AspNetCore.Mvc;
using WebApiVideo.Model;
using WebApiVideo.Services.FuncionarioService;

namespace WebApiVideo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioInterface;
        public FuncionarioController(IFuncionarioService FuncionarioInterface)
        {
            this._funcionarioInterface = FuncionarioInterface;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
            return Ok(await _funcionarioInterface.GetFuncionario());
        }


        [HttpGet("getById/{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int id) 
        {
            ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioInterface.GetById(id);
            return Ok(serviceResponse);
        }


        [HttpPost("create")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
        }


        [HttpPatch("inactivateEmployee")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativarFuncionario(int id)
        {

            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.InativoFuncionario(id);
            
            return Ok(serviceResponse);
        }


        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel FuncionarioNovo) 
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.UpdateFuncionario(FuncionarioNovo);

            return Ok(serviceResponse);
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.DeleteFucionario(id);

            return Ok(serviceResponse);
        }

    }
}
