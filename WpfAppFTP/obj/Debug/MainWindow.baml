   M S B A M L   `   `   `  ����D  @WpfAppFTP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfAppFTP	WpfAppFTP  5   	       WpfAppFTP.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfAppFTP     5   	   -   5          � Title$  FTP Ver 1.0��5	   	   $	��350��6   $	��500��6*   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ btnStart��5      $��5q�6#   $��서버 시작��6.   6>   �� 5   
   -   5         ��Name$ tbxIP��5      $��1��6!   $��5q�61   6<   �� 5   
   -   5        $ 
btnConnect��5      $��5q�6%   $��2��60   $��2��6@   $��서버 연결��6Q   6a   �� 5   
   $��전송할 파일 정보��6   $��1��6$   $��2��61   �� 5   
   -   5        $ tbxInfo��5      $��2��6#   $��3��60   $��5q�6D    �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�6a   � 5   
   -   5         �Name$ pgbTrans��5      $��3��6(   $��3��65   $��10��6I   $	��5,0q�6X   �� 5   
   -   5        $ btnSelectFile��5      $��4��6(   $��3��65   $��전송파일선택��6I   $��5q�6Z   6e   5      5      