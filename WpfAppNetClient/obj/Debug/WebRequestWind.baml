   M S B A M L   `   `   `  ����J  FWpfAppNetClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfAppNetClientWpfAppNetClient  5   	   $    WpfAppNetClient.WebRequestWind   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfAppNetClient     5   	     � Title$  WebRequestWind��5   	   $	��300��6    $	��300��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $
��URL:��6   �� 5   
   -   5         ��Name$ tbxUrl��5      $��1��6"   $��5q�62   $��Stretch=�6=   $��http://��6[   �� 5   
   -   5         ��Name$ 
btnRequest��5      $��2��6%   $��읽어오기��65   $��5q�6D   6O   �� 5   
   $��HTTP 헤더 정보:��6   $��1��6&   $��3��63   �� 5   
   -   5        $ tbxHeaderInfo��5      $��2��6)   $��3��66   $
��10,0q�6J   �� 5   
   $��HTML:��6   $��3��6    $��3��6-   �� 5   
   -   5        $ tbxHTML��5      $��4��6#   $��3��60   $
��10,0q�6D   5       5!      