using System;
using System.Collections.Generic;
using System.Text;
using ClubMembershipApplication.FieldValidators;


namespace ClubMembershipApplication.Views
{ // 即用户登录查看用户注册和欢迎的界面直接给用户的 使用
    class MainView : IView  //调用了接口
    {
        public IFieldValidator FieldValidator => null;   //实现了IFieldValidator 的接口并生成了一个
        // IFieldValidator的对象初始为null

        IView _registerView = null;   //存储注册视图和登录视图的实例
        IView _loginView = null;
        public MainView(IView registerView, IView loginView)
        {    //构造函数
            _registerView = registerView;
            _loginView = loginView;
        }
        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            Console.WriteLine("Please press 'l' to login or if you are not yet registered please press 'r'");

            ConsoleKey key = Console.ReadKey().Key;   //获取他的枚举值  用于从控制台读取单个按键信息的方法 
            //Console.readKey()  是等待用户的按键  而 .key 属性适用于收集所有按键的枚举也就是说所有按键都会放到key里
            

            if (key == ConsoleKey.R)
            {
                RunUserRegistrationView();  //运行用户注册界面
                RunLoginView();   //运行用户登录页面
            }
            else if (key == ConsoleKey.L)
            {  
            //直接登录 不需要注册
                RunLoginView();  
            }
            else
            {
            //消除控制台
                Console.Clear();
            //输出goodbye
                Console.WriteLine("Goodbye");
            //等待用户输入
                Console.ReadKey();
               
            }
        
        }

        private void RunUserRegistrationView()
        {
            _registerView.RunView();   // // 调用注册视图的 RunView 方法
        }

        private void RunLoginView()   //// 调用登录视图的 RunView 方法
        {
            _loginView.RunView();
        }

    }
}
