using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AreaCalculatorRestApi.Models;


namespace AreaCalculatorRestApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]
     [Route("/api/[controller]")]

    public class AreaController : ControllerBase
    {
        //private static readonly string[] Summaries = new[] {
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //Some initial data (On the DB later)
        public static List<Area> areaList = new List<Area>() 
        {
            new Area() { Id = 1, Name = "Area51", Width = 51, Length = 51 },
            new Area() { Id = 2, Name = "Area52", Width = 52, Length = 52 },
            new Area() { Id = 3, Name = "Area53", Width = 53, Length = 53 },
            new Area() { Id = 4, Name = "Area54", Width = 54, Length = 54 },
            new Area() { Id = 5, Name = "Area55", Width = 55, Length = 55 }
        };


        private readonly ILogger<AreaController> _logger;
        private int typeSearch = -1;

        public AreaController(ILogger<AreaController> logger)
        {
            _logger = logger;
        }

        // GET: <port>/Area
        [HttpGet]
        public IEnumerable<Area> Get()
        {
            return areaList.ToArray();
        }
        
        // GET: <port>/Area/0
        [HttpGet("{id}", Name = "Get")]
        public Area Get(int id)
        {
            return areaList.Find(item => item.Id == id);
        }


        // 0 regular, 1 search for W, 2 search for L
        public void _validateSearch(string _query, int token)
        {
            //int tmpNum;
            typeSearch = 0;
            var num = _query.ToLower().Substring(1);

            if (int.TryParse(num, out _))
                typeSearch = token;
        }



        // GET: <port>/api/Area/{query}/search
        [Route("{query}/search")]
        [HttpGet]
        public IEnumerable<Area> Search(string query)
        {
            if (query.ToLower().StartsWith("w"))
                _validateSearch(query, 1);
            else if (query.ToLower().StartsWith("l"))
                _validateSearch(query, 2);
            else
                typeSearch = 0;

            // 0 regular, 1 search for Width, 2 search for Length
            if (typeSearch == 0)
                return areaList.Where(x => x.Name.ToLower().Contains(query.ToLower()) 
                                    || x.Width.ToString().Contains(query) 
                                    || x.Length.ToString().Contains(query)
                                );
            else if (typeSearch == 1)
                return areaList.Where(x => x.Name.ToLower().Contains(query.ToLower())
                                    || x.Width.ToString().Contains(query)
                                );
            else
                return areaList.Where(x => x.Name.ToLower().Contains(query.ToLower())
                                    || x.Length.ToString().Contains(query)
                                );
        }


        // POST: <port>/Area
        [HttpPost]
        public void Post(Area area)
        {
            var newArea = areaList.FirstOrDefault(item => item.Id == area.Id);

            if (newArea == null)
            {
                //Get a new Id then save
                area.Id = areaList.Max(x => x.Id) + 1;

                areaList.Add(area);
            }
            else
            {
                // Id Area already exist in areaList
            }
        }


        // PUT: <port>/Area/
        [HttpPut]
        // public void Put(int id, Area area)
        public void Put(Area area)
        {
            var existingArea = areaList.FirstOrDefault(item => item.Id == area.Id);

            if (existingArea != null)
            {
                existingArea.Name = area.Name;
                existingArea.Width = area.Width;
                existingArea.Length = area.Length;
            }
            else
            {
                //Logic
            }
        }


        // DELETE: <port>/Area/0
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // areaList.Remove(areaList.Find(item => item.Id == id));

            int existingArea = areaList.FindIndex(item => item.Id == id);
            if(existingArea > 0)
                areaList.RemoveAt(areaList.FindIndex(item => item.Id == id));
        }
    }
}
