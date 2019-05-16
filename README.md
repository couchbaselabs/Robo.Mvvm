# Robo.Mvvm

<img align="right" src="https://github.com/couchbaselabs/Robo.Mvvm/blob/master/src/Robo.Mvvm/packaging/nuget/logo.png?raw=true" />

The purpose of these projects are to simplify the creation simple/prototype [Xamarin.Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/) apps. 

Again, these projects include a **small** set of functionality with the overall function being to create simple `Xamarin.Forms` apps that adhere to the [Model-View-ViewModel (MVVM)](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel) design pattern. 

_(Much like how a simple robo..t exists to perform a few, targeted functions. Yea, see what I did there?)_


# Table of Contents
1. [Project Summary](#project-summary)
2. [Getting Started](#getting-started)
    1. [Grab Dat Nuget!](#grab-dat-nuget)
    1. [Initializing](#initializing)
3. [Coupling Pages to ViewModels](#coupling-pages-to-viewmodels)
    1. [Pages](#pages)
    2. [ViewModels](#viewmodels)
4. [Navigation](#navigation)
5. [Dependency Injection](#dependency-injection)
6. [Sample](#sample)
7. [Contribute](#contribute)

## Project Summary<a href="project-summary"></a>

* **`Robo.Mvvm`** is a project that contains a few classes/enumerations/etc. to help quickly spin up a platform agnostic Model-View-ViewModel (MVVM) architectural design approach for an application. 

* **`Robo.Mvvm.Forms`** is a project that uses the `Robo.Mvvm` project, and provides a set of `Xamarin.Forms` specific class/object extensions that make creating prototype and simple `Xamarin.Forms` apps painless. 

## Getting Started<a href="getting-started"></a>

### Grab Dat Nuget!<a href="grab-dat-nuget"></a>
Yes, there's a nuget for this! In fact, there are two:

1. `Robo.Mvvm` [![GitHub release](https://img.shields.io/nuget/v/Robo.Mvvm.svg?style=plastic)](https://www.nuget.org/packages/Robo.Mvvm)

2. `Robo.Mvvm.Forms` [![GitHub release](https://img.shields.io/nuget/v/Robo.Mvvm.Forms.svg?style=plastic)](https://www.nuget.org/packages/Robo.Mvvm.Forms)

So, you may be wondering, which one do I use and where? Well, there's a simple answer to this; if the project you're adding it to needs the `Xamarin.Forms` Nuget then you'll need to reference both `Robo.Mvvm` and `Robo.Mvvm.Forms`. If not, then you'll just need to include `Robo.Mvvm`. 

**Pro Tip:** Remember that two important functions of the MVVM pattern are

1. Maximize reuse which helps...(see point 2)
2. Remain **completely** oblivious to the anything "View Level". This includes packages like `Xamarin.Forms`. 

So, it's best to separate your `Xamarin.Forms` app/view level code (i.e. ContentPage, ContentView, Button, etc.) from your ViewModels. At the very least, in separate projects. <./rant>

### Initializing<a href="initializing"></a>

Once the Nuget packages have been installed you will need to initialize `Robo.Mvvm.Forms`. Add the following line to the `App` method in `App.xaml.cs`:

```csharp
public App()
{
    InitializeComponent();

    // Add this line!
    Robo.Mvvm.Forms.App.Init<RootViewModel>(GetType().Assembly);

    // Where "RootViewModel" is the ViewModel you want to be your MainPage
}
```

This accomplishes two things:

1. Registers and couples the Views to ViewModels
2. The _Generic_ () assigned to the `Init` method establishes the `MainPage` (and coupled ViewModel).

## Coupling Pages to ViewModels<a href="coupling-pages-to-viewmodels"></a>

### Pages<a href="pages"></a>

All Base page perform two main operations upon instantiation:

1. Set the BindingContext to the appropriate _ViewModel_ received via generic.
2. Executes the `InitAsync` method of the instantiated _ViewModel_. This is good for functionality you'd like executed upon page creation. `InitAsync` is optional - it exists as a `virtual` method in the base viewmodel.

#### BaseContentPage

Inherit from `BaseContentPage` from all `ContentPage` implementations.

##### XAML

```xml
<?xml version="1.0" encoding="UTF-8"?>
<pages:BaseContentPage 
    xmlns="http://xamarin.com/schemas/2014/forms" 
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
    xmlns:pages="clr-namespace:Robo.Mvvm.Forms.Pages;assembly=Robo.Mvvm.Forms"
    xmlns:vm="clr-namespace:PrototypeSample.Core.ViewModels;assembly=PrototypeSample.Core"
    x:TypeArguments="vm:ViewModel1"
    x:Class="PrototypeSample.Pages.ContentPage1"
    Title="Page 1">
    <pages:BaseContentPage.Content>
           
        <!-- Content here -->
                
    </pages:BaseContentPage.Content>
</pages:BaseContentPage>
```

Key takeaways: <a href="content-page-xaml"></a>

1. Change `ContentPage` to `pages:BaseContentPage` ('pages' can be whatever you name it - see #2.1 below)
2. Include XML namespaces (xmlns) declarations for 
    1. `Robo.Mvvm.Forms.Pages`
    2. The namespace where the ViewModel that you want to bind to this page.
3. Add the `TypeArgument` for the specific ViewModel you want to bind to this page.

##### CS

The `ContentPage` implementation just needs to inherit from `BaseContentPage` and provide the _ViewModel_ to be bound to the `Page`.

```csharp
public partial class ContentPage1 : BaseContentPage<ViewModel1>
```

#### BaseMasterDetailPage

##### XAML

```xml
<?xml version="1.0" encoding="utf-8"?>
<pages:BaseMasterDetailPage 
    xmlns="http://xamarin.com/schemas/2014/forms" 
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
    xmlns:pages="clr-namespace:Robo.Mvvm.Forms.Pages;assembly=Robo.Mvvm.Forms"
    xmlns:vm="clr-namespace:PrototypeSample.Core.ViewModels;assembly=PrototypeSample.Core"
    x:TypeArguments="vm:RootViewModel"
    x:Class="PrototypeSample.Pages.RootPage">

</pages:BaseMasterDetailPage>
```
Key takeaways: _See [ContentPage XAML](#content-page-xaml)_.

##### CS

The `MasterDetailPage` implementation just needs to inherit from `BaseMasterDetailPage` and provide the _BaseMasterDetailViewModel_ to be bound to the `Page`.

```csharp
public partial class RootPage : BaseMasterDetailPage<RootViewModel>
```

#### BaseTabbedPage

##### XAML

```xml
<?xml version="1.0" encoding="utf-8"?>
<pages:BaseTabbedPage 
    xmlns="http://xamarin.com/schemas/2014/forms" 
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
    xmlns:pages="clr-namespace:Robo.Mvvm.Forms.Pages;assembly=Robo.Mvvm.Forms"
    xmlns:vm="clr-namespace:PrototypeSample.Core.ViewModels;assembly=PrototypeSample.Core"
    x:TypeArguments="vm:CollectionViewModel"
    x:Class="PrototypeSample.Pages.TestTabbedPage"
    Title="Tabbed Page">
</pages:BaseTabbedPage>

```
Key takeaways: _See [ContentPage XAML](#content-page-xaml)_.

##### CS

The `TabbedPge` implementation just needs to inherit from `BaseTabbedPage` and provide the _BaseCollectionViewModel_ to be bound to the `Page`.

```csharp
public partial class TestTabbedPage : BaseTabbedPage<CollectionViewModel>
```

### ViewModels<a href="viewmodels"></a>

#### BaseNotify

`BaseNotify` is an abstract class that implements INotifyPropertyChanged, and provides implementations for:

PropertyChanged
```csharp
public event PropertyChangedEventHandler PropertyChanged;
```

SetPropertyChanged
```csharp
public void SetPropertyChanged(string propertyName)
{ ... }

protected virtual bool SetPropertyChanged<T>(ref T currentValue, T newValue, [CallerMemberName] string propertyName = "")
{ ... }
```

#### BaseViewModel

`BaseViewModel` inherits from `BaseNotify`. 

You can inherit from the abstract class `BaseViewModel` for all navigation enabled ViewModels, and ViewModels you want to bind to `BaseContentPage`. Note that you are _not_ limited to only binding to `BaseContentPage`

```csharp
public class ViewModel1 : BaseViewModel
```

<a href="base-vm-properties"></a>
Properties available: 

* IsBusy (`bool`)

Methods available:

* InitAsync: a virtual method that returns a task. This method is executed upon page creation.
* GetViewModel: returns an instantiated _ViewModel_ via generic.

#### BaseMasterDetailViewModel

Inherit from abstract class `BaseMasterDetailViewModel` for ViewModels you want to bind to a `BaseMasterDetailPage`. 

```csharp 
public class RootViewModel : BaseMasterDetailViewModel
{
    public RootViewModel(INavigationService navigationService) : base(navigationService)
    {
        var menuViewModel = GetViewModel<MenuViewModel>();
        menuViewModel.MenuItemSelected = MenuItemSelected;

        Master = menuViewModel;
        
        Detail = GetViewModel<CollectionViewModel>();
    }

    void MenuItemSelected(BaseViewModel viewModel) => SetDetail(viewModel);
}
```

`BaseMasterDetailViewModel` inherits from `BaseViewModel`, and because of this all of the [properties/methods](#base-vm-properties) available in `BaseViewModel` are also available in `BaseMasterDetailViewModel`.

Addition properties available: 

* Master (`BaseViewModel`)
* Detail (`BaseViewModel`)

Additional methods available:

* SetDetail: allows you to set the Detail _ViewModel_.

#### BaseCollectionViewModel

Inherit from the abstract class `BaseCollectionViewModel` for ViewModels you want to bind to a `BaseTabbedDetailPage`. 

```csharp
public class CollectionViewModel : BaseCollectionViewModel
```

`BaseCollectionViewModel` inherits from `BaseViewModel`, and because of this all of the [properties/methods](#base-vm-properties) available in `BaseViewModel` are also available in `BaseCollectionViewModel`.

Addition properties available: 

* EnableNavigation (`bool`) - defaulted to true - determines if the page will exist within navigation stack (page)
* SelectedIndex (`int`)
* SelectedViewModel (`BaseViewModel`)
* ViewModels (`List<BaseViewModel>`)

## Navigation<a href="navigation"></a>

Navigation from one _ViewModel_ to another is very simple. Below are samples, using 'Navigation' for an 'INavigationService' resolution, we are able to perform several actions.

### Push
```csharp
await Navigation.PushAsync<ViewModel>();
await Navigation.PushAsync(GetViewModel<ViewModel>());
```

### Push Modal
```csharp
await Navigation.PushModalAsync<ViewModel>();
await Navigation.PushModalAsync(GetViewModel<ViewModel>());
```

### Pop
```csharp
await Navigation.PopAsync();
```

### Set Root
```csharp
await Navigation.SetRoot<ViewModel>();
await Navigation.SetRoot(GetViewModel<ViewModel>());
```

## Dependency Injection<a href="dependency-injection"></a>

Simple Dependency Injection is exposed through a class called `ServiceContainer` that merely wraps [Simple Injector](https://simpleinjector.org/index.html). 

### Registration

```csharp
Service.Container.Resolve<IAlertService>();
```

### Resolving (Manually)

```csharp
ServiceContainer.Register<IAlertService>(new AlertService());
```

### Constructor Injection
```csharp
public ViewModel1(INavigationService navigationService)
```

## Sample<a href="#sample"></a>

Please feel free to clone this repository, and run the sample located [here](https://github.com/couchbaselabs/Robo.Mvvm/tree/master/sample). The sample app contains a demonstration of all the major features included in `Robo.Mvvm` and `Robo.Mvvm.Forms`.

## Contribute<a href="#contribute"></a>
    
Please feel free to contribute to this project! I certainly need all the help I can get, and welcome all PR's, issues, questions, etc. You can also contact me at [robert.hedgpeth@couchbase.com](mailto:robert.hedgpeth@couchbase.com) and on [Twitter](https://twitter.com/probablyrealrob).



