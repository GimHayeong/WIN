   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   A =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfPhotoGalleryWpfPhotoGallery 5   	      WpfPhotoGallery.WinExcel   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   /localclr-namespace:WpfPhotoGallery     5   	   -   5          �Name$  window��5   	    � Title$ WinExcel��5	   	   $��555.2��6   $��434.4��6)    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$
 Help��5      6E     5   
   $	 Cut��6     5   
   $
 Copy��6     5   
   $ Paste��6     5   
   $
 Undo��6     5   
   $
 Redo��6    � 	Resources 5      �� 5   
      Key
photos   �� Type" ��6!   .s�5      ��
Item 1��6!   ��5      
Item 2��6!   ��5      
Item 3��6!   5      .��5      �� -   5         ��Name$ stpnlParent��5      .+�5   
   �� -   5         ��Name$ lblMsg��5      $��Center=�6    ��6=   �� *
Foreground+ �� ElementName$ btnForeground��.��6z   WPF Unleashed (Version 3.0)6�   �� 5   
   -   5        	 ��Name$	 btnExcel��5      $��엑셀실행하기��6#   $��Stretch=�64   $��Center=�6R   $��20,20,20,10q�6�   $��5q�6�   
 � ToolTip
 5      _� 5      .��6   PN엑셀을 실행하고 데이터와 차트를 생성하려면 클릭하세요.5      5!      �� 5"   
    �� Orientation$ 
Horizontal=�6   $��5q�6.   .+�5#      �� -   5         ��Name$ tbxName��5#      $	��100��6'   $��Center=�66   $��5,0,10,0q�6Q    �� AcceptsReturn .  ��5$      �� *
Background+$ btnBackground����6S   �� *
Foreground+$ btnForeground���� 5%      -   5        $	 btnBackground��5%      $��배경색설정��6,   $��5q�6<   $��
0,10,5, 10q�6H    �� 	IsDefault . ��5&      �� *
Foreground+$ btnForeground���� 5'      -   5        $	 btnForeground��5'      $��전경색설정��6,   $��5q�6=   $��
5,10,0, 10q�6I   ��5(      �� *
Background+$ btnBackground��5)      �� 5+   
   -	   5         ��Name$ 
lbxProduct��5+       5,        1 �� A �� R �� G �� B  2�� 5-      %�   &	       &	 J     �� 5.      $	 255��6&   $	 255��6.   $	 255��66   $	 255��6>   �� 5/      $ 0��6&   $ 0��6,   $ 0��62   $ 0��68   50      ��52      �� 53      .R�54      $�  $� Orientation$ 
Horizontal=�6-   55      @�57      �� 58       w� Text$ 3��6   $��Item 3��62   �� 59      $ 1��6   $��Item 1��62   �� 5:      $ 4��6   $��Item 4��62   �� 5;      $ 2��6   $��Item 2��62   5=      �� 5>   
   -
   5        $��아이템추가��5>      ��5?      �� 5@       �� 
