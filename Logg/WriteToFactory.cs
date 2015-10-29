
namespace Logg
{
    public class WriteToFactory
    {
        public static IWriteTo GetObject(WriteTo writeTo)
        {
            IWriteTo ObjSelector = null;

            switch (writeTo)
            {
                case WriteTo.WriteToDataBase:
                    { ObjSelector = new WriteToDatabse(); }
                    break;
                case WriteTo.WriteToFile:
                    { ObjSelector = new WriteToFile(); }
                    break;
            }

            return ObjSelector;
        }
    }
}
