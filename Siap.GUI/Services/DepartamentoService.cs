using Siap.Shared;
using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly HttpClient _httpClient;
        public DepartamentoService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }
        public async Task<DepartamentoDTO> Buscar(int? id)
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<DepartamentoDTO>>($"api/Departamentos/Buscar/{id}");
            if (result!.EsCorrecto)
                return result.Valor;
            throw new Exception(result.Mensaje);
        }

        public Task<int> Editar(DepartamentoDTO departamentoDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Guardar(DepartamentoDTO departamentoDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Departamentos/Guardar", departamentoDTO);
            var response = await result.Content.ReadFromJsonAsync<responseAPI<int>>();
            if (response!.EsCorrecto)
                return response.Valor;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<List<DepartamentoDTO>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<List<DepartamentoDTO>>>("api/Departamentos/Lista");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
