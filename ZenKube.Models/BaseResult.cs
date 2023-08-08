using System.Linq;
using static ZenKube.Models.Enums;

namespace ZenKube.Models
{
    public class BaseResult<T>
    {

        public BaseResult Result = BaseResult.None;
        public string Msg = "";
        public T Content;

    

        public bool isOk() { return new BaseResult[]{ BaseResult.Success }.Any(n => n == Result); }


        public BaseResult(){
            
            Result = BaseResult.None;
            Content =  Activator.CreateInstance<T>();
            Msg = "";

        

        }
         
        public static BaseResult<T> NewSuccess(T? c) { 
        
            var ret=new BaseResult<T>();
            ret.Result = BaseResult.Success;
            ret.Content = c != null ? c : Activator.CreateInstance<T>();

            return ret;
        }


        public static BaseResult<T> NewError(string msg)
        {

            var ret = new BaseResult<T>();
            ret.Result = BaseResult.Error;
            ret.Content = Activator.CreateInstance<T>();
            ret.Msg = msg;

            return ret;
        }
    }
}