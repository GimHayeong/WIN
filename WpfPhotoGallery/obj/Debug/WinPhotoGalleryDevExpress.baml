   M S B A M L   `   `   `  ����J  FWpfPhotoGallery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfPhotoGalleryWpfPhotoGallery  5   	   E'clr-namespace:WpfPhotoGallery.ViewModelWpfPhotoGallery.ViewModel  5   	   /    )WpfPhotoGallery.WinPhotoGalleryDevExpress   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfPhotoGallery     5   	   6vm'clr-namespace:WpfPhotoGallery.ViewModel     5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   Gdxbt<http://schemas.devexpress.com/winfx/2008/xaml/bars/themekeys  5	   	   f bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5
   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	     � Title$   Photo Gallery : DevExpress��5   	   $	��400��6,   $	��600��69    � 	Resources 5       �� MergedDictionaries �� Source   bgBrush �� 
StartPoint �� EndPoint � Offset � Color �� 
TargetType<  6DevExpress.Xpf.Bars.Themes.BarControlThemeKeyExtension�  �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionInternalBase`1[[DevExpress.Xpf.Bars.Themes.BarControlThemeKeys, DevExpress.Xpf.Core.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]	   ResourceKey:  4DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionGeneric
   	ThemeName  RootFolderDataProvider S� ObjectInstance)   #WpfPhotoGallery.ViewModel.ViewModel �� DataType&    WpfPhotoGallery.ViewModel.Folder �� ItemsSource �� Path �� 	Converter:   4WpfPhotoGallery.ViewModel.FolderToShortPathConverter
 � Tag�� 5   
    5      �� 5      $ resFile01.xaml?�6%   �� 5      $ resFile02.xaml?�6%   �� 5      $ resPhotoGallery.xaml?�6%   %�  &	        (  N    5      $	 ControlTemplate=�$
 Office2007Silver��)&	 �    (�� �    5<   '   *, +)�� 5      $	 0,0&�62   $	 0,1&�6C   .��5      � $ 0Q�6   $
 Gray��6*   � 5      $	 0.9Q�6   $ 	#FF222222��6,   � 5      $	 0.9Q�6   $ Black��6,   � 5      $	 0.9Q�6   $ Black��6,   � 5      $	 0.9Q�6   $ 	#FF222222��6,   � 5      $ 1Q�6   $
 Gray��6*   5      �� 5      " ��5      .R�5      �� 
������ ._�5       �� 5!      5"      S� 57       58        59      5;      �� 5<      "  6'    5=   '   �� $ 
SubFolders�.R�5>      �� ��6   �� *Row+    5?      �� $ FullPath�5@      5A      .��5F      �  � RowDefinitions 5G   
   �� 5H      $��50 �6   �� 5I      �� 5J      $��55 �6    � ColumnDefinitions 5L   
   �� 5M      $	��200��6   $��1* �6.   �� 5N      $
��Auto �6   �� 5O      $��2* �6   .+�5Q   
   �� $��3��6   #��[  6%   $��3q�6L    �� CornerRadius$ 5��6`   �� 5R   
   $��3��6   $��2��6(   #��[  65   -  'DevExpress.Xpf.Bars.BarContainerControl  5e   
   $��3��6"   $��Center=�66   $��Center=�6S      Bars. 5f      )  #DevExpress.Xpf.Bars.MainMenuControl  ,	  &DevExpress.Xpf.Bars.ToolBarControlBase 	  Caption$ 	Main Menu��6"    	  ShowBackground .   	  Items. 5g      $
  DevExpress.Xpf.Bars.BarSubItem
  !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ 
파일(_F) 6!    
  Items. 5h      '  !DevExpress.Xpf.Bars.BarButtonItem  -   5          Name$ mnuAdd��5h   (   $  즐겨찾기에 추가(_A) 68    �� 	IsEnabled .     BarItemDisplayMode$ Default=�6a   6~     5i      -   5        $ 	mnuDelete��5i   (   $ 
삭제(_D) 6;    .  6^     5j      -   5        $ 	mnuRename��5j   (   $ 이름바꾸기(_M) 6;    .  6a   *  $DevExpress.Xpf.Bars.BarItemSeparator  5k        5l      -   5        $ 
mnuRefresh��5l   (   $ 새로고침(_R) 6<   6O     5m        5n      -   5        $ mnuExit��5n   (   $ 
종료(_X) 69   6J   5o      
  5p      -   5         
 Name$ mnuFix��5p   !   $ 
고정(_I) 61    .  6T   
  5q      -   5        $ mnuPrint��5q   !   $ 
인쇄(_P) 63    .  6V   
  5r      -   5        $ mnuEdit��5r   !   $ 
편집(_E) 62    .  6U   5s      5t      �� 5v   
   -	   5         ��Name$ btnBack��5v      $y�Hidden=�67   $��Back To Gallery��6K   )  #DevExpress.Xpf.Grid.TreeListControl  5z   
   -
   5          Name$ trvFolderExplorer��5z      $��1��69   )  #DevExpress.Xpf.Grid.DataControlBase    AutoGenerateColumns$  AddNew=�6F   #!   EnableSmartColumnsGeneration! . $��Stretch=�6�   $��Stretch=�6�   "   SelectionMode$	" Row=�5{      # %� IsVirtualizing# . $ %� VirtualizationMode$$ 	Recycling=�5}      %   ItemsSource% 5      �� 5�      $ 
SubFolders�6   & �� Source#& [ 6-   '   View' 5�      &   DevExpress.Xpf.Grid.TreeListView  5�      -   5        (   TreeDerivationMode$( HierarchicalDataTemplate=�5�   #   )   ShowHorizontalLines) .  *   ShowVerticalLines* .  +   ShowIndicator+ .  ,   TreeLineStyle$
, None=�5�   #   &   DevExpress.Xpf.Grid.DataViewBase-   ShowColumnHeaders- .  .   ChildNodesSelector. 5�   #   �� $ TreeVM�5�   #   5�      �� 5�   
   $��1��6   $��1��6'   $��Stretch=�64   $
��Left=�6P   $��2��6k   / �� ResizeBehavior$/ PreviousAndNext=�6u   �� 5�   
   -   5        0 ��Name$0 
lbxPicture��5�      $��1��6&   $��2��63   $��0q�6C   $��Disabled=�6W   ��5�      �� 5�      .R�5�      � 5�      5�      ]� 5�   
   -   5        1 ]�Name$1 pnlImageView��5�      $��1��6*   $��3��67   $y�Hidden=�6K   2 J� SnapsToDevicePixels2 . .+�5�      �� -   5        3 ��Name$3 	pnlFixbar��5�        bgButtonBrush#��[ 6,   .+�5�      �� -   5        $ btnRotateCW��5�      $��20q�6.   .��6O   Rotate Clockwise6a   �� 5�      -   5        $ btnRotateCCW��5�      $��20q�6/   .��6P   Rotate Counterclockwise6i   �� 5�      -   5        $ btnRotateSave��5�      $��20q�60   .��6Q   Save6W   5�      � 5�      
�������.+�5�      �� -   5        4 ��Name$4 	imgViewer��5�      $��Center=�6+   5 � LayoutTransform5 5�      �� 5�      5�      5�      5�      � 5�   
   $��2��6   $��3��6    5�      �� 5�      �� 5�      $
��Auto �6#   �� 5�      .+�5�      �� 6 �� Orientation$6 
Horizontal=�6   $��Right=�62   .+�5�      �� -   5        $ btnZoom��5�      $��Center=�6*   7 �� 	ClickMode$7 Press=�6E   8 � ToolTip$8 확대/축소��6W   .��5�      �� $��22��6   $��images\zoom.gif��6(   5�      � 5�      -   5        9 �Name$9 popZoom��5�      $��Center=�6Y   : � 	StaysOpen: .  ; � PlacementTarget; 6)   �� < �� ElementName$< btnZoom��.��5�      � 
�������.+�5�      �� 
���   �$��1q�65   $ 5��6I   ._�5�      �� -   5        = ��Name$= sldZoom��5�   %   $��20q�66   > �� Orientation$> Vertical=�6B   ? � Minimum$? 1Q�6Y   @ � Maximum$@ 10Q�6e   $	��100��6r   6�   5�      5�      5�      �� 5�      -   5        $ btnDefaultSize��5�      $��Center=�61   $8 원래사이즈��6L   .��5�      �� $��22��6   $%��images\defaultThumbnailSize.gif��6(   5�      5�      �� 5�      $��1��6   $6 
Horizontal=�6)   $��Center=�6B   .+�5�      �� -   5        $ btnPrev��5�      $��Center=�6*   $8 이전이미지��6E   .��5�      �� $��22��6   $��images\previous.gif��6(   5�      �� 5�      -   5        $ btnSlideShow��5�      $��Center=�6/   $8 슬라이드쇼��6J   $��52��6Z   $��42��6e   {�.  A J� Opacity$A .5Q�6�   .��5�      �� $��22��6   $��images\slideshow.gif��6(   5�      �� 5�      -   5        $ btnNext��5�      $��Center=�6*   $8 다음이미지��6E   {�.  $A .5Q�6g   .��5�      �� $��22��6   $��images\next.gif��6(   5�      5�      �� 5�      $��2��6   $6 
Horizontal=�6)   $
��Left=�6B   .+�5�      �� -   5        $ btnCounterClockWise��5�      $��Center=�66   $8 반시계방향회전��6Q   .��5�      �� $��22��6   $!��images\counterclockwise.gif��6(   5�      �� 5�      -   5        $ btnClockWise��5�      $��Center=�6/   $8 시계방향회전��6J   {�.  $A .5Q�6m   .��5�      �� $��22��6   $��images\clockwise.gif��6(   5�      �� 5�      -   5        $ 	btnDelete��5�      $��Center=�6,   $8 삭제��6G   {�.  $A .5Q�6f   .��5�      �� $��22��6   $��images\delete.gif��6(   5�      5�      5�      5�      5�      