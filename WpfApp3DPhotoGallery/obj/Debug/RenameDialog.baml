   M S B A M L   `   `   `  ����O  KWpfApp3DPhotoGallery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfApp3DPhotoGalleryWpfApp3DPhotoGallery  5   	   '    !WpfApp3DPhotoGallery.RenameDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfApp3DPhotoGallery     5   	     � Title$&   파일명 변경 다이얼로그��5   	   $	��150��6   $	��300��6+   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��Choose a new name:��6   �� 5   
   -   5         ��Name$ tbxFileName��5      6'   �� 5   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5      �� -   5        $��OK��5      $��0,0,5,0q�6"   63   �� 5      $��Cancel��6    �� IsCancel . 6&   5      5      5      