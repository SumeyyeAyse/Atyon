using Atyon.Entities;
using Atyon.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atyon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirmaController : ControllerBase
    {
        public AtyonDataContext AtyonDataContext { get; set; }

        public FirmaController(AtyonDataContext atyonDataContext)
        {
            AtyonDataContext = atyonDataContext;

        }


        [HttpGet]
        [Route("List")]
        public List<TblFirma> List()
        {
            var q = AtyonDataContext.TblFirmas.ToList();

            return q;
        }


        [HttpPost]
        [Route("Add")]
        public IActionResult Add(FirmaRequest firma)
        {

            TblFirma dto = new TblFirma();
            dto.Ad = firma.Ad;
            dto.FirmaKod = firma.FirmaKod;
            dto.VergiNo = firma.VergiNo;


            //  dto.AtikTipKodNavigation.AtikTipAd = atik.atikTipaciklamasi;



            AtyonDataContext.Add(dto);
            AtyonDataContext.SaveChanges();
            return Ok();
        }

        [HttpPut("Put")]

        public IActionResult Put(FirmaRequest firma)
        {
            var q = AtyonDataContext.TblFirmas.Where(x => x.FirmaId == firma.FirmaId).FirstOrDefault();

            if (q != null)
            {
                q.Ad = firma.Ad;
                q.FirmaKod = firma.FirmaKod;
                q.VergiNo = firma.VergiNo;
                AtyonDataContext.TblFirmas.Update(q);
                AtyonDataContext.SaveChanges();
                return Ok();
            }
            else
            {
                throw new Exception();
            }


        }

        [HttpDelete("Delete")]

        public IActionResult Delete(int firmaId)
        {
            var q = AtyonDataContext.TblFirmas.Where(x => x.FirmaId == firmaId).FirstOrDefault();

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
