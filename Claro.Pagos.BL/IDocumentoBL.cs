using Claro.Pagos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Pagos.BL
{
    public interface IDocumentoBL
    {
        List<DocumentoBE> ListarDocumentos();

        //Task<List<DocumentoBE>> ListarDocumentosMock(DocumentoBE documentoBE);
        List<DocumentoBE> ListarDocumentosMock();
    }
}
