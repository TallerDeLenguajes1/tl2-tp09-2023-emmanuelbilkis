using Kanban.Models;
using Kanban.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Kanban.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
     
        private readonly ILogger<UsuarioController> _logger;
       
        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("api/agregarUsuario")]
        public ActionResult AgregarUsuario(Usuario usuario)
        {
            try
            {
                IUsuarioRepository usuarioRepository = new UsuarioRepository(); 
                usuarioRepository.Create(usuario);
                return Ok("Se creo con exito");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("Error al crear el post");
            }
        }

        [HttpGet]
        [Route("api/ObtenerUsuarios")]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            try 
            {
                IUsuarioRepository usuarioRepository = new UsuarioRepository();
                var usuarios = usuarioRepository.GetAll();
                return Ok(usuarios);
            }
            catch(Exception)
            {
                return BadRequest("Error al intentar traer los usuarios");
            }
        }

        [HttpGet]
        [Route("api/ObtenerPorId")]
        public ActionResult<Usuario> ObtenerPorId(int id) 
        {
            try
            {
                IUsuarioRepository usuarioRepository = new UsuarioRepository();
                var usu = usuarioRepository.GetById(id);
                return Ok(usu);
            }
            catch (Exception)
            {
                return BadRequest("Error al intentar traer el usuario");
            }
        }

        [HttpDelete]
        [Route("api/BorrarUsuario")]
        public ActionResult Borrar(int id)
        {
            try
            {
                IUsuarioRepository usuarioRepository = new UsuarioRepository();
                usuarioRepository.Remove(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error al borrar");
            }
        }

        [HttpPut]
        [Route("api/ActualizarUsuario")]
        public ActionResult UpdateUsuario(Usuario usu)
        {
            try
            {
                IUsuarioRepository usuarioRepository = new UsuarioRepository();
                usuarioRepository.Update(usu);
                return Ok(usu);
            }
            catch (Exception)
            {
                return BadRequest("Error al actualizar");
            }
        }
    }
}