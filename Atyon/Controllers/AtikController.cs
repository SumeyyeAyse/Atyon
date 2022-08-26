using Atyon.Entities;
using Atyon.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atyon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtikController : ControllerBase
    {      
        public AtyonDataContext AtyonDataContext { get; set; }
        private readonly ILogger<AtikController> _logger;

        public AtikController(AtyonDataContext atyonDataContext, ILogger<AtikController> logger)
        {
            AtyonDataContext = atyonDataContext;
            _logger = logger;
        }


        [HttpGet]
        [Route("List")]
        public List<TblAtik> List()
        {
            var q = AtyonDataContext.TblAtiks.ToList();

            return q;
        }


        [HttpPost]
        [Route("Add")]
        public IActionResult Add(AtikRequest atik)
        {

            TblAtik dto = new TblAtik();
            dto.AtikAd = atik.atikAd;
            dto.AtikKod = atik.atikKod;
            dto.AtikTipKod = atik.atikTipKod;


          //  dto.AtikTipKodNavigation.AtikTipAd = atik.atikTipaciklamasi;



            AtyonDataContext.Add(dto);
            AtyonDataContext.SaveChanges();
            return Ok();
        }

        [HttpPut("Put")]

        public IActionResult Put(AtikRequest atik)
        {
            var q = AtyonDataContext.TblAtiks.Where(x => x.AtikId == atik.AtikId).FirstOrDefault();

            if (q != null)
            {
                q.AtikAd = atik.atikAd;
                q.AtikKod = atik.atikKod;
                q.AtikTipKod = atik.atikTipKod;
                AtyonDataContext.TblAtiks.Update(q);
                AtyonDataContext.SaveChanges();
                return Ok();
            }
            else
            {
                throw new Exception();
            }


        }

        [HttpDelete("Delete")]

        public IActionResult Delete(int atikId)
        {
            var q = AtyonDataContext.TblAtiks.Where(x => x.AtikId == atikId).FirstOrDefault();

            if (q != null)
            {
                AtyonDataContext.Remove(q);
                AtyonDataContext.SaveChanges();
                return Ok();
            }
            else
            {
                throw new Exception();
            }

        }
    }
}
