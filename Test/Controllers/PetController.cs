using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    //静态类：（像密闭类sealed）
    //1、不能创建实例，不能被继承
    //2、可以为静态类定义一个静态构造函数
    //用途：基础类库（函数Math）、扩展
    //扩展：（不能修改方法，并且不能派生方法时用扩展）
    //a、扩展方法所属的类，必须是static类
    //b、扩展方法本身必须是static方法
    //c、扩展方法的第一个参数类型，必须是this+类名
    //注意：静态类的扩展方法必须在顶级的静态类中
    static class PetGuide
    {
        static public int HowToFeedDog(this Test.Controllers.PetController.Dog dog)//this+扩展谁的方法
        {
            return 2;
        }
    }
    public class PetController : Controller
    {
        //
        // GET: /Pet/

        public ActionResult Index()
        {
            return View();
        }
        //有共同行为（叫声，喂不一样的东西，但是都有叫声和喂），放到一个容器中，便于管理，方便扩展。既有共性，又有个性。（基类声明为虚方法virtual,派生类中用override重写），基类会调用派生类（基类引用指向的派生类）重写的方法；
        //pet是抽象类更合适（重写更合适）
        abstract public class Pet
        {
            //初始化的放在基类中，字段也在基类中
            public Pet(string name)
            {
                _name = name;
                _age = 0;
            }

            public int  showAge()
            {
                return _age;
            }
            //重载运算符：现有的某种运算符：一元：+-！++ -- true false 操作数必须是类或结构
            //二元：+ - * / ! | ^ >>  <= >= 操作数至少有一个是类或结构
            public static Pet operator ++(Pet pet)
            {
                ++pet._age;
                return pet;
            }
            //private:派生类不可访问字段_name，改为protected
             protected string _name;
             protected int _age;
            public string  PrintName()
            {
                return "Pet is:" + _name;
            }
            //虚方法，派生类中可以重写也可不重写，派生类中没有重写，则调用基类中的方法

            //virtual public string Speak()
            //{
            //    return _name+"要叫了";
            //}


            //抽象方法：abstract,没有方法体，派生类必须重写
            //抽象成员：必须是方法、属性、事件、索引
            //抽象类：
            //类中有一个抽象方法时，必须定义为抽象类，目的：被继承（因为没有方法体）
            //抽象类不能被实例化
            //抽象类可以包含抽象成员和普通成员，以及他们的任意组合
            //在派生类中需要用override关键字实现（必须实现）
            //基类中的叫声没有意义，动物的叫声没有一样的，所以用抽象方法
            abstract public string Speak();

            //密闭类：不希望他人通过继承修改（不要子类）如string类
            //密闭方法：不希望其他人重写该方法
            //一个基类不希望子类对其重写，可以不声明为virtual,如果某个派生类不希望子类对其重写，同时是override重写，就可以使用sealed
        }

   

        //只能单继承，c++可以多继承
        //一个设计原则，要依赖于抽象类（Pet）,而不是具体类（Dog）
        public class Dog : Pet
        {
           
            //初始化构造函数

            //public Dog(string name)
            //{
            //    _name = name;
            //}

            //静态构造方法：无参，无修饰符，只能访问静态变量
            //用于这个类的公共方法，字段，属性
            static int Num;
            static Dog()
            {
                Num = 0;
            }

            static public int dogNum()
            {
                return Num;
            }

            //初始化放在基类中，派生类可简化，:base调用基类的构造函数，把name传过去
            public Dog(string name)
                : base(name)
            {
                ++Num;
                //查看有无订阅者，然后调用方法
                if (NewDog != null)
                {
                    NewDog();
                }
            }
            //屏蔽基类函数，new关键字，修饰符和函数名与基类一样，不包括返回类型
            new public int PrintName()
            {
                return 1;
            }
            //1、重写虚方法必须具有相同的可访问性，且基类方法不能是private
            //2、不能重写static方法或者非虚方法（static相当于密闭类，sealed）
            //3、方法、属性、索引器、事件，都可以声明为virtual或override
           sealed  public override string Speak()
            {
                return _name + "要叫了，" + "wangwang";
            } 
            //派生类不希望子类对其重写，可以使用sealed,:所有的狗都是wangwang的叫，子类继承这个基类，不能用override重写该方法

            //泛型方法
            //泛型约束：不知道T具体是什么，不能对他进行操作，添加约束后，知道他具有哪些字段、属性和方法，就可以进行操作了。
            //约束类型：类（或其派生类）、class(任何类)、struct(任何值)、接口（该接口类型或任何实现该接口的类型）、new()(带有无参共有构造函数的类)
            //约束叠加规则：a、主约束，只能有一个（类名，class，struct）
            //b、接口约束（任意多个）
            //c、构造约束（new（））可以new 一个T类型对象，不加构造约束，不可以new
            public string  IsHappy<T>(T target)where T:Pet
           {
               return "happy:" + target.ToString();
           }
           //自定义转换：隐式转换implicit ，public static operator 不可少
            //注意：隐式 显式转换为同一对象，不能在同一类中
           public static implicit operator Cat(Dog dog)
           {
               return new Cat(dog._name);
           }

            //委托：持有方法，并执行
           public void WagTail()//狗摇尾巴
           {

           }
           //事件
           public delegate void Handler();
           public static event Handler NewDog;
            
        }
          class Client{
              public void WantaDog()
              {
                 // return "i want a new dog";
              }
         }
        
        //泛型接口
        public abstract class DogCmd
        {
            public abstract string GetCmd();
        }

        public class SitDogCmd : DogCmd
        {
            public override string GetCmd()
            {
                return "sit";
            }
        }
        public interface IDog<Cmd>where Cmd:DogCmd
        {
            void Act(Cmd cmd);
        }
        public class Labrador:Dog,IDog<SitDogCmd>{
            public Labrador(string name):base(name){

            }
            public void Act(SitDogCmd cmd){
                cmd.GetCmd();
            }
        }
        //可以实现多个接口,只能派生一个基类，顺序是：基类、接口
        //实现接口，必须用方法体实现它，加上public和方法体
        public class Cat : Pet,ICatchMice,IClimbtree
        {
            public Cat(string name)
                : base(name)
            {

            }
            public override string Speak()
            {
                return _name + "要叫了，" + "miaomiao";
            }
            public void CatchMice()
            {

            }
            public void Climbtree()
            {

            }
            //自定义转换：显式转换explicit（）
            public static explicit operator Dog(Cat  cat)
            {
                return new Dog(cat._name);
            }

            public void Lookbeatiful()
            {

            }
        }
        //抽象类
       abstract  class a{
            
        }
        //泛型类
       public class Cage<T>
       {
           T[] array;
           readonly int Size;
           int num;
           public Cage(int n)
           {
               Size = n;
               num = 0;
               array = new T[Size];
           }
           public void Putin(T pet)
           {
               if (num < Size)
               {
                   array[num++] = pet;
               }
               else
               {

               }
           }
           public T TakeOut()
           {
               if (num > 0)
               {
                   return array[--num];
               }
               //返回默认值
               return default(T);
           }
       }
       delegate void ActCute();
        public void test1()
        {
            //派生类可以直接调用基类的方法，属性
            Dog dog = new Dog("dog");
            //dog._name = "lala";

            //基类引用， 调用基类属性方法（派生类屏蔽不起作用）。基类引用可以指向派生类
            Pet dog1 = new Dog("k");
            //dog1._name = "lallala";

            //可以循环所有动物的所有行为
            Pet[] pets = new Pet[] { new Dog("dog"), new Cat("cat") };
                for(int i=0;i<pets.Length;i++){
                    pets[i].Speak();
                }

            //可以用类或者接口调用方法
                Cat cat = new Cat("猫");
                IClimbtree climb = (IClimbtree)cat;
            //可以调用类中其他方法
                cat.Climbtree();
            //接口实现的，只能调用接口中的方法
                climb.Climbtree();


            //静态方法可以不实例化，直接调用
                Dog.dogNum();

            //调用扩展方法像调用自己的方法一样
                Dog newDog = new Dog("dd");
                newDog.HowToFeedDog();


            //隐式转换
                Dog catdog = new Dog("catdog");
                catdog.Speak();
                Cat cat1 = catdog;
                cat1.Speak();

            //显式转换
                Cat cattodog = new Cat("猫变狗");
                cattodog.Speak();
                Dog cattodog1 = (Dog)cattodog;

                Pet[] pet = new Pet[] { new Dog("dog"), new Cat("cat") };
                for (int i = 0; i < pets.Length; i++)
                {
                    //重载运算符调用，更新年龄
                    pets[i]++;
                }

            //泛型方法
                var dogfanxing = new Dog("A");
                dogfanxing.IsHappy<Dog>(new Dog("B"));
                //dogfanxing.IsHappy<int>(8);

            //委托
            //委托的声明在方法体外面
                ActCute del=null;
                Dog dogcute=new Dog ("1");
                Cat catcute=new Cat ("2");
                del = dogcute.WagTail;
                del += catcute.Lookbeatiful;
                del();
            //匿名方法（原始的）
                del = delegate()
                {
                    //自定义方法体
                };
            //匿名方法（出现了Lamda表达式）
                del += () =>
                {
                    //自定义方法体
                };

            //事件(是委托的另一种，委托绑定要执行的事件，当触动某一事件时，委托执行)
                Client c1 = new Client();
                Client c2 = new Client();
                Dog.NewDog += c1.WantaDog;
                Dog.NewDog += c2.WantaDog;
                Dog dogevent = new Dog("event");
            
        }
        class Person
        {

        }
        //接口：
        //指定一组函数成员，而不实现他们的引用类型
        //只能用来被实现
        
        interface ICatchMice
        {
            //默认是public,但不能加任何修饰符
            void CatchMice();
        }
        interface IClimbtree
        {
            void Climbtree();
        }

        //结构：可以实现接口
        //与类的不同点：1、结构是值类型（栈），类是引用类型（推）
        //2、结构不支持继承，类支持继承
        //3、结构不能定义默认构造函数，编译器会定义
        //使用场合：
        //分配内存快，作用域结束就被删除，不需要垃圾回收，用于小型数据结构，传递过程中会复制，使用ref（引用类型）提高效率
        //what???
        struct fish
        {
            int weight;
            int size;
            int type;
        }
        //集合：
        //1、list add removeat [0]
        //2、dictionary [key]
        //3、栈：先进后出，后进先出，好比只有一个口的羽毛球筒。
        //出栈：Pop  入栈：Push 获取栈顶元素（并没有取出来）Peek
    class test{
        public void jihe()
        {
             Stack<Pet> strack = new Stack<Pet>();
            strack.Push(new Dog("dog"));
            strack.Pop();
            strack.Peek();

            Queue<Pet> queue = new Queue<Pet>();
            queue.Enqueue(new Dog("enwueuedog"));
            Pet pet = queue.Dequeue();
        }
        //4、队列：先进先出，类似两端开口的容器
        //出队：Dequeue  入队：Enqueue
        
    }
        //事件：发布者（通知事件发生的）、订阅者（关注事件发生的）
        //事件：触发（通知订阅者），注册（想在事件发生时被通知，必须注册）
        //事件订阅：+=方法  -=方法  方法：实例方法、静态方法、匿名方法Lamda表达式
    }
}
