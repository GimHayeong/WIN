   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfPhotoGalleryWpfPhotoGallery  5      %    WpfPhotoGallery.PagPhotoGallery   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WpfPhotoGallery     5        N� Title$  PagPhotoGallery��5	      .��5      ]� .+�5   
   �� $	��Top=�6   
��� ���.+�5      o� $��Center=�6   
������ $��0, 10q�6I   .@�5      m� $��_File��6   m� 5      $
��_Fax��6   m� 5      $��_Print��6   m� 5      $��_Edit��6   5      �� 5      Click �� 6   $��PagHistory.xaml?�6)   .�6G   hear6M    to view the photo.6l   5      �� 5   
   $��Bottom=�6   
������.+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $	��0,7q�6O   .+�5      �� -   5         ��Name$ 	btnSearch��5      
������ $��5q�6E   $
��10,0q�6P   $��검색��6_   �� 5      -   5        $ btnIcon��5      
������ $��5q�6C   $
��10,0q�6N   $��	아이콘��6]   �� 5      -   5        $ btnPrev��5      
������ $��5q�6C   $
��10,0q�6N   $��이전��6]   6j   �� 5      -   5        $ btnLarge��5      
������ $��5q�6D   $
��10,0q�6O   $��큰아이콘��6^   �� 5      -   5        $ btnNext��5      
������ $��5q�6C   $
��10,0q�6N   $��다음��6]   6j   �� 5      
������ $��5q�62   $
��10,0q�6=   $��실행취소��6L   �� 5      
������ $��5q�62   $
��10,0q�6=   $��다시실행��6L   �� 5      
������ $��5q�62   $
��10,0q�6=   $��삭제��6L   5       5!      R� 5"   
   -   5         R�Name$ trvFolderExplorer��5"      $
��Left=�6.   $
��Left=�6D   $��Stretch=�6_   $	��100��6{   .@�5#      Q� -   5         Q�Name$ trvItmFavorites��5#      $��	Favorites��64   .@�5$      Q� $��C:\Users\Adam\Pictures��6   
 � Tag$ C:\Users\Adam\Pictures��6?   5%      Q� 5&      -   5        $ trvItmFolder��5&      $��Folders��61   .@�5'      Q� $	��C:\��6   $	 C:\��6,   Q� 5(      $	��D:\��6   $	 D:\��6,   Q� 5)      $	��E:\��6   $	 E:\��6,   5*      5+      �� 5,   
   6   5.      5/      