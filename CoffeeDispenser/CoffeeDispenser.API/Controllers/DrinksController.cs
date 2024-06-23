using CoffeeDispenser.API.Dtos;
using CoffeeDispenser.API.Models;
using CoffeeDispenser.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeDispenser.API.Controllers
{
    /// <summary>
    /// Contrôleur pour gérer les boissons dans le distributeur de café.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkService _drinkService;

        /// <summary>
        /// Constructeur pour DrinksController.
        /// </summary>
        /// <param name="drinkService">Le service responsable des opérations sur les boissons.</param>
        public DrinksController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        /// <summary>
        /// Récupère toutes les boissons.
        /// </summary>
        /// <returns>Une liste de toutes les boissons.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtenir toutes les boissons")]
        [SwaggerResponse(StatusCodes.Status200OK, "Liste des boissons récupérée avec succès.")]
        public async Task<ActionResult<IEnumerable<Drink>>> GetDrinks()
        {
            var drinks = await _drinkService.GetAllDrinksAsync();
            return Ok(drinks);
        }

        /// <summary>
        /// Récupère le prix d'une boisson spécifique par son ID.
        /// </summary>
        /// <param name="id">L'ID de la boisson.</param>
        /// <returns>Le prix de la boisson.</returns>
        [HttpGet("prix/{id}")]
        [SwaggerOperation(Summary = "Obtenir le prix d'une boisson par son ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Prix de la boisson récupéré avec succès.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "La boisson spécifiée n'a pas été trouvée.")]
        public async Task<ActionResult<IEnumerable<Drink>>> GetDrinPrice(int id)
        {
            var drinks = await _drinkService.GetDrinPriceById(id);
            return Ok(drinks);
        }

        /// <summary>
        /// Récupère des informations détaillées sur une boisson spécifique par son ID.
        /// </summary>
        /// <param name="id">L'ID de la boisson.</param>
        /// <returns>Des informations détaillées sur la boisson.</returns>
        [HttpGet("details/{id}")]
        [SwaggerOperation(Summary = "Obtenir les détails d'une boisson par son ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Informations détaillées de la boisson récupérées avec succès.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "La boisson spécifiée n'a pas été trouvée.")]
        public async Task<ActionResult<DrinkDto>> GetDrinkPrice(int id)
        {
            var drink = await _drinkService.GetDrinkWithDetails(id);
            if (drink == null)
            {
                return NotFound();
            }

            return Ok(drink);
        }
    }
}
