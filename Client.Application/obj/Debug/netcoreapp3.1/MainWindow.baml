   M S B A M L   `   `   `  ����@  <Prism, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null>+clr-namespace:Prism.Commands;assembly=PrismPrism.Commands  5   	   :)clr-namespace:Prism.Events;assembly=PrismPrism.Events  5   
   4&clr-namespace:Prism.Ioc;assembly=Prism	Prism.Ioc  5   
   B-clr-namespace:Prism.Modularity;assembly=PrismPrism.Modularity  5   
   P LPrism.Wpf, Version=8.0.0.0, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59@.clr-namespace:Prism.Regions;assembly=Prism.WPFPrism.Regions 5   
   :+clr-namespace:Prism.Mvvm;assembly=Prism.WPF
Prism.Mvvm 5	   	    Client.Application#   Client.Application.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   DprismComands+clr-namespace:Prism.Commands;assembly=Prism     5   	   AprismEvents)clr-namespace:Prism.Events;assembly=Prism     5   
   ;prismIoc&clr-namespace:Prism.Ioc;assembly=Prism     5   
   IprismModularity-clr-namespace:Prism.Modularity;assembly=Prism     5   
   GprismRegions.clr-namespace:Prism.Regions;assembly=Prism.WPF     5   
   A	prismMvvm+clr-namespace:Prism.Mvvm;assembly=Prism.WPF     5	   	   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5
   	   $	��350��5   !   $	��525��6.    � WindowState$ 	Maximized=�6:    � Title 6	   �� *Title+ � 	Resources 5      ��%    5      .��5      ]� $
��True��6   .+�5   
   o� $	��Top=�6   !  Prism.Regions.RegionManager   
RegionName$ MenuContentRegion��6$   $��5q�6^   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $
��auto��6.   .+�5      � -   5         �Name$ RequetesListViewContent��5      $
��Left=�66   .+�5      �� $ RequeteListContentRegion��6!   5      � 5      -   5        $ ActionTabViewContent��5      $��right=�62   .+�5      �� -   5         ��Name$ 	actionTab��5   !   $ TabsContentRegion��64   5      5      5      5      