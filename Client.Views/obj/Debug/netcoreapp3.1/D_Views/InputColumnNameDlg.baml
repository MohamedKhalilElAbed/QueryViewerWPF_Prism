   M S B A M L   `   `   `  ����  Client.Views'    !Client.D_Views.InputColumnNameDlg   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   P LPrism.Wpf, Version=8.0.0.0, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59V RPrism.Unity.Wpf, Version=8.0.0.0, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5   	   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5   	   $	��220��5
   	   $	��120��6   .��5      �� .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ oldColumnNamePrefix��5      $��
Old Name :��61   �� 5      -   5        $ oldColumnName��5      $��Center=�6p   ��6+   �� *
OldColName+ �� UpdateSourceTrigger$ PropertyChanged=�6p   5      �� 5   
   $ 
Horizontal=�6   .+�5      �� -   5        $ newColumnName��5      $��
New Name :��6+   �� 5      -   5         ��Name$ ResponseTextBox��5      $	��100��6/   $
��Left=�6�   $��Center=�6�   ��6;   �� *NewColumnName+ �� Mode$ TwoWay=�$ PropertyChanged=�6�   5      �� 5   
   $ 
Horizontal=�6   $��0,5,0,0q�6.   .+�5      �� $��OK��6   $	��100��6#   $
��Left=�60   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ Click��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 61   �� *DataContext.OKCommand+
 �� RelativeSource
 ��  �� AncestorType" >�5       5"      �� 5#      $��Cancel��6   $	��100��6'   $
��Left=�64   $��2,0,0,0q�6O    5$        5%      $ Click��6%   . 5&        	 61   �� *DataContext.CancelCommand+
 �� " >�5'      5)      5*      5+      5,      