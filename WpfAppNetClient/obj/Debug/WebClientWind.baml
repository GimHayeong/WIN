   M S B A M L   `   `   `  ����J  FWpfAppNetClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfAppNetClientWpfAppNetClient  5   	   #    WpfAppNetClient.WebClientWind   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfAppNetClient     5   	     � Title$  
Web Client��5   	   $	��300��6   $	��600��6)   .��5	      ]�  � 	Resources 5
   
    �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value�� 5      %�   '��       �� 5      " ��6   .�5      ��  � ��$ 5q�60   �� 5       � ��$
 2, 0q�6/    5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
 �����6;   5      5      5      .+�5   
   �� $	��Top=�6   $$��읽어올 웹페이지 주소:��6%   �� 5   
   -   5         ��Name$ tbxUrl��5      $	��Top=�6"   $	��5,0q�67   $#��http://dic.daum.net/search.do��6D   �� 5   
   	 �� Orientation$	 
Horizontal=�6   $	��Top=�6.   $��5q�6C   .+�5      �� -   5        
 ��Name$
 btnDownloadData��5      $
��HTML��6.   6=   �� 5      -   5        $ tbxFileName��5      $��80��6+   $	��2,0q�66   $��
dnHtml.htm��6C   �� 5      -   5        $
 btnDownloadFile��5      $��SaveFile��6.   6A   �� 5      -   5        $
 btnUploadFile��5      $��
UploadFile��6,   6A   �� 5      -   5        $
 btnDownloadHeader��5      $��Header��60   6A   5      �� 5    
   $	 
Horizontal=�6   $	��Top=�6.   $��5q�6C   .+�5!      �� $	��ID:��6   $��0q�6"   $��Center=�6.   �� 5"      -   5        $ tbxID��5"      $��80��6%   $	��2,0q�60   �� 5#      $��	Password:��6   $��0q�6(   $��Center=�64   �� 5$      -   5        $ tbxPwd��5$      $��80��6&   $	��2,0q�61   �� 5%      $��Name:��6   $��0q�6$   $��Center=�60   �� 5&      -	   5        $ tbxName��5&      $��80��6'   $	��2,0q�62   �� 5'      -
   5        $
 btnUploadValues��5'      $	��Get��6.   6<   �� 5(      $��
검색어:��6   $��0q�6#   $��Center=�6/   $��10,0,0,0q�6Q   �� 5)      -   5        $ 	tbxSearch��5)      $��80��6)   $	��2,0q�64   �� 5*      -   5        $
 btnOpenWrite��5*      $
��Post��6+   6:   5+      �� 5,   
   $��Stretch=�6   $��Stretch=�65   $��Bottom=�6Q   .��5-      �� -   5         ��Name$ 	tbkResult��5-      $��Stretch=�6+   $	��190��6I   $��5q�6Y   $��Stretch=�6d   5.      5/      50      