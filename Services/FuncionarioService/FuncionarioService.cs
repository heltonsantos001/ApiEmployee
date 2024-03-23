using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApiVideo.DataContext;
using WebApiVideo.Model;

namespace WebApiVideo.Services.FuncionarioService
{
    public class FuncionarioService : IFuncionarioService
    {

        private readonly DBContext _context;

        public FuncionarioService(DBContext context)
        {
            this._context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                if (novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "informe os dados";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionario.ToList();



            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFucionario(int id)
        {

            ServiceResponse<List<FuncionarioModel>> serviceResponse = new();

            try 
            { 
                FuncionarioModel funcionario = _context.Funcionario.FirstOrDefault(x => x.Id == id);

                if (funcionario == null) 
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "usuario nao encontrado";
                    serviceResponse.Sucesso = false;
                }

                _context.Funcionario.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionario.ToList();


            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetById(int id)
        {


            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();
            try
            {

                FuncionarioModel funcionario = _context.Funcionario.FirstOrDefault(x => x.Id == id);
                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionario nao encontrado";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = funcionario;



            }
            catch (Exception)
            {
                serviceResponse.Mensagem = "Falha ao encontrar usuario";
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario()
        {

            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceResponse.Dados = _context.Funcionario.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum usuario encontrado";
                    serviceResponse.Sucesso = false;
                }


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<FuncionarioModel>>> InativoFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionario.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "usuario nao encontrado";
                    serviceResponse.Sucesso = false;
                    
                }

                funcionario.Ativo = false;
                funcionario.DataAlteracao = DateTime.Now.ToLocalTime();
                _context.Update(funcionario);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Funcionario.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel FuncionarioNovo)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new();
            try
            {
                FuncionarioModel funcionario = _context.Funcionario.AsNoTracking().FirstOrDefault(x => x.Id == FuncionarioNovo.Id);

                if(funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "usuario nao encontrado";
                    serviceResponse.Sucesso = false;
                }

                _context.Funcionario.Update(FuncionarioNovo);
               await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionario.ToList();
            
            } catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
