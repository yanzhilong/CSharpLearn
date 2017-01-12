using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLearn
{
    /// <summary>
    /// 类的高级应用
    /// </summary>
    public class ProgramAdvanced
    {
        public static void ProgramAdvanceMan()
        {
            Console.WriteLine("ProgramAdvanced");
            //接口的使用
            InterfaceChild interfaceChild = new InterfaceChild();
            ImyInterface iMyInterface = interfaceChild;
            iMyInterface.ID = "TM";
            iMyInterface.Name = "C# 3.5从入门到开发";
            iMyInterface.ShowInfo();

            //多接口的使用
            Yanzl yanzl = new Yanzl();
            ITeacher iteacher = yanzl;
            iteacher.Name = "TM";
            iteacher.Sex = "男";
            iteacher.teach();

            IStudent istudent = yanzl;
            istudent.Name = "C#";
            istudent.Sex = "男";
            istudent.study();

            //多接口相同方法
            //显示实现的接口就不能通过类来调用了
            Console.WriteLine("指定实现接口的方法");
            AddChild addChild = new AddChild();
            IaddInterface1 addinterface1 = addChild;
            IaddInterface2 addinterface2 = addChild;
            Console.WriteLine(addinterface1.Add());
            Console.WriteLine(addinterface2.Add());

            //抽象类的使用
            Console.WriteLine("抽象类的使用");
            AbsChild absChild = new AbsChild();
            AbsClass absClass = absChild;
            absClass.Id = "BH001";
            absClass.Name = "yanzl";
            absClass.ShowInfo();

            //密封类的使用
            Console.WriteLine("密封类的使用");
            SealedClass sealedClass = new SealedClass();
            sealedClass.Name = "yanzl";
            sealedClass.Id = "id";
            sealedClass.ShowInfo();
        }
    }

    //*************************************************单接口的使用********************************************************
    /// <summary>
    /// 定义一个接口
    /// </summary>
    interface ImyInterface
    {
        string ID
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        void ShowInfo();


    }

    class InterfaceChild : ImyInterface
    {
        string id;
        string name;

        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        /// <summary>
        /// 实现接口的方法
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine("编号\t姓名");
            Console.WriteLine(ID + "\t" + Name);
        }
    }


    //*************************************************多接口的使用********************************************************

    interface IPeople
    {
        string Name
        {
            get; set;
        }
        string Sex
        {
            get;
            set;
        }

    }

    interface ITeacher : IPeople
    {
        void teach();
    }

    interface IStudent : IPeople
    {
        void study();
    }

    class Yanzl : IPeople, ITeacher, IStudent
    {
        string name = "";
        string sex = "";

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
            }
        }

        public void study()
        {
            Console.WriteLine(name + "" + Sex + " 学生");
        }

        public void teach()
        {
            Console.WriteLine(name + "" + Sex + " 教师");
        }
    }

    //*************************************************多接口同方法的使用********************************************************
    interface IaddInterface1
    {
        int Add();
    }

    interface IaddInterface2
    {
        int Add();
    }

    class AddChild : IaddInterface1, IaddInterface2
    {
        /// <summary>
        /// 指定实现IaddInterface2这个接口的Add()方法
        /// </summary>
        /// <returns></returns>
        int IaddInterface2.Add()
        {
            return 2;
        }

        /// <summary>
        /// 指定实现IaddInterface1接口的Add()方法
        /// </summary>
        /// <returns></returns>
        int IaddInterface1.Add()
        {
            return 1;
        }
    }


    //*************************************************抽象类的使用********************************************************

    abstract class AbsClass{

        private string id = "";
        private string name = "";

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        /// <summary>
        /// 抽象方法，子类实现
        /// </summary>
        public abstract void ShowInfo();
    }


    class AbsChild : AbsClass
    {
        /// <summary>
        /// 实现父类的方法
        /// </summary>
        public override void ShowInfo()
        {
            Console.WriteLine(Id + " " + Name);
        }
    }


    //*************************************************密封类的使用********************************************************
    class SealedBase
    {
        public virtual void ShowInfo()
        {

        }
    }

    class SealedClass : SealedBase
    {
        private string id;
        private string name;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public sealed override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine(Id + " " + Name);
        }
    }
}



