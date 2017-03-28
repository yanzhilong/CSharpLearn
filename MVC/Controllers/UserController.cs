using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateSuccess()
        {
            return View();
        }

        // 默认的Get请求
        public ActionResult Create简单模型绑定()
        {
            return View();
        }

        // 默认的Post请求
        [HttpPost]
        public ActionResult Create简单模型绑定(string UserName)
        {
            //验证成功
            return RedirectToAction("CreateSuccess");
        }


        // 默认的Get请求，会到达创建用户的页面
        public ActionResult Create原始方法()
        {
            return View();
        }

        // 默认的Post请求 用于接收用户提交的表单
        [HttpPost]
        public ActionResult Create原始方法(User原始方法 user)
        {
            if (ModelState.IsValid)
            {
                //验证成功
                return RedirectToAction("CreateSuccess");
            }
            return View(user);
        }


        // 默认的Get请求，会到达创建用户的页面
        public ActionResult Create指定绑定字段()
        {
            return View();
        }

        // 指定绑定的字段，这里只要有ID和Name即为有效
        [HttpPost]
        public ActionResult Create指定绑定字段([Bind(Include = "ID,Name")]User指定绑定字段 user)
        {
            if (ModelState.IsValid)
            {
                //验证成功
                return RedirectToAction("CreateSuccess");
            }
            return View(user);
        }

        // 默认的Get请求，会到达创建用户的页面
        public ActionResult Create显示指定的名字()
        {
            return View();
        }

        // 指定绑定的字段，这里只要有ID和Name即为有效
        [HttpPost]
        public ActionResult Create显示指定的名字([Bind(Include = "ID,Name")]User显示指定的名字 user)
        {
            if (ModelState.IsValid)
            {
                //验证成功
                return RedirectToAction("CreateSuccess");
            }
            return View(user);
        }
        // 默认的Get请求，会到达创建用户的页面
        public ActionResult Create必填项及错误提示()
        {
            return View();
        }

        // 指定绑定的字段，这里只要有ID和Name即为有效
        [HttpPost]
        public ActionResult Create必填项及错误提示([Bind(Include = "ID,Name")]User必填项及错误提示 user)
        {
            if (ModelState.IsValid)
            {

                //验证成功
                return RedirectToAction("CreateSuccess");
            }
            //清除模型绑定状态，这样在页面上就看不到哪个没有 绑定成功的错误提示了
            //ModelState.Clear();
            int count = ModelState.Count(); //得到已经绑定的的属性数量
            bool emailBind = ModelState["Email"].Errors.Count > 0; //判断Email这个属性绑定过程中是否出现错误
            if (emailBind)
            {
                //得到绑定Email出现的错误
                ModelError me = ModelState["Email"].Errors[0];
                var errMsg = me.ErrorMessage;
                var errExp = me.Exception;
                //这里可以手动指定将要输出到html页面中的提示信息,一般直接在Model中通过ErrorMessage指定了
                ModelState.AddModelError("Email", "请输入Email字段");
                //这里也可以加入一些其它的错误信息
            }
            return View(user);
        }


        // 默认的Get请求，
        public ActionResult Create手动绑定模型()
        {
            return View();
        }

        // 
        [HttpPost]
        public ActionResult Create手动绑定模型(FormCollection form12)
        {
            User手动绑定模型 user = new User手动绑定模型();
            if (TryUpdateModel<User手动绑定模型>(user))
            {
                //绑定失败
                return View();
            }
            //验证成功
            return RedirectToAction("CreateSuccess");
        }

        // 默认的Get请求，
        public ActionResult Create复杂模型绑定()
        {
            return View();
        }

        // 
        [HttpPost]
        public ActionResult Create复杂模型绑定(User复杂模型绑定 user1,User复杂模型绑定 user2)
        {
            //验证成功
            return RedirectToAction("CreateSuccess");
        }
        


        // 到达用户详情页面
        public ActionResult Details查看所有用户()
        {
            List<User查看所有用户> users = new List<User查看所有用户>();
            for(int i = 0; i < 20; i++)
            {
                User查看所有用户 user = new User查看所有用户();
                user.ID = Guid.NewGuid().ToString();
                user.Name = "严志龙";
                user.NickName = "龙";
                user.Age = 18;
                user.Birthday = DateTime.Now;
                user.Email = "51877421@qq.com";
                user.School = "清华大学";
                user.Wife = "黄红";
                user.WifeBirthday = DateTime.Now;
                user.WifeEmail = "51877421@qq.com";
                user.Father = "严昌";
                user.FatherBirthday = DateTime.Now;
                user.FatherEmail = "gfdonx@163.com";
                users.Add(user);
            }
            return View(users);
        }


        // 定义找不到Action的时候的处理方法
        protected override void HandleUnknownAction(string actionName)
        {
            Response.Redirect("error");
        }


        // 到达用户详情页面
        public string error()
        {
            return "未找到action";
        }
    }
}