   M S B A M L   `   `   `  ����O  KWpfApp3DPhotoGallery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfApp3DPhotoGalleryWpfApp3DPhotoGallery  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   bgBrush  �� 
StartPoint �� EndPoint � Offset � Color  bgBlueBrush  
scaleTrans �� ScaleX �� ScaleY  cubeButtonStyle �� 
TargetType �� 	Resources  Key �� 
TargetName	 �� TargetProperty
 g� Duration W� From	 W� To g� DecelerationRatio �� Property �� Value �� Triggers P� Property P� Value N� EnterActions  spin '� Camera � Position � LookDirection g� Content t� 	Direction g� 	Transform �� Rotation �� Axis �� Angle � Material u� Brush j� ViewportUnits  �� 	Transform! !� Visual" �� Path# �� RelativeSource$ � Geometry% k� 	Positions& k� TriangleIndices' k� TextureCoordinates�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      ,local"clr-namespace:WpfApp3DPhotoGallery  5      %r  &	        &	 N    &	 �    &	     7  �� 5      $	  0,0&�6*   $	 0,1&�6;   .��5   
   � $ 0Q�6   $
 Gray��6"   � 5   
   $	 0.3Q�6   $ 	#FF222222��6$   � 5   
   $	 0.3Q�6   $ Black��6$   � 5   
   $	 0.9Q�6   $ Black��6$   � 5	   
   $	 0.9Q�6   $ 	#FF222222��6$   � 5
   
   $ 1Q�6   $
 Gray��6"   5      �� 5      $	  0,0&�6.   $	 0,1&�6?   .��5   
   � $ 0Q�6   $ 	LightBlue��6"   � 5   
   $ 1Q�6   $ 	AliceBlue��6"   5      �� 5      $ 3Q�6(   $ 3Q�63   �� 5      " ��6$    5   
   ���� 5      spin .��5      W� $ cubeRotation��6"   $	 Angle�5   &   $
 0:0:1D�5   &   $ 0X�67   $	 360X�6@   $	 1.0Q�6I   5      5      .�5   
   ��  � �� 5      �� 5       5      P� 5        � �� .  5!      �� 5"   "   8��  62   5$      .R�5&      '�  5'      =� 5(      $ 4,4,41�60   $ -1,-1,-15�6A   x�5*      g� 5+       5,   "   t� 5-   &   $ -0.3,-0.4,-0.55�67   5/      g� 50      cube�� 51   "   �� 52   &    53   *   �� 54   .   cubeRotation��$ 0,1,05�6X   $ 0Q�6e   56   '    58   "   � 59   &   materialCube�� 5:   *   u� 5;   .    5<   2   !� 5=   6   $ Absolute=�6B   $  1,0,0,-1,0,1W�6[   ! 5>   :   �� 5?   >   ��6E   �� $" 
Background�# �� *TemplatedParent+._�5@   B   �� ��6H   �� $" Content�# �� *TemplatedParent+��5A   L   �� $" 
Foreground�# �� *TemplatedParent+5B   ?   5D   7   5F   /   $ 5H   *   k� 5I   .   mashCube��Q% �   .& �$     	

9' �   5L   1   5N   '   5P      5R      5S      5U      5V      5X      