   M S B A M L   `   `   `  ����E  AWpfAppExam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfAppExam
WpfAppExam  5   	   ;"clr-namespace:WpfAppExam.ViewModelWpfAppExam.ViewModel  5   	   %    WpfAppExam.FolderExplorerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WpfAppExam     5   	   1vm"clr-namespace:WpfAppExam.ViewModel     5   	     � Title$  Folder Explorer��5	   	   $	��400��6!   $	��600��6.    � 	Resources 5
         RootFolderDataProvider S� ObjectInstance!   WpfAppExam.ViewModel.Folder �� DataType �� ItemsSource �� Path
 � Tag��%�   &	        (�� 2     5      *, +)S� 5   
    5        5      5      �� 5   
   "  5       5      �� $ 
SubFolders�.R�5      �� ��6   ��  6)   �� $ FullPath�5      5!      .��5"      �  � RowDefinitions 5#   
   �� 5$      �� 5%       � ColumnDefinitions 5'   
   �� 5(      �� 5)      .+�5,   
   R� -   5        	 R�Name$	 
trvFolders��5,      $��2��5-      $��Stretch=�6$   $��Stretch=�6B   .@�5.      Q� $��Folders��6s   ��6   �� $ 
SubFolders�
 �� Source#
 [  6s   50      �� 51   
   $��2��6   $��2��6(   �� 52   
   -   5         ��Name$ lstSubFolders��52      $��1��54      $��Stretch=�6#   $��Stretch=�6A   ��53      �� $ SelectedItem.SubFolders� �� ElementName$ 
trvFolders�� �� Mode$ OneWay=�54   _   �� 55   
   -   5        $ lstFiles��55      $��1��57      $��1��6#   $��Stretch=�60   $��Stretch=�6N   ��56      �� $ SelectedItem.Files�$ 
trvFolders��$ OneWay=���58      �� 59      .R�5:      � $��Stretch=�6   $��Stretch=�6:   .+�5;      �� 
�������$��Stretch=�64   $��Stretch=�6R   $��1q�6n   
����+�� �� CornerRadius$ 5��6�   �� 5<       �� Padding$ 5q�6S   ��6$   ��  65   �� $ FullPath�6S   5=      5>      5@      5B      5C      