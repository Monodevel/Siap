using Siap.Shared;
using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public class EscalafonService : IEscalafonService
    {
        private readonly HttpClient _httpClient;

        public EscalafonService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<EscalafonDTO> Buscar(int? id)
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<EscalafonDTO>>($"api/Escalafones/Buscar/{id}");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

        public Task<int> Editar(EscalafonDTO escalafonDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Guardar(EscalafonDTO escalafonDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Escalafones/Guardar", escalafonDTO);
            var response = await result.Content.ReadFromJsonAsync<responseAPI<int>>();
            if (response!.EsCorrecto)
                return response.Valor;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<List<EscalafonDTO>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<List<EscalafonDTO>>>("api/Escalafones/Lista");
            if (result!.EsCorrecto)
            {
                return result.Valor;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }

        }
    }
}
