using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase {

    private readonly ContextCrud _context;

    public ClientController(ContextCrud context){
        this._context = context;
    }

    [HttpGet()]
    public IActionResult GetClients(){
        try
        {
            var clientes = this._context.Cliente.ToListAsync();
            return Ok(1);
        }
        catch (System.Exception)
        {
            return BadRequest();
            throw;
        }
    }

    [HttpPost()]
    public async Task<IActionResult> CreateClient(Client clients){
        try
        {
            this._context.Add(clients);
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