using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using APISample.Helper;
using System.Net.Http.Headers;

namespace APISample.Controllers
{
    [Route("api/[controller]")]
    public class DemoController : BaseController
    {

        [HttpGet("demo_message")]
        public void demo_message(string message)
        {
            string hostname = Environment.GetEnvironmentVariable("COMPUTERNAME") ?? Environment.GetEnvironmentVariable("HOSTNAME");
            this.Message = $"[{hostname}]{message}";
        }

        [HttpPost("demo_data")]
        public void demo_data(string message, [FromBody]Object pushForm)
        {
            this.Message = message;
            this.Data = pushForm;
        }

        [HttpGet("demo_error")]
        public void demo_error(string message)
        {
            throw new ArgumentException("ERROR");
        }


        [HttpGet("demo_list_error_log")]
        public void demo_list_error_log()
        {
            this.Data = MongoLogger.getInstance().ListLog();
        }

        /// <summary>
        /// 測試 Redis寫入
        /// </summary>
        /// <param name="key"></param>
        [HttpGet("RedisGet")]
        public void RedisGet(string key) 
        {       
           this.Data =  RedisService.getInstance().GetAsync<object>(key).Result;
        } 


        /// <summary>
        /// 取得Keys
        /// </summary>
        /// <param name="key"></param>
        [HttpGet("RedisKeys")]
        public void RedisKeys(string keyPattern="*") 
        {       
           this.Data =  RedisService.getInstance().GetKeys(keyPattern);
        } 
 

        /// <summary>
        /// 測試Redis讀取
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        [HttpPost("RedisSet")]
        public void RedisSet(string key, string value) 
        { 
            this.Data = RedisService.getInstance().SetAsync(key, value).Result;
        }


        [HttpGet]
        public void HeaderRead(){
            var headers = this.Request.Headers;
            string token = string.Empty;
            if (headers["username"].ToArray().Length!=0)
            {
                token = headers["username"].ToArray()[0];
            }


            this.Message = token;
           
        }



    }


    
}
