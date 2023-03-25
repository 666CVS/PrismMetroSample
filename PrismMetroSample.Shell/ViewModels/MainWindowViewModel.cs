using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PrismMetroSample.Infrastructure.Constants;
using PrismMetroSample.MedicineModule.Views;
using PrismMetroSample.PatientModule.Views;
using PrismMetroSample.Shell.Views.RegionAdapterViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using Zhaoxi.MES.Frame.Base;
using Zhaoxi.MES.Frame.Models;

namespace PrismMetroSample.Shell.ViewModels
{
    //public class MainWindowViewModel : BindableBase
    //{
    //    #region Fields

    //    private IModuleManager _moduleManager;
    //    private readonly IDialogService _dialogService;
    //    private IRegion _paientListRegion;
    //    private IRegion _medicineListRegion;
    //    private PatientList _patientListView;
    //    private MedicineMainContent _medicineMainContentView;

    //    #endregion

    //    #region Properties

    //    public IRegionManager RegionMannager { get; }

    //    private bool _isCanExcute = false;
    //    public bool IsCanExcute
    //    {
    //        get { return _isCanExcute; }
    //        set { SetProperty(ref _isCanExcute, value); }
    //    }

    //    #endregion

    //    #region Commands

    //    private DelegateCommand _loadingCommand;
    //    public DelegateCommand LoadingCommand =>
    //        _loadingCommand ?? (_loadingCommand = new DelegateCommand(ExecuteLoadingCommand));

    //    private DelegateCommand _activePaientListCommand;
    //    public DelegateCommand ActivePaientListCommand =>
    //        _activePaientListCommand ?? (_activePaientListCommand = new DelegateCommand(ExecuteActivePaientListCommand));

    //    private DelegateCommand _deactivePaientListCommand;
    //    public DelegateCommand DeactivePaientListCommand =>
    //        _deactivePaientListCommand ?? (_deactivePaientListCommand = new DelegateCommand(ExecuteDeactivePaientListCommand));

    //    private DelegateCommand _activeMedicineListCommand;
    //    public DelegateCommand ActiveMedicineListCommand =>
    //        _activeMedicineListCommand ?? (_activeMedicineListCommand = new DelegateCommand(ExecuteActiveMedicineListCommand).ObservesCanExecute(() => IsCanExcute));

    //    private DelegateCommand _deactiveMedicineListCommand;
    //    public DelegateCommand DeactiveMedicineListCommand =>
    //        _deactiveMedicineListCommand ?? (_deactiveMedicineListCommand = new DelegateCommand(ExecuteDeactiveMedicineListCommand).ObservesCanExecute(() => IsCanExcute));


    //    private DelegateCommand _loadMedicineModuleCommand;
    //    public DelegateCommand LoadMedicineModuleCommand =>
    //        _loadMedicineModuleCommand ?? (_loadMedicineModuleCommand = new DelegateCommand(ExecuteLoadMedicineModuleCommand));

    //    #endregion

    //    #region  Excutes

    //    void ExecuteLoadingCommand()
    //    {

    //        _paientListRegion = RegionMannager.Regions[RegionNames.PatientListRegion];
    //        _patientListView = ContainerLocator.Current.Resolve<PatientList>();
    //        _paientListRegion.Add(_patientListView);

    //        var uniformContentRegion = RegionMannager.Regions["UniformContentRegion"];
    //        var regionAdapterView1 = ContainerLocator.Current.Resolve<RegionAdapterView1>();
    //        uniformContentRegion.Add(regionAdapterView1);
    //        var regionAdapterView2 = ContainerLocator.Current.Resolve<RegionAdapterView2>();
    //        uniformContentRegion.Add(regionAdapterView2);

    //        _medicineListRegion = RegionMannager.Regions[RegionNames.MedicineMainContentRegion];
    //    }


    //    void ExecuteDeactiveMedicineListCommand()
    //    {
    //        _medicineListRegion.Deactivate(_medicineMainContentView);
    //    }

    //    void ExecuteActiveMedicineListCommand()
    //    {
    //        _medicineListRegion.Activate(_medicineMainContentView);
    //    }

    //    void ExecuteLoadMedicineModuleCommand()
    //    {
    //        _moduleManager.LoadModule("MedicineModule");
    //        _medicineMainContentView = (MedicineMainContent)_medicineListRegion.Views.Where(t => t.GetType() == typeof(MedicineMainContent)).FirstOrDefault();
    //        this.IsCanExcute = true;
    //    }

    //    void ExecuteDeactivePaientListCommand()
    //    {
    //        _paientListRegion.Deactivate(_patientListView);
    //    }

    //    void ExecuteActivePaientListCommand()
    //    {
    //        _paientListRegion.Activate(_patientListView);
    //    }

    //    #endregion

    //    public MainWindowViewModel(IModuleManager moduleManager,IRegionManager regionManager,IDialogService dialogService)
    //    {
    //        _moduleManager = moduleManager;
    //        RegionMannager = regionManager;
    //        _dialogService = dialogService;
    //        _moduleManager.LoadModuleCompleted += _moduleManager_LoadModuleCompleted;
    //    }


    //    private void _moduleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
    //    {
    //        _dialogService.ShowDialog("SuccessDialog", new DialogParameters($"message={e.ModuleInfo.ModuleName+ "模块被加载了"}"), null);
    //    }
    //}
    public class MainWindowViewModel : NotifyBase
    {
        // 菜单 集合
        public List<MenuItemModel> TreeList { get; set; }
        // 页面 集合
        public ObservableCollection<PageItemModel> Pages { get; set; }
            = new ObservableCollection<PageItemModel>();

        public MainWindowViewModel()
        {
            #region 菜单初始化
            TreeList = new List<MenuItemModel>();
            {
                MenuItemModel tim = new MenuItemModel();
                tim.Header = "MES";
                //&#xe740;  XAML里使用
                tim.IconCode = "\ue610"; // 字体图标编码，阿里的Iconfont平台打包的图标库
                TreeList.Add(tim);
                tim.Children.Add(new MenuItemModel
                {
                    Header = "SAP订单打印",
                    TargetView = "Material",
                    OpenViewCommand = new Command<MenuItemModel>(OpenView)
                });
                tim.Children.Add(new MenuItemModel
                {
                    Header = "初始化",
                    TargetView = "BlankPage",
                    OpenViewCommand = new Command<MenuItemModel>(OpenView)
                });

                tim.Children.Add(new MenuItemModel
                {
                    Header = "模块大类设计",
                    TargetView = "BlankPage"
                });
                MenuItemModel subMenu = new MenuItemModel();
                subMenu.Header = "二级菜单";
                subMenu.Children.Add(
                    new MenuItemModel
                    {
                        Header = "三级菜单"
                    }
                   );
                tim.Children.Add(subMenu);
            }
            #endregion
            #region 测试  页面初始
            // 所有数据集合都可以 VM中进行控件 （增加和删除）
            //Pages = new ObservableCollection<PageItemModel>();
            //Pages.Add("AAAA");
            //Pages.Add("BBBB");
            //Pages.Add("CCCC");
            //Pages.Add("DDDD");
            #endregion
        }
        private void OpenView(MenuItemModel menu)
        {
            // 两个问题：
            // 1、每点击一次都会有一个新的页面！  解决方案：从集合中判断是否存在
            // 2、新打开一个页面后，不能马上显示 
            //MenuItemModel mim = menu as MenuItemModel;
            // 需要进行页面的打开 
            //Pages.Add("EEEE");

            var page = Pages.ToList().FirstOrDefault(p => p.Header == menu.Header);

            if (page == null)
            {
                Type type = Assembly.GetExecutingAssembly().
                    GetType("PrismMetroSample.Shell.Views.Pages." + menu.TargetView);
                object p = Activator.CreateInstance(type);

                Pages.Add(new PageItemModel
                {
                    Header = menu.Header,
                    PageView = p,
                    IsSelected = true,
                    CloseTabCommand = new Command<PageItemModel>(ClosePage)
                });
            }
            else
                page.IsSelected = true;
        }

        private void ClosePage(PageItemModel menu)
        {
            Pages.Remove(menu);
        }
    }
}
