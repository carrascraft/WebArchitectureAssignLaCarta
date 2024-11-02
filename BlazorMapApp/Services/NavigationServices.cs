using System.Collections.Generic;

namespace BlazorMapApp.Services
{
    public class NavigationStateService
    {
        // Diccionario para almacenar el hash permitido por cada restaurante
        private readonly Dictionary<int, string> _restaurantHashes = new();

        // Método para establecer el hash permitido para un restaurante específico
        public void SetAllowedHash(int restaurantId, string hash)
        {
            _restaurantHashes[restaurantId] = hash;
        }

        // Método para verificar si el hash es el permitido para el restaurante específico
        public bool IsAllowedHash(int restaurantId, string hash)
        {
            return _restaurantHashes.ContainsKey(restaurantId) && _restaurantHashes[restaurantId] == hash;
        }

        // Método para resetear el hash de un restaurante específico
        public void Reset(int restaurantId)
        {
            if (_restaurantHashes.ContainsKey(restaurantId))
            {
                _restaurantHashes.Remove(restaurantId);
            }
        }
    }
}
