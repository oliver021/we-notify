using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeNotify.HttpService.Contracts;

namespace PremiumTesh.TwitterNotifier.Support
{
    /// <summary>
    /// El controlador generico sirve para implementar un api rest
    /// de las entidades que se necesiten mediante el protocolo http
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    [ApiController]
    public class GenericController<TEntity, TId> : Controller
        where TEntity : class, IBaseEntity<TId>
    {
        public GenericController(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public IRepository<TEntity> Repository { get; set; }

        /// <summary>
        /// Devuelve un listado de todos los registros de datos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetAllAsync()
        {
            return Json(await Repository.GetAll());
        }

        /// <summary>
        /// Devueleve un listado filtrado de registros de datos
        /// </summary>
        /// <param name="page"></param>
        /// <param name="length"></param>
        /// <param name="search"></param>
        /// <param name="sort"></param>
        /// <param name="sortType"></param>
        /// <returns></returns>
        [HttpGet("page/{page}")]
        public async Task<JsonResult> GetAsync([FromRoute] int page, int length)
        {
            return Json(await Repository.Get(page, length));
        }

        /// <summary>
        /// Devuelve un unico registro basado en su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<JsonResult> GetByIdAsync([FromRoute] ulong id)
        {
            return Json(await Repository.GetOne(id));
        }

        /// <summary>
        /// Agrega un registro con datos que entran en el cuerpo de la peticion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] TEntity data)
        {
            try
            {
                var result = await Repository.StoreAnsyc(data);
                return StatusCode(201, new
                {
                    data.Id,
                    data.AtCtreated
                });
            }
            catch (Exception)
            {
                // ignore for now
                return StatusCode(400);
            }
        }

        /// <summary>
        /// Actualiza un registro con datos que entran en el cuerpo de la peticion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<NoContentResult> UpdateAsync([FromBody] TEntity data)
        {
            try
            {
                await Repository.UpdateAsync(data);
            }
            catch (Exception)
            {
                // ignore for now
            }
            return NoContent();
        }

        /// <summary>
        /// Elimina un registro basado en su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<NoContentResult> DeleteAsync([FromRoute] ulong id)
        {
            try
            {
                await Repository.DeleteAsync(id);
            }
            catch (Exception)
            {
                // ignore for now
            }
            return NoContent();
        }
    }
}