TargetType" ��6    �� Triggers 5A      P� 5B       P� Property �@J�IsMouseOver P� Value . . �5C      ��  �� Property � �� �� Value
 �2͚�6;   �� 5D       � ��$ 20(�69   5E      5G      5I      �� 5J   
   $ 
Horizontal=�6   .+�5K      �� -   5        $��5q�5K      .��6H   클릭하세요6O   �� 5L      $��5q�6   $
��Help��6    ��6/   ��  �� RelativeSource �� *Self+ �� Path$ Command.Text�6}   �� 5M      -   5         ��Name$ cbxDisabled��5M      $��5q�6,    ^� ShowDuration$
 3000��67   {�.    ^� ShowOnDisabled  . 
 5N      _� 5O      .��5P      �� .+�5Q      �� $
��Bold"�6$   
����  �
�������.��6[   The Checkbox?6j   �� 5R      ! �� Padding$! 10q�6(   $��WrapWithOverflow=�65   $	��200��6U   hfCheckBox is a familiar control. But in WPF, it's not much more than a ToggleButton styled differently!5T      �� 5U      
���   �$��1��62   	" �� X2$	" 200��6F   �� 5V      $ 
Horizontal=�6)   .+�5W   "   �� $��2q�6(   $��20��63   $4��.D:\Projects\2015\WpfApp\WinApp\Images\help.png��6>   �� 5X   "   $
��Bold"�6(   .��6:   Press F1 for more help.6S   5Y      5Z      5[      .��5\   $   
Checkbox5]      �� 5^      $��10,0,5,0q�6   .��6&   아이템수:6-   �� 5_      ��6   ��  
 photos# �� Source## [ $ Count��� 5r      $ �� 
IsEditable$ . .@�5s      �� $ Curtain Call��6   $ 
Horizontal=�6<   $��5q�6U   .+�5t      �� $��20��6   $	��Top=�6'   $4��.D:\Projects\2015\WpfApp\WinApp\Images\help.png��6@   �� 5u      $	��200��6!   .+�5v      �� $
��5, 0q�6$   $��14(�62   $
��Bold"�6@   $��Center=�6R   Curtain Call6{   �� 5w      $��5q�6$   $��Center=�6/   $
��Wrap=�6J   DBWhimsical, with a red curtain background that repressents a stage.6�   5x      5y      �� 5z      $ 	Fireworks��6   $ 
Horizontal=�69   $��5q�6R   .+�5{      �� $��20��6   $	��Top=�6'   $4��.D:\Projects\2015\WpfApp\WinApp\Images\help.png��6?   �� 5|      $	��200��6!   .+�5}      �� $
��5, 0q�6$   $��14(�62   $
��Bold"�6@   $��Center=�6R   	Fireworks6x   �� 5~      $��5q�6$   $��Center=�6/   $
��Wrap=�6J   trSleek, with a black sky containing fireworks. When you need to celebrate PowerPoint-style, this design is for you!6�   5      5�      �� 5�      $ Items Control��6   .��5�      �� $ 
Horizontal=�6!   $��5q�6:   .+�5�      �� $��20��6    $	��Top=�6+   $4��.D:\Projects\2015\WpfApp\WinApp\Images\help.png��6D   �� 5�      $	��200��6%   .+�5�      �� $
��5, 0q�6(   $��14(�66   $
��Bold"�6D   $��Center=�6V   Items Control6�   �� 5�      $��5q�6(   $��Center=�63   $
��Wrap=�6N   %#Add a DateTime object to a ListBox.6�   5�      5�      5�      5�      5�      �� 5�   
   $ 
Horizontal=�6   .+�5�      �� $	��Cut��6   $��5q�6#   ��6.   ��  �� *Self+$ Command.Text���6z   �� $ tbxName���� 5�      $
��Copy��6   $��5q�6$   ��6/   ��  �� *Self+$ Command.Text���6{   �� $ tbxName���� 5�      $��Paste��6   $��5q�6%   ��60   ��  �� *Self+$ Command.Text���6|   �� $ tbxName���� 5�      $
��Undo��6   $��5q�6$   ��6/   ��  �� *Self+$ Command.Text���6{   �� $ tbxName���� 5�      $
��Redo��6   $��5q�6$   ��6/   ��  �� *Self+$ Command.Text���6{   �� $ tbxName��5�      �� 5�   
   $��학년선택��6   $��5q�6!   $��5q�6-   .��5�      �� .+�5�      �� $ 
Horizontal=�6   .+�5�      	� % 	� 	GroupName$% A��6"   $��10,0,5,0q�60   .��6B   
초1학년6H   	� 5�      $% A��6"   $��5,0,5,0q�60   .��6A   
초2학년6G   	� 5�      $% A��6"   $��5,0,5,0q�60   .��6A   
초3학년6G   	� 5�      $% A��6"   $��5,0,5,0q�60   .��6A   
초4학년6G   5�      �� 5�      $ 
Horizontal=�6   .+�5�      	� $% A��6"   $��10,0,5,0q�60   .��6B   
초5학년6H   	� 5�      $% A��6"   $��5,0,5,0q�60   .��6A   
초6학년6G   	� 5�      $% B��6"   $��5,0,5,0q�60   .��6A   
중1학년6G   	� 5�      $% B��6"   $��5,0,5,0q�60   .��6A   
중2학년6G   	� 5�      $% B��6"   $��5,0,5,0q�60   .��6A   
중3학년6G   5�      5�      5�      �� 5�   
   .@�5�      �� $��ListBox��6   .��5�      9� $��날짜��6   .��5�      �� & �� DisplayMemberPath$& 	DayOfWeek��6   ' � ContextMenu' 5�      �� 5�      .@�5�   "   �� Select date69   5�      .@�5�      ��1/1/2016��61   ��5�      1/1/2017��61   ��5�      1/1/2018��61   5�      5�      5�      �� 5�      $��ListView��6   .��5�      �� ( �� View( 5�      �� 5�      ) �� AllowsColumnReorder) . * �� ColumnHeaderToolTip$* Date Information��6>   .P�5�      �� $
��Date��6-   �� 5�      $��Day of week��6-   + �� DisplayMemberBinding+ 5�   %   �� *	DayOfWeek+�� 5�      $
��Year��6-   + 5�   %   �� *Year+5�      .@�5�      ��1/1/2016��6-   ��5�      1/1/2017��6-   ��5�      1/1/2018��6-   5�      5�      �� 5�      $��Frame��6   .��5�      9� $
��Daum��6   .��5�       � ,  � Source$, http://www.daum.net?�6   $	��200��69   6K   5�      5�      �� 5�      $
��Menu��6   .��5�      o� .@�5�      m� $��_File��6   .@�5�      m� $
��_New��6#   m� 5�      $��_Open��6#   �� 5�      m� 5�      $��Sen_d To��6#   .@�5�      m� $��Mail Recipient��6'   m� 5�      $��My Documents��6'   5�      5�      m� 5�      $��_Edit��6   .@�5�      m� $��_Copy��6#   m� 5�      $
��_Cut��6#   m� 5�      $��_Paste��6#   5�      m� 5�      $��_View��6   .@�5�      m� $��Zoom _In��6#   m� 5�      $��	Zoom _Out��6#   5�      5�      5�      �� 5�      $��TreeView��6   .��5�      R� .@�5�      Q� $��Desktop��6#   .@�5�      Q� $��Computer��6'   6;   Q� 5�      $��
Recyle Bin��6'   6=   Q� 5�      $��Control Panel��6'   .@�5�      Q� $��Program��6+   6>   Q� 5�      $��Security��6+   6?   Q� 5�      $��User Accounts��6+   6D   5�      Q� 5�      $��Network��6'   6:   5�      5�      5�      �� 5�      $��ToolBar��6   .��5�      c� .@�5�      �� .��5�      �� $9��3D:\Projects\2015\WpfApp\WinApp\Resources\MyIcon.ico��6    5�      �� 5�      d� 5�      $
��Bold"�6#   $	��5,0q�65   .��6B   B6E   d� 5�      $��Oblique$�6#   $	��5,0q�67   .��6D   I6G   d� 5�      $	��5,0q�6#   .��60   U63   �� 5�      d� 5�      .��6#   Left6)   d� 5      .��6#   Right6*   d� 5     .��6#   	Justify6,   �� 5     �� 5     $��Center=�6   .��67   Zoom6=   �� 5     $��40��6   .@�5     �� .��6'   100%6-   �� 5     .��6'   90%6,   �� 5     .��6'   80%6,   �� 5     .��6'   70%6,   �� 5	     .��6'   60%6,   �� 5
     .��6'   50%6,   5     �� 5     5     5     �� 5     $��	StatusBar��6   .��5     �� .@�5     �� .��6   
27 Items6&   �� 5     �� 5     $��Center=�6   .��67   Zoom6=   �� 5     $��20��6   .��5     �� $9��3D:\Projects\2015\WpfApp\WinApp\Resources\MyIcon.ico��6    5     � 5     - � Value$- 80Q�6"   $	��100��6-   $��5��69   . � IsIndeterminate. . 6D   5     5     �� 5     $��Slider��6   .��5     �� -   5        $ 
spnlSlider��5     .+�5     �� $ 
Horizontal=�6!   .+�5     �� $
��Bold"�6    $��5q�62   .��6=   R:6A   �� 5     -   5        / ��Name$
/ sldR��5  !   $	��100��6/   0 � Minimum$0 0Q�6>   1 � Maximum$	1 255Q�6J   2 �� TickPlacement$2 BottomRight=�6X   3 �� TickFrequency$3 20Q�6t   4 �� IsSnapToTickEnabled4 . 6�   �� 5      $��30��6"   $��Center=�60   $��3q�6K   ��6W   �� $
 sldR��$ Value�5 �� UpdateSourceTrigger$5 PropertyChanged=�5!     �� 5"     $ 
Horizontal=�6!   .+�5#     �� $
��Bold"�6    $��5q�62   .��6=   G:6A   �� 5$     -   5        $
/ sldG��5$  !   $	��100��6/   $0 0Q�6>   $	1 255Q�6J   $2 BottomRight=�6X   $3 20Q�6t   4 . 6�   �� 5%     $��30��6"   $��Center=�60   $��3q�6K   ��6W   �� $
 sldG��$ Value�$5 PropertyChanged=�5&     �� 5'     $ 
Horizontal=�6!   .+�5(     �� $
��Bold"�6    $��5q�62   .��6=   B:6A   �� 5)     -   5        $
/ sldB��5)  !   $	��100��6/   $0 0Q�6>   $	1 255Q�6J   $2 BottomRight=�6X   $3 20Q�6t   4 . 6�   �� 5*     $��30��6"   $��Center=�60   $��3q�6K   ��6W   �� $
 sldB��$ Value�$5 PropertyChanged=�5+     5-     5.     5/     �� 50  
   $ 
Horizontal=�6   .+�51     �� $��70��6   $��5q�6)   $	��200��64   $	��124��6C   . �52     /� .T�53     J� .*�6    .*�54     �� $ �내용을 입력하세요.��6   55     56     57     G� 58     $��70��6   $��5q�6(   $��Center=�63   � 59     .+�5:     �� $	��100��6   $	��100��6+   .H�5;     �� $	��100��6   $:��4D:\Projects\2015\WpfApp\WinApp\Resources\singers.jpg��6(   5<     5=     5>     5B     5C     