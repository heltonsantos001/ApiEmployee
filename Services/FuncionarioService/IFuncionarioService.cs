using WebApiVideo.Model;

namespace WebApiVideo.Services.FuncionarioService
{
    public interface IFuncionarioService
    {
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario();
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);
        Task<ServiceResponse<FuncionarioModel>> GetById(int id);
        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel FuncionarioNovo);
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFucionario(int id);
        Task<ServiceResponse<List<FuncionarioModel>>> InativoFuncionario(int id);
    }
}
