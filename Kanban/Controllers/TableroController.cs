using Kanban.Models;
using Kanban.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableroController : Controller
    {
        [HttpPost]
        [Route("tablero/agregar")]
        public ActionResult Agregar(Tablero tablero)
        {
            try
            {
                ITableroRepositorio tableroRepositorio = new TableroRepositorio();
                tableroRepositorio.Create(tablero);
                return Ok("Se creo con exito");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("Error al crear el post");
            }
        }

        [HttpGet]
        [Route("tablero/listarPorUsu")]
        public ActionResult <IEnumerable<Tablero>> ListarPorUsuario(int idUsu) 
        {
            try
            {
                ITableroRepositorio tableroRepositorio = new TableroRepositorio();
                var lista = tableroRepositorio.ListarPorUsuario(idUsu);
                return Ok(lista);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("Error");
            }
        }

        [HttpGet]
        [Route("Tablero/Obtener")]
        public ActionResult<IEnumerable<Tablero>> GetTableros()
        {
            try
            {
                ITableroRepositorio tableroRepositorio = new TableroRepositorio();
                var tableros = tableroRepositorio.GetAll();
                return Ok(tableros);
            }
            catch (Exception)
            {
                return BadRequest("Error al intentar traer los tableros");
            }
        }

        [HttpGet]
        [Route("Tablero/ObtenerPorId")]
        public ActionResult<Tablero> ObtenerPorId(int id)
        {
            try
            {
                ITableroRepositorio tableroRepositorio = new TableroRepositorio();
                var tab = tableroRepositorio.GetById(id);
                return Ok(tab);
            }
            catch (Exception)
            {
                return BadRequest("Error al intentar traer el tablero");
            }
        }

        [HttpDelete]
        [Route("Tablero/Borrar")]
        public ActionResult Borrar(int id)
        {
            try
            {
                ITableroRepositorio tableroRepositorio = new TableroRepositorio();
                tableroRepositorio.Remove(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error al borrar");
            }
        }

        [HttpPut]
        [Route("Tablero/Actualizar")]
        public ActionResult Update(Tablero tablero)
        {
            try
            {
                ITableroRepositorio tableroRepositorio = new TableroRepositorio();
                tableroRepositorio.Update(tablero);
                return Ok(tablero);
            }
            catch (Exception)
            {
                return BadRequest("Error al actualizar");
            }
        }
    }
}
