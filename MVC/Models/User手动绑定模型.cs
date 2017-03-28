using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    /// <summary>
    /// 用户的表单
    /// </summary>
    public class User手动绑定模型
    {
        [DisplayName("编号")]
        [Required]
        public string ID { get; set; }
        [DisplayName("名字")]
        [Required(ErrorMessage = "请输入名字")]
        public string Name { get; set; }//名字
        [DisplayName("昵称")]
        public string NickName { get; set; }//昵称
        [DisplayName("年龄")]
        [Required(ErrorMessage = "请输入年龄")]
        public int Age { get; set; }//年龄
        [DisplayName("生日")]
        public DateTime Birthday { get; set; }//生日
        [DisplayName("邮件")]
        public string Email { get; set; }//邮件
        [DisplayName("学校")]
        public string School { get; set; }//学校
        [DisplayName("妻子名字")]
        public string Wife { get; set; }//妻子名字
        [DisplayName("老婆生日")]
        public DateTime WifeBirthday { get; set; }//老婆生日
        [DisplayName("老婆邮件")]
        public string WifeEmail { get; set; }//老婆的邮件
        [DisplayName("父亲名字")]
        public string Father { get; set; }//父亲名字
        [DisplayName("父亲生日")]
        public DateTime FatherBirthday { get; set; }//父亲生日
        [DisplayName("父亲邮件")]
        public string FatherEmail { get; set; }//父亲的邮件
    }
}