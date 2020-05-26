using Skippy.Data;
using Skippy.Interface;

namespace Skippy.Factory
{


    public class DalFactory
    {
        public static IDalOrder CreateOrderDal()
        {
            return new DalOrder();
        }

        public static IDalCategorie CreateCategorieDal()
        {
            return new DalCategorie();
        }

        public static IDalKlant CreateKlantDal()
        {
            return new DalKlant();
        }
        public static IDalProduct CreateProductDal()
        {
            return new DalProduct();
        }

    }
}
