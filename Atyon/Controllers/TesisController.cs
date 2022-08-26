using Atyon.Entities;
using Atyon.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atyon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesisController : ControllerBase
    {
        public AtyonDataContext AtyonDataContext { get; set; }
        public TesisController(AtyonDataContext atyonDataContext)
        {
            AtyonDataContext = atyonDataContext;
        }

        [HttpGet]
        [Route("List")]
        public List<TblTesis> List()
        {
            var q = AtyonDataContext.TblTesis.ToList();

            return q;
        }


        [HttpPost]
        [Route("Add")]
        public IActionResult Add(TesisRequest tesis)
        {

            TblTesis dto = new TblTesis();
            dto.TesisKod = tesis.TesisKod;
            dto.FirmaKod = tesis.FirmaKod;
            dto.IlceKod = tesis.IlceKod;

            AtyonDataContext.Add(dto);
            AtyonDataContext.SaveChanges();
            return Ok();
        }

        [HttpPut("Put")]

        public IActionResult Put(TesisRequest tesis)
        {
            var q = AtyonDataContext.TblTesis.Where(x => x.TesisId == tesis.TesisId).FirstOrDefault();

            if (q != null)
            {
                q.FirmaKod = tesis.FirmaKod;
                q.TesisKod = tesis.TesisKod;
                q.IlceKod = tesis.IlceKod;
                AtyonDataContext.TblTesis.Update(q);
                AtyonDataContext.SaveChanges();
                return Ok();
            }
            else
            {
                throw new Exception();
            }


        }

        [HttpDelete("Delete")]

        public IActionResult Delete(int tesisId)
        {
            var q = AtyonDataContext.TblTesis.Where(x => x.TesisId == tesisId).FirstOrDefault();

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
