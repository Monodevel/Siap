using Siap.Shared;
using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public class PerfilProfesionalService : IPerfilProfesionalService
    {
        private readonly HttpClient _httpClient;

        public PerfilProfesionalService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }
        public async Task<PerfilProfesionalDTO> BuscarPersonal(int? idPersonal)
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<PerfilProfesionalDTO>>($"api/PerfilProfesional/BuscarPersonal/{idPersonal}");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

        public Task<int> Guardar(PerfilProfesionalDTO perfilProfesionalDTO)
        {
            throw new NotImplementedException();
        }

        public Task<List<PerfilProfesionalDTO>> Lista()
        {
            throw new NotImplementedException();
        }
    }
}
