   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfPhotoGalleryWpfPhotoGallery  5   	       WpfPhotoGallery.DlgRename   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfPhotoGallery     5   	     � Title$  파일 이름 바꾸기��5   	   $	��150��6   $	��300��6(    � 
ResizeMode$ NoResize=�64   .��5	      �� .+�5
   
   �� $��	10,5,10,0q�6   .��6#   &$새로운 이름을 입력하세요.63   �� 5   
   -   5         ��Name$ 
tbxNewName��5      $��
15,0,15,20q�6&   �� 5   
    �� Orientation$ 
Horizontal=�6   $��RightToLeft=�6.   .+�5      �� -   5         ��Name$ 	btnCancel��5      $��50��6(   $��15,0,5,0q�63    �� IsCancel . .��6U   취소6Y   �� 5      -   5        $ btnOK��5      $��50��6$   .��6D   확인6H   5      5      5      