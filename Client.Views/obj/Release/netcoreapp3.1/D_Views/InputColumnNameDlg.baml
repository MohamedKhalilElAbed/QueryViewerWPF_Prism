   M S B A M L   `   `   `  ����   Client.Views'    !Client.D_Views.InputColumnNameDlg   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  P LPrism.Wpf, Version=8.0.0.0, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59V RPrism.Unity.Wpf, Version=8.0.0.0, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True$	��220��$	��120��.���� .+���  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ oldColumnNamePrefix��$��
Old Name :���� -   $ oldColumnName��$��Center=����� *
OldColName+ �� UpdateSourceTrigger$ PropertyChanged=��� $ 
Horizontal=�.+��� -   $ newColumnName��$��
New Name :���� -    ��Name$ ResponseTextBox��$	��100��$
��Left=�$��Center=����� *NewColumnName+ �� Mode$ TwoWay=�$ PropertyChanged=��� $ 
Horizontal=�$��0,5,0,0q�.+��� $��OK��$	��100��$
��Left=�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Click��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 �� *DataContext.OKCommand+
 �� RelativeSource
 ��  �� AncestorType" >��� $��Cancel��$	��100��$
��Left=�$��2,0,0,0q�   $ Click��.   	 �� *DataContext.CancelCommand+
 �� " >