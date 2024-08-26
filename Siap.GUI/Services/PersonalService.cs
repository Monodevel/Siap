using Siap.Shared;
using Siap.Shared.DTO;

namespace Siap.GUI.Services
{
    public class PersonalService : IPersonalService
    {
        private readonly HttpClient _httpClient;

        public PersonalService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<PersonalDTO> Buscar(int? id)
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<PersonalDTO>>($"api/Personal/Buscar/{id}");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<PersonalDTO> DetallePersonal(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<PersonalDTO>>($"api/Personal/DetallePersonal/{id}");
            if (result!.EsCorrecto)
                return result.Valor;
            else
                throw new Exception(result.Mensaje);
        }

        public Task<int> Editar(PersonalDTO personalDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Guardar(PersonalDTO personalDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Personal/Guardar", personalDTO);
            var response = await result.Content.ReadFromJsonAsync<responseAPI<int>>();
            if (response!.EsCorrecto)
                return response.Valor;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<List<PersonalDTO>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<responseAPI<List<PersonalDTO>>>("api/Personal/Lista");
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
