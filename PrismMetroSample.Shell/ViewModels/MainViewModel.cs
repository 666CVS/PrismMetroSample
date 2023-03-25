﻿//using System;
//using System.Collections.Generic;
//using System.DirectoryServices.ActiveDirectory;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Collections.ObjectModel;
//using System.Reflection;
//using Zhaoxi.MES.Frame.Base;
//using Zhaoxi.MES.Frame.Models;

//namespace Zhaoxi.MES.Frame.ViewModels
//{
//    public class MainViewModel : NotifyBase
//    {
//        // 菜单 集合
//        public List<MenuItemModel> TreeList { get; set; }
//        // 页面 集合
//        public ObservableCollection<PageItemModel> Pages { get; set; }
//            = new ObservableCollection<PageItemModel>();

//        public MainViewModel()
//        {
//            #region 菜单初始化
//            TreeList = new List<MenuItemModel>();
//            {
//                MenuItemModel tim = new MenuItemModel();
//                tim.Header = "工艺设计";
//                //&#xe740;  XAML里使用
//                tim.IconCode = "\ue610"; // 字体图标编码，阿里的Iconfont平台打包的图标库
//                TreeList.Add(tim);
//                tim.Children.Add(new MenuItemModel
//                {
//                    Header = "加工工艺",
//                    TargetView = "BlankPage",
//                    OpenViewCommand = new Command<MenuItemModel>(OpenView)
//                });
//                tim.Children.Add(new MenuItemModel
//                {
//                    Header = "EBOM",
//                    TargetView = "BlankPage",
//                    OpenViewCommand = new Command<MenuItemModel>(OpenView)
//                });

//                tim.Children.Add(new MenuItemModel
//                {
//                    Header = "PBOM",
//                    //TargetView = "BlankPage"

//                });
//                MenuItemModel subMenu = new MenuItemModel();
//                subMenu.Header = "二级菜单";
//                subMenu.Children.Add(
//                    new MenuItemModel
//                    {
//                        Header = "三级菜单"
//                    }
//                   );
//                tim.Children.Add(subMenu);
//            }
//            #endregion

//            #region 测试  页面初始
//            // 所有数据集合都可以 VM中进行控件 （增加和删除）
//            //Pages = new ObservableCollection<PageItemModel>();
//            //Pages.Add("AAAA");
//            //Pages.Add("BBBB");
//            //Pages.Add("CCCC");
//            //Pages.Add("DDDD");
//            #endregion
//        }

//        private void OpenView(MenuItemModel menu)
//        {
//            // 两个问题：
//            // 1、每点击一次都会有一个新的页面！  解决方案：从集合中判断是否存在
//            // 2、新打开一个页面后，不能马上显示 

//            //MenuItemModel mim = menu as MenuItemModel;
//            // 需要进行页面的打开 
//            //Pages.Add("EEEE");

//            var page = Pages.ToList().FirstOrDefault(p => p.Header == menu.Header);

//            if (page == null)
//            {
//                Type type = Assembly.GetExecutingAssembly().
//                    GetType("Zhaoxi.MES.Frame.Views.Pages." + menu.TargetView);
//                object p = Activator.CreateInstance(type);

//                Pages.Add(new PageItemModel
//                {
//                    Header = menu.Header,
//                    PageView = p,
//                    IsSelected = true,
//                    CloseTabCommand = new Command<PageItemModel>(ClosePage)
//                });
//            }
//            else
//                page.IsSelected = true;
//        }

//        private void ClosePage(PageItemModel menu)
//        {
//            Pages.Remove(menu);
//        }
//    }
//}
