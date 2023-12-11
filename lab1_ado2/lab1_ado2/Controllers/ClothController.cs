using Dapper;
using lab1_ado2.Models;
using lab1_ado2.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace lab1_ado2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothController : ControllerBase
    {
        private readonly IClothService _clothService;
        private readonly IConfiguration _config; 
        public ClothController(IConfiguration configuration,IClothService clothService) { 
            _config= configuration;
            _clothService = clothService;
        }

        [HttpGet]
        public List<Cloth> GetAllCloth()
        {
            /*using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var cloths = await connection.QueryAsync<Cloth>("EXEC GetAllCloth;");
            return Ok(cloths);*/
            return _clothService.getAllCloth();
        }


        [HttpGet("{clothId}")]
        public Cloth GetCloth(int clothId )
        {
            /*using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var cloth = await connection.QueryFirstAsync<Cloth>("select * from Cloth where id=@Id", new {Id=clothId});
            return Ok(cloth);*/
            return _clothService.getCloth(clothId);
        }

        [HttpPost]
        public int CreateCloth(Cloth cloth)
        {
            /*using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into Cloth(name, discription, type) values(@Name, @Discription, @Type)", cloth);
            return Ok(await GetAllCloths(connection));*/
            return _clothService.createCloth(cloth);
        }
        [HttpPut]
        public int UpdateCloth(Cloth cloth)
        {
            /*using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update Cloth set name=@Name, discription=@Discription, type=@Type where id=@Id", cloth);
            return Ok(await GetAllCloths(connection));*/
            return _clothService.updateCloth(cloth);
        }
        [HttpDelete("{clothId}")]
        public int DeleteCloth(int clothId)
        {
         /*   using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var cloth = await connection.QueryFirstAsync<Cloth>("EXEC DeleteCloth @ClothID=@Id", new { Id = clothId });
            return Ok(cloth);*/
         return _clothService.deleteCloth(clothId);
        }

        private List<Cloth> GetAllCloths(SqlConnection connection)
        {
            return _clothService.getAllCloth();
            /*return await connection.QueryAsync<Cloth>("EXEC GetAllCloth;");*/
        }
    }
}
