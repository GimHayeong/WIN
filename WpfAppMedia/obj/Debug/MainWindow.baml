   M S B A M L   `   `   `  ����F  BWpfAppMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppMediaWpfAppMedia  5   	       WpfAppMedia.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfAppMedia     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      �  � 	Resources 5
   
    �� 
TargetType �� Property �� Value�� 5      %|   '��       �� 5      " ��6   .�5      ��  � ��$
 10,5q�60   �� 5       � ��$ Center=�6<   5      5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��Center=�6   $��Confirm��6.   $
��10,5q�6@    � Triggers 5      :� 5       :� RoutedEvent$ Button.Click��6   [�5      �� 5       �� Source$ Sound/click.wav?�6,   5      :� 5      $ Button.MouseEnter��6   [�5      �� 5       $ Sound/hover.wav?�6,   5"      5$      r� 5&   
   -   5        	 r�Name$	 audio��5&      $��1��6&   52      �� 54   
   $��2��6   
 �� Orientation$
 
Horizontal=�6"   $��Center=�6;   .+�55      �� $
��Play��6    56      :� 57      $ Button.Click��6#   [�58      �� 59      .��5:   "   �� .��5;   &   p�  p� Source$ Sound/click.wav?�64    �� 
TargetName$ audio��6M   5<   #   5=      5?      :� 5@      $ Button.MouseEnter��6#   [�5A      �� 5B      .��5C   "   �� .��5D   &   p� $ Sound/hover.wav?�64   $ audio��6M   5E   #   5F      5H      5J      5K      5M      5N      