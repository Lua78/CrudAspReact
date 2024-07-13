using DBGestorsApi.Context;
using DBGestorsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBGestorsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public GestorsController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los gestores.
        /// </summary>
        /// <returns>Una lista de modelos de gestores.</returns>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                List<DbGestorsModel> models = _context.gestors.ToList();
                return Ok(models);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Obtiene un gestor por ID.
        /// </summary>
        /// <param name="id">El ID del gestor.</param>
        /// <returns>El modelo del gestor.</returns>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                DbGestorsModel model = _context.gestors.FirstOrDefault(elemenent => elemenent.id == id);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Crea un nuevo gestor.
        /// </summary>
        /// <param name="value">El modelo del gestor a crear.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPost]
        public ActionResult Post([FromBody] DbGestorsModel value)
        {
            try
            {
                _context.Add(value);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Actualiza un gestor existente.
        /// </summary>
        /// <param name="id">El ID del gestor a actualizar.</param>
        /// <param name="value">El modelo del gestor actualizado.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DbGestorsModel value)
        {
            try
            {
                DbGestorsModel model = _context.gestors.FirstOrDefault(el => el.id == id);
                if (model != null)
                {
                    model.release = value.release;
                    model.dev_company = value.dev_company;
                    model.name = value.name;
                    _context.gestors.Update(model);
                    _context.SaveChanges();
                    return Ok();
                }
                return BadRequest("Error");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Elimina un gestor por ID.
        /// </summary>
        /// <param name="id">El ID del gestor a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                DbGestorsModel model = _context.gestors.FirstOrDefault(el => el.id == id);
                if (model != null)
                {
                    _context.gestors.Remove(model);
                    _context.SaveChanges();
                    return Ok();
                }
                return BadRequest("Error");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
