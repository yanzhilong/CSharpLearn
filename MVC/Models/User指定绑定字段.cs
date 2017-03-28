using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    /// <summary>
    /// 用户的表单
    /// </summary>
    public class User指定绑定字段
    {
        public string ID { get; set; }
        public string Name { get; set; }//名字
        public string NickName { get; set; }//昵称
        public int Age { get; set; }//年龄
        public DateTime Birthday { get; set; }//生日
        public string Email { get; set; }//邮件
        public string School { get; set; }//学校

        public string Wife { get; set; }//妻子名字
        public DateTime WifeBirthday { get; set; }//老婆生日
        public string WifeEmail { get; set; }//老婆的邮件
        public string Father { get; set; }//父亲名字
        public DateTime FatherBirthday { get; set; }//父亲生日
        public string FatherEmail { get; set; }//父亲的邮件
    }
}