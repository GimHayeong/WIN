   M S B A M L   `   `   `  ����F  BWpfAppMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppMediaWpfAppMedia  5      !    WpfAppMedia.MediaPlayerPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:WpfAppMedia     5        N� Title$  MediaPlayerPage��5	       � 	Resources 5
      �� 5   
   %    5      .��5      �  � Triggers 5   
   :� 5       :� RoutedEvent$ Button.Click��6    :� 
SourceName$ btnPlay��66   [�5      �� 5      -   5         ��Name$ 	playVideo��5   &   .��5      �� .��5      p�  p� Source$ Video/kaist.wmv?�6,    �� 
TargetName$ video��5   ,   5      5      5      :� 5      $ Button.Click��6   $ btnPause��66   [�5      ?� 5       �� BeginStoryboardName$ 	playVideo��6&   5       :� 5!      $ Button.Click��6   $ 	btnResume��66   [�5"      �� 5#      $ 	playVideo��6'   5%      .+�5(   
   r� -   5        	 r�Name$	 video��5(      6&   �� 5*   
   
 �� Orientation$
 
Horizontal=�6   $��Bottom=�6.    5+       �� 
TargetType �� Property �� Value�� 5,      %�   '��       �� 5-      " ��6   .�5.      ��  � �� �	#55FFFFFF67   �� 5/       � ��$
 5,10q�64   50      51      .+�53      �� -   5         ��Name$ btnPlay��53      $
��Play��6&   �� 54      -   5        $ btnPause��54      $��Pause��6'   �� 55      -   5        $ 	btnResume��55      $��Resume��6(   56      57      58      