   M S B A M L   `   `   `  ����H  DWpfAppWebInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfAppWebInfoWpfAppWebInfo  5   	   !    WpfAppWebInfo.WebReaderWind   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfAppWebInfo     5   	     � Title$  HTML Reader Ver 1.0��5   	   $	��300��6%   $	��500��62   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��2��6   $��15(�6$   $,��&웹 페이지 HTML 소스 가져오기��62   �� 5   
   -   5         ��Name$ tbxInfo��5      $��1��6#   $��2��60   $��5q�6D   " �� VerticalScrollBarVisibility$
 Auto=�6O   �� 5   
   -   5        $ tbxUrl��5      $��2��6"   $��http://www.daum.net��6/   $��5q�6J   6U   �� 5   
   -   5         ��Name$ btnRead��5      $��2��6"   $��1��6/   $��소스보기��6?   $��5q�6N   6Y   5      5      