using System.Collections.Generic;

namespace Skippy.Interface
{
    public interface IDalProduct
    {
        public void Insert(DtoProduct product);

        public List<DtoProduct> GetAll();

        public DtoProduct GetById(int id);

        public void Delete(int id);

        public void Update(DtoProduct product);
    }
}
