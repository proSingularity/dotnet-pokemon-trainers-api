using Microsoft.AspNetCore.Mvc;
using TsttPokemon.Models;
using TsttPokemon.Services;

namespace TsttPokemon.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private readonly PokemonService _service;

    public PokemonController(PokemonService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Pokemon> getAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{index}")]
    public async Task<ActionResult<Pokemon>> getOneAsync(int index)
    {
        var pokemon = await _service.GetByIndexAsync(index);
        if (pokemon is null) return NotFound();
        return pokemon;
    }

}
