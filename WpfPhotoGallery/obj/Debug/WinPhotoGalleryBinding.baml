   M S B A M L   `   `   `  ����J  FWpfPhotoGallery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfPhotoGalleryWpfPhotoGallery  5   	   E'clr-namespace:WpfPhotoGallery.ViewModelWpfPhotoGallery.ViewModel  5   	   ,    &WpfPhotoGallery.WinPhotoGalleryBinding   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfPhotoGallery     5   	   6vm'clr-namespace:WpfPhotoGallery.ViewModel     5   	   -   5          � Title$  포토갤러리 바인딩��5
   	   $	��500��6   $	��800��6(    � 	Resources 5       �� MergedDictionaries �� Source 	  close  RootFolderDataProvider S� ObjectInstance&    WpfPhotoGallery.ViewModel.Folder �� DataType �� ItemsSource �� Path
 � Tag�� 5   
    5      �� 5      $ resFile01.xaml?�6%   �� 5      $ resFile02.xaml?�6%   �� 5      $ resPhotoGallery.xaml?�6%   %5  &	        &	 R     (�� �     5   '   *, +)�� 5      $��21��6"   $0��*pack://application:,,,/Resources/close.png��6.   S� 5       5        5      5      �� 5      "  6'    5   '   �� $ 
SubFolders�.R�5      �� ��6   ��  5      �� $ FullPath�5      5      .��5      � 	 � RowDefinitions	 5    
   �� 5!      $��50��6   $��50 �6+   �� 5"      �� 5#      $��55��6   $��55 �6+   
 � ColumnDefinitions
 5%   
   �� 5&      $	��200��6   $	��200 �6.   �� 5'      $
��Auto �6   �� 5(      .+�5*   
   �� $��3��6     bgMenuBrush#��[ 6)   �� 5+   
   $��2��6   $��3��6!   #��[ 65   o� 5-   
   $��3��6   $��Center=�6#   
������ 
�������$��0, 10q�6l   .@�5.      m� $��
파일(_F)��6     MenuItemStyle#��[ 6'   .@�5/      m� -   5         m�Name$ mnuAdd��5/      $ ��즐겨찾기에 추가(_A)��6+     SubMenuItemStyle#��[ 6A   {�.  6}   m� 50      -   5        $ 	mnuDelete��50      $��
삭제(_L)��6.   #��[ 6>   {�.  6z   m� 51      -   5        $ 	mnuRename��51      $��이름바꾸기(_M)��6.   #��[ 6A   {�.  6}   �� 52      m� 53      -   5        $ 
mnuRefresh��53      $��새로고침(_R)��6/   #��[ 6A   6k   �� 54      m� 55      -   5        $ mnuExit��55      $��
종료(_X)��6,   #��[ 6<   6f   56      m� 57      -   5        $ mnuFix��57      $��
고정(_I)��6(   #��[ 68   {�.  6q   m� 58      -   5        $ mnuPrint��58      $��
인쇄(_P)��6)   #��[ 69   {�.  6r   m� 59      -	   5        $ mnuEdit��59      $��
편집(_E)��6(   #��[ 68   {�.  6q   5:      �� 5;   
   -
   5         ��Name$ btnBack��5;      $y�Hidden=�67   .��6K   Back To Gallery6\   R� 5>   
   -   5         R�Name$ trvFolderExplorer��5>      $��1��6.   $��0q�6;   $��Stretch=�5?      $��Stretch=�61    %� IsVirtualizing .  %� VirtualizationMode$ 	Recycling=�5A       � DataContext 5C      )   #WpfPhotoGallery.ViewModel.ViewModel  5D      .@�5F      Q� -   5         Q�Name$ trvItmFavorites��5F      $��	Favorites��5G      ��5H      �� *FavoriteList+��5I      �� 5J      (   "WpfPhotoGallery.ViewModel.Favorite"  6/   .R�5K      �� ��6$   ��  65   �� 5L      5O      Q� 5P      -   5        $ trvItmFolder��5P      $��Folders��5Q      ��5R      �� $ 
SubFolders� �� Source# [ 5S      5T      �� 5U   
   $��1��6   $��1��6'   $��Stretch=�64   $
��Left=�6P   $��2��6k    �� ResizeBehavior$ PreviousAndNext=�6u   �� 5V   
   -   5         ��Name$ 
lbxPicture��5V      $��1��6&   $��2��63   $��0q�6C   $��Disabled=�6W   ��5W      �� 5X      .R�5Y      � 5Z      5\      ]� 5`   
   -   5         ]�Name$ pnlImageView��5`      $��1��6*   $��3��67   $y�Hidden=�6K    J� SnapsToDevicePixels . .+�5a      �� -   5         ��Name$ 	pnlFixbar��5a        bgButtonBrush#��[ 6,   .+�5b      �� -   5        $ btnRotateCW��5b      $��20q�6.   .��6O   Rotate Clockwise6a   �� 5c      -   5        $ btnRotateCCW��5c      $��20q�6/   .��6P   Rotate Counterclockwise6i   �� 5d      -   5        $ btnRotateSave��5d      $��20q�60   .��6Q   Save6W   5e      � 5f      
�������.+�5g      �� -   5         ��Name$ 	imgViewer��5g      $��Center=�6+    � LayoutTransform 5h      �� 5i      5k      5l      5m      � 5q   
   $��2��6   $��3��6   
 5r      �� 5s      �� 5t      $
��Auto �6#   �� 5u      .+�5w      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5x      �� -   5        $ btnZoom��5x      $��Center=�6*    �� 	ClickMode$ Press=�6E    � ToolTip$ 확대/축소��6W   .��5y      �� $��22��6   $��images\zoom.gif��6(   5z      � 5|      -   5         �Name$ popZoom��5|      $��Center=�6Y    � 	StaysOpen .   � PlacementTarget 6)   ��   �� ElementName$  btnZoom��.��5}      � 
�������.+�5~      �� 
���   �$��1q�65   ! �� CornerRadius$! 5��6I   ._�5      �� -   5        " ��Name$" sldZoom��5   %   $��20q�66   # �� Orientation$# Vertical=�6B   $ � Minimum$$ 1Q�6Y   % � Maximum$% 10Q�6e   $	��100��6r   6�   5�      5�      5�      �� 5�      -   5        $ btnDefaultSize��5�      $��Center=�61   $ 원래사이즈��6L   .��5�      �� $��22��6   $%��images\defaultThumbnailSize.gif��6(   5�      5�      �� 5�      $��1��6   $ 
Horizontal=�6)   $��Center=�6B   .+�5�      �� -   5        $ btnPrev��5�      $��Center=�6*   $ 이전이미지��6E   .��5�      �� $��22��6   $��images\previous.gif��6(   5�      �� 5�      -   5        $ btnSlideShow��5�      $��Center=�6/   $ 슬라이드쇼��6J   $��52��6Z   $��42��6e   {�.  & J� Opacity$& .5Q�6�   .��5�      �� $��22��6   $��images\slideshow.gif��6(   5�      �� 5�      -   5        $ btnNext��5�      $��Center=�6*   $ 다음이미지��6E   {�.  $& .5Q�6g   .��5�      �� $��22��6   $��images\next.gif��6(   5�      5�      �� 5�      $��2��6   $ 
Horizontal=�6)   $
��Left=�6B   .+�5�      �� -   5        $ btnCounterClockWise��5�      $��Center=�66   $ 반시계방향회전��6Q   .��5�      �� $��22��6   $!��images\counterclockwise.gif��6(   5�      �� 5�      -   5        $ btnClockWise��5�      $��Center=�6/   $ 시계방향회전��6J   {�.  $& .5Q�6m   .��5�      �� $��22��6   $��images\clockwise.gif��6(   5�      �� 5�      -   5        $ 	btnDelete��5�      $��Center=�6,   $ 삭제��6G   {�.  $& .5Q�6f   .��5�      �� $��22��6   $��images\delete.gif��6(   5�      5�      5�      5�      5�      