using Sajat.ObjektumModel;

namespace Sajat.Partner
{
    public interface IIrszamValtozas : IEgysegnyiValtozas
    {
        IIrszamTarolo Irszamok { get; set; }
    }
}
