using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase {

    private readonly ContextCrud _context;
    private readonly IMapper _mapper;

    public ClientController(ContextCrud context, IMapper mapper){
        this._context = context;
        this._mapper = mapper;
    }

    [HttpGet()]
    public async Task<IActionResult> GetClients(){
        try
        {
            var clientes = await this._context.Cliente.ToArrayAsync();
            // var clientInfo = this._mapper.Map<ClientViewModel>(clientes);
            Console.WriteLine(clientes);
            return Ok(clientes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.GetBaseException());

            throw;
        }
    }

    [HttpPost()]
    public async Task<IActionResult> CreateClient(ClientInputModel clients){
        try
        {
            var client = this._mapper.Map<Client>(clients);

            this._context.Add(client);
            var result = await this._context.SaveChangesAsync();
            return Ok(result);
        }
        catch (System.Exception)
        {
            return BadRequest();
            throw;
        }
    }
}