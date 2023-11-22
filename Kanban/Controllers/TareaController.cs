using Kanban.Models;
using Kanban.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers
{
    public class TareaController : Controller
    {
        [HttpPost]
        [Route("tarea/crear")]
        public ActionResult Agregar(Tarea tarea)
        {
            try
            {
                ITareaRepositorio tareaRepositorio = new TareaRepositorio();    
                tareaRepositorio.Create(tarea);
                return Ok("Se creo con exito");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("Error al crear");
            }
        }

        [HttpGet]
        [Route("tarea/listarPorUsu")]
        public ActionResult<IEnumerable<Tarea>> ListarPorUsuario(int idUsu)
        {
            try
            {
                ITareaRepositorio tareaRepositorio = new TareaRepositorio();
                var lista = tareaRepositorio.ListarPorUsuario(idUsu);
                return Ok(lista);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("Error");
            }
        }

        [HttpGet]
        [Route("tarea/listarPorTablero")]
        public ActionResult<IEnumerable<Tarea>> ListarPorTablero(int idTab)
        {
            try
            {
                ITareaRepositorio tareaRepositorio = new TareaRepositorio();
                var lista = tareaRepositorio.ListarPorTablero(idTab);
                return Ok(lista);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("Error");
            }
        }

        [HttpGet]
        [Route("tarea/Obtener")]
        public ActionResult<IEnumerable<Tarea>> GetTareas()
        {
            try
            {
                ITareaRepositorio tareaRepositorio = new TareaRepositorio();
                var tareas = tareaRepositorio.GetAll();
                return Ok(tareas);
            }
            catch (Exception)
            {
                return BadRequest("Error al intentar traer las tareas");
            }
        }

        [HttpGet]
        [Route("tarea/ObtenerPorId")]
        public ActionResult<Tablero> ObtenerPorId(int id)
        {
            try
            {
                ITareaRepositorio tareaRepositorio = new TareaRepositorio();
                var tab = tareaRepositorio.GetById(id);
                return Ok(tab);
            }
            catch (Exception)
            {
                return BadRequest("Error al intentar traer");
            }
        }

        [HttpDelete]
        [Route("tarea/Borrar")]
        public ActionResult Borrar(int id)
        {
            try
            {
                ITareaRepositorio tareaRepositorio = new TareaRepositorio();
                tareaRepositorio.Remove(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error al borrar");
            }
        }

        [HttpPut]
        [Route("tarea/Actualizar")]
        public ActionResult Update(Tarea tarea)
        {
            try
            {
                ITareaRepositorio tareaRepositorio = new TareaRepositorio();
                tareaRepositorio.Update(tarea);
                return Ok(tarea);
            }
            catch (Exception)
            {
                return BadRequest("Error al actualizar");
            }
        }
    }
}
